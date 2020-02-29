using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/game/");

            var runResponse = await client.PostAsync("run", null);
            runResponse.EnsureSuccessStatusCode();
            
            while (true)
            {
                await Task.Delay(1000);
                var infoResponse = await client.GetAsync("info");
                infoResponse.EnsureSuccessStatusCode();
                var infoString = await infoResponse.Content.ReadAsStringAsync();
                var info = JsonConvert.DeserializeObject<string[]>(infoString) ?? new string[0];
                foreach (var s in info)
                {
                    Console.WriteLine(s);
                }

                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid number");
                    Console.WriteLine("Try again");
                }

                var choiceResponse = await client.PostAsync($"choice?choice={input}", null);
                choiceResponse.EnsureSuccessStatusCode();
            }
        }
    }
}