using GithubDataCollector.Injection;
using GithubDataCollector.Models;
using GithubDataCollector.Repository;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace GithubDataCollector
{
    class Program
    {

        static readonly HttpClient _client = new HttpClient();
        static IUserRepository _userRepository;
        static IRepoRepository _repoRepository;

        public Program(IUserRepository repo)
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Voce quer buscar usuarios? (S/N)");
            string command = Console.ReadLine();
            var byteArray = Encoding.ASCII.GetBytes("RanderGabriel:4ec88934d7e4cca8ca875a1b0a4a58609322384e");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubApiSeeker");
            _userRepository = new UserRepository(SessionFactory.AbrirSession());
            _repoRepository = new RepoRepository(SessionFactory.AbrirSession());
            while (command.ToLower().Contains("s"))
            {
                
                HttpResponseMessage users_message = _client.GetAsync("https://api.github.com/users").Result;
                User[] users = JsonConvert.DeserializeObject<User[]>(users_message.Content.ReadAsStringAsync().Result);
                if (users != null)
                {

                    foreach (User u in users)
                    {
                        //Salva um novo usuario
                        u.user_id = 0;
                        _userRepository.Salvar(u);

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
                Console.WriteLine(users_message.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Voce quer buscar usuarios? (S/N)");
                command = Console.ReadLine();
            }
        }
    }
}

