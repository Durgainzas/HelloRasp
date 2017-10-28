using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloRasp.Models;
using System.Runtime.Serialization;

namespace HelloRasp
{
    public static class Helper
    {
        public const string IP = "78.45.147.145";

        /// <summary>
        /// Get localKey string from server
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static async Task<string> GetLocalKey(ApiClient client)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Location));

            var response = await client.GetAsync(GetLocationByIP(IP));
            if (response.IsSuccessStatusCode == false)
            {
                return response.ReasonPhrase;
            }

            var responseStream = await response.Content.ReadAsStreamAsync();

            var deserializedResponse = (Location)serializer.ReadObject(responseStream);


            return deserializedResponse.Key;
        }
        
        //public async Task<string> GetActualWeather()
        //{

        //}
        
        #region endpoints

        public static string GetLocationByIP(string ip) 
            => $"/locations/v1/cities/ipaddress?q={ip}";

        public static string GetWeatherFromLocationKey(string locationKey)
            => $"/currentconditions/v1/{locationKey}";
        
        #endregion

    }
}
