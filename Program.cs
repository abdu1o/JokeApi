using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Lesson_20_10
{
    internal class Program
    {
        public class Joke
        {
            public string joke { get; set; }
        }

        static async Task Main()
        {
            string url = "https://geek-jokes.sameerkumar.website/api?format=json";

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                string joke_txt = await response.Content.ReadAsStringAsync();

                Joke joke = JsonConvert.DeserializeObject<Joke>(joke_txt);

                string[] sentences = Regex.Split(joke.joke, @"(?<=[.!?])\s+");
                foreach (string sentence in sentences)
                {
                    Console.WriteLine(sentence);
                }
            }

            Console.WriteLine("\n");
        }
    }
}
