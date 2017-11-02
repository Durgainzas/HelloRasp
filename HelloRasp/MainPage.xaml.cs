using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using HelloRasp.Models;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloRasp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApiClient client = new ApiClient();
        IPinfo ipInfo = null;
        Location location = null;
            
        public MainPage()
        {
            this.InitializeComponent();
            Refresh_Init();
        }

        private async void Refresh_Init()
        {
            string locationKey = "";
            string ipAddress = "";
            string city = "";

            if (ipInfo == null)
            {
                ipInfo = await Helper.GetIpInfoAsync(client);
                ipAddress = ipInfo.query;
                city = ipInfo.city;

            }

            if (location == null)
            {
                location = await Helper.GetLocalKeyAsync(client, ipAddress);
                locationKey = location.Key;
            }


            var actualWeather = await Helper.GetActualWeatherAsync(client, location.Key);

            if (actualWeather != null)
            {
                TextBlockTime.Text = actualWeather.GetDateTime();
                TextBlockLocation.Text = city;
                TextBlockWeatherText.Text = actualWeather.WeatherText;
                TextBlockTemperature.Text = actualWeather.GetTemperature() + " °C";
            }
            else
            {
                TextBlockTime.Text = "Error loading data";
                TextBlockWeatherText.Text = "Error loading data";
                TextBlockTemperature.Text = "Error loading data";
            }

            TextBlockIPAddress.Text = ipAddress;

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh_Init();
            TextBlockLocation.Text = "blah";
        }
    }
}
