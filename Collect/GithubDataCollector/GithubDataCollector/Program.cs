using System;
using System.Net.Http;

namespace GithubDataCollector
{
    class Program
    {
        static readonly HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Rander");
            HttpResponseMessage message = _client.GetAsync("https://api.github.com/users").Result;
            Console.WriteLine(message.Content.ReadAsStringAsync().Result);
        }
    }
}
