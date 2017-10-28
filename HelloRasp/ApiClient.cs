using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace HelloRasp
{
    public class ApiClient
    {
        private const string ApiKey = "0GdSrwLGGC1SDN7YpHwwcQPCVF1ROooi";

        private static readonly HttpClient _client = new HttpClient();


        public ApiClient()
        {
            _client.BaseAddress = new Uri("http://dataservice.accuweather.com");
        }


        //Currently not in use
        //public async Task<string> Post(string requestUri, HttpContent content)
        //{
        //    var response = await _client.PostAsync($"{requestUri}?apikey={ApiKey}", content).ConfigureAwait(false);
        //    var responseString = await response.Content.ReadAsStringAsync();

        //    return responseString;
        //}

        /// <summary>
        /// Send GET request to uri
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns>System.IO.Stream</returns>
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var response = await _client.GetAsync($"{requestUri}&apikey={ApiKey}").ConfigureAwait(false);

            return response;
        }

    }
}
