using Flurl.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ClientApp
{
    class GameServerApi
    {
        public GameServerApi()
        {
            client = new FlurlClient("https://localhost:5001/api/game/");
        }

        public FlurlClient client { get; }


        public async Task RunGame()
        {
            var runResponse = await client
                .Request()
                .AppendPathSegment("run")
                .PostAsync(null);
        }

        public async Task<string[]> Info()
        {
            var infoResponse = await client
                .Request()
                .AppendPathSegment("info")
                .GetAsync();
            var infoString = await infoResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string[]>(infoString) ?? new string[0];
        }

        public async Task Choice(int input)
        {
            var choiceResponse = await client
                .Request()
                .AppendPathSegment("choice")
                .SetQueryParam("choice", input)
                .PostAsync(null);
        }
    }
}