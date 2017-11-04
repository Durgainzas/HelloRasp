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
            try
            {
                if (ipInfo == null)
                {
                    ipInfo = await Helper.GetIpInfoAsync(client);
                }

                if (location == null)
                {
                    location = await Helper.GetLocalKeyAsync(client, ipInfo.query);
                }

                var actualWeather = await Helper.GetActualWeatherAsync(client, location.Key);
                TextBlockTime.Text = actualWeather.GetDateTime();
                TextBlockLocation.Text = ipInfo.city;
                TextBlockWeatherText.Text = actualWeather.WeatherText;
                TextBlockTemperature.Text = actualWeather.GetTemperature() + " °C";
                TextBlockIPAddress.Text = ipInfo.query;
            }
            catch (Exception)
            {
                TextBlockTime.Text = "";
                TextBlockLocation.Text = "";
                TextBlockWeatherText.Text = "";
                TextBlockTemperature.Text = "";
                TextBlockIPAddress.Text = "Error loading data. Please check internet connection or try again later.";
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            TextBlockTime.Text = "Loading...";
            TextBlockLocation.Text = "Loading...";
            TextBlockWeatherText.Text = "Loading...";
            TextBlockTemperature.Text = "Loading...";
            TextBlockIPAddress.Text = "Loading...";
            Refresh_Init();
        }
    }
}
