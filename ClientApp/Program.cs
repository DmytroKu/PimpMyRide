using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new GameServerApi();
            await api.RunGame();
            while (true)
            {
                await Task.Delay(1000);
                var info = await api.Info();
                foreach (var x in info)
                    Console.WriteLine(x);

                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid number");
                    Console.WriteLine("Try again");
                }

                await api.Choice(input);
            }
        }
    }
}