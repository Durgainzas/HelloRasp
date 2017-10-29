using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {

            //Textblock1.Text = await Helper.GetLocalKeyAsync(client);

            var actualWeather = await Helper.GetActualWeatherAsync(client);
            var ipAddress = await Helper.GetIpInfoAsync(client);

            TextBlockTemperature.Text = ;



        }
    }
}
