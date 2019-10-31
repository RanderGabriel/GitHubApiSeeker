using GithubDataCollector.Injection;
using GithubDataCollector.Models;
using GithubDataCollector.Repository;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace GithubDataCollector
{
    class Program
    {

        static readonly HttpClient _client = new HttpClient();
        static IUserRepository _userRepository;

        public Program(IUserRepository repo)
        {

        }
        static void Main(string[] args)
        {
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Rander");
            HttpResponseMessage message = _client.GetAsync("https://api.github.com/users/RanderGabriel").Result;
            User u = JsonConvert.DeserializeObject<User>(message.Content.ReadAsStringAsync().Result);
            u.user_id = 0;
            _userRepository = new UserRepository(SessionFactory.AbrirSession());
            _userRepository.Salvar(u);
            Console.WriteLine(message.Content.ReadAsStringAsync().Result);
        }
    }
}

