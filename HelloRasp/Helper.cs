using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloRasp.Models;
using Newtonsoft.Json;

namespace HelloRasp
{
    public static class Helper
    {
        public const string IP = "78.45.147.145";
        public const string BaseUriAccuWeather = "http://dataservice.accuweather.com";
        public const string BaseUriIpInfo = "http://ip-api.com/";

        /// <summary>
        /// Get localKey string from server
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static async Task<string> GetLocalKey(ApiClient client)
        {
            var response = await client.GetAsync(BaseUriAccuWeather, EndpointGetLocationByIP(await GetIpInfo(client)));
            if (response.IsSuccessStatusCode == false)
            {
                return response.ReasonPhrase;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<Location>(responseString);


            return deserializedResponse.Key;
        }

        public static async Task<string> GetIpInfo(ApiClient client)
        {
            var response = await client.GetAsync(BaseUriIpInfo, EndpointGetIpInfo(), false);
            if (response.IsSuccessStatusCode == false)
            {
                return response.ReasonPhrase;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<IPinfo>(responseString);


            return deserializedResponse.querry;

        }



        #region endpoints

        public static string EndpointGetLocationByIP(string ip) 
            => $"/locations/v1/cities/ipaddress?q={ip}&";

        public static string EndpointGetWeatherFromLocationKey(string locationKey)
            => $"/currentconditions/v1/{locationKey}?";

        public static string EndpointGetIpInfo()
            => "json";

        #endregion

    }
}
