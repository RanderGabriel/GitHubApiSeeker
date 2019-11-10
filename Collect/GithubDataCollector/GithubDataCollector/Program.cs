using GithubDataCollector.Injection;
using GithubDataCollector.Models;
using GithubDataCollector.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace GithubDataCollector
{
    class Program
    {
        private int MAX_PAGE;
        private int PAGES_NUMBER;
        private int START_PAGE;

        public int[] pages;
        public Thread[] threads;
        public readonly HttpClient _client = new HttpClient();
        public IUserRepository _userRepository;
        public IRepoRepository _repoRepository;

        public Program(int pages_number, int start_page, int max_page)
        {
            MAX_PAGE = max_page;
            START_PAGE = start_page;
            PAGES_NUMBER = pages_number;
            pages = new int[PAGES_NUMBER];
            threads = new Thread[PAGES_NUMBER];
        }

        public async void SaveRepo(User user)
        {
            var resp = await _client.GetAsync(user.repos_url);
            List<Repo> repos = JsonConvert.DeserializeObject<List<Repo>>(await resp.Content.ReadAsStringAsync());
            Console.WriteLine($"Saving repos for user: {user.login}");
            _repoRepository.SalvarLista(repos);
        }
        public void FetchAndSaveRepos()
        {
            List<User> users = (List<User>) _userRepository.RecuperarTodos();
            foreach(User u in users)
            {
                Console.WriteLine($"Fetching repos for user: {u.login}");
                SaveRepo(u);
            }
        }

        static void Main(string[] args)
        {
            int pagesSize = 5000000;
            for(int i = 0; i<6; i++)
            {
                var client = new Program(15, i * pagesSize, (i+1)*pagesSize);
                client.FetchRepositories("RanderGabriel:4ec88934d7e4cca8ca875a1b0a4a58609322384e");
            }
        }

        private void FetchRepositories(string authorization)
        {

            var byteArray = Encoding.ASCII.GetBytes(authorization);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubApiSeeker");
            _userRepository = new UserRepository(SessionFactory.AbrirSession());
            _repoRepository = new RepoRepository(SessionFactory.AbrirSession());
            //HttpResponseMessage users_message;
            //Thread t = new Thread(FetchAndSaveRepos);
            //t.Start();
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i] = (START_PAGE) + i * (MAX_PAGE / pages.Length);
                Console.WriteLine($"pages[i]: {pages[i]}");
            }

            for (int i = 1; i < pages.Length - 1; i++)
            {
                threads[i] = new Thread(FetchUsersFromTo);
                threads[i].Start(i - 1);
            }
        }

        static int usersCount = 0;
        public long startTime = DateTime.Now.Ticks;
        public readonly object locker = new object();
        private void FetchUsersFromTo(object indexStart)
        {
            int pageStart = pages[(int)indexStart];
            int pageEnd = pages[(int)indexStart + 1];
            HttpResponseMessage users_message;
            int lastFetched = pageStart;
            while(lastFetched <= pageEnd)
            {
                //Console.WriteLine("Fetching: " + $"https://api.github.com/users?since={lastFetched}");
                
                try
                {
                    users_message = _client.GetAsync($"https://api.github.com/users?since={lastFetched}").Result;
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(users_message.Content.ReadAsStringAsync().Result);
                    lock (locker)
                    {
                        _userRepository.SalvarLista(users);
                    }

                    lastFetched = users.Max((el) => (el.id));
                    usersCount += users.Count;
                    //Console.WriteLine("Users rate: " + ((usersCount * 30) / (double)(DateTime.Now.Ticks - startTime)) * TimeSpan.TicksPerHour);
                    //Console.WriteLine("Users count: " + usersCount * 30);
                    //Console.WriteLine("Hours: " + (DateTime.Now.Ticks - startTime) / TimeSpan.TicksPerHour);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Limit exceeded!");
                    Thread.Sleep(70000);
                    FetchUsersFromTo(indexStart);
                }
            }

        }

        public void SaveReposForUser(User u)
        {

            //Busca os repos do usuario
            HttpResponseMessage repos_message = _client.GetAsync(u.repos_url).Result;
            Repo[] repos = JsonConvert.DeserializeObject<Repo[]>(repos_message.Content.ReadAsStringAsync().Result);
            foreach (Repo r in repos)
            {
                r.owner = u;
                r.repos_id = 0;
                // Parse permissions
                r.perm_is_admin = r.permissions["admin"];
                r.perm_can_push = r.permissions["push"];
                r.perm_can_pull = r.permissions["pull"];
                // Parse topics
                if (r.topics != null)
                {
                    foreach (string t in r.topics)
                    {
                        r.repo_topics.Add(new Topics() { topics_id = t });
                    }
                }
                _repoRepository.Salvar(r);
            }
        }
    }
}

