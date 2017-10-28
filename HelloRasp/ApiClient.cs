using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HelloRasp
{
    public class ApiClient
    {
        private const string ApiKey = "0GdSrwLGGC1SDN7YpHwwcQPCVF1ROooi";

        public static readonly HttpClient client = new HttpClient();


        public ApiClient()
        {
            
        }

        public async Task<string> Post(string requestUri, HttpContent content)
        {
            var response = await client.PostAsync($"{requestUri}?apikey={ApiKey}", content);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<string> Get(string requestUri)
        {
            var responseString = await client.GetStringAsync($"{requestUri}?apikey={ApiKey}");

            return responseString;
        }

    }
}
