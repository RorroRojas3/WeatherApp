using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WeatherApp.OpenWeatherAPI;

namespace WeatherApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TapBtn_Clicked(object sender, EventArgs e)
        {
            var weather = new WeatherAPI();
            OpenWeatherRoot currentWeather = await weather.GetCurrentWeather();
            if (currentWeather != null)
            {
                weatherLabel.Text = "Current Weather: " + currentWeather.Main.Temp.ToString() + " C";
            }
        }
    }
}
