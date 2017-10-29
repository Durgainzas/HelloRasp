using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRasp.Models
{
    public class ActualWeather
    {
        public string EpochTime { get; set; }
        public string WeatherText { get; set; }
        public Temperature Temperature { get; set; }

        public string GetTemperature()
        {
            return Temperature.Metric.Value;
        }

        public string GetDateTime()
        {
            if (long.TryParse(EpochTime, out long unixTime) == false)
            {
                return "Error";
            }

            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime);

            return dateTimeOffset.LocalDateTime.ToString();
        }

    }

    public class Temperature
    {
        public Metric Metric { get; set; }
    }

    public class Metric
    {
        public string Value { get; set; }
    }
}
