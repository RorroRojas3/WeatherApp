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

        private async void currentWeatheButton_Clicked(object sender, EventArgs e)
        {
            var weather = new WeatherAPI();
            var city = enteredCity.Text;
            OpenWeatherRoot currentWeather = await weather.GetCurrentWeather(city);
            if (currentWeather != null)
            { 
                // Gets the correponding image source
                string imageSource = weather.GetWeatherImage(currentWeather);
                weatherImage.Source = imageSource;


                // Changes the text on the corresponding fields 
                currentTempLabel.Text = currentWeather.Main.Temp.ToString();
                minTempLabel.Text = currentWeather.Main.Temp_min.ToString();
                maxTempLabel.Text = currentWeather.Main.Temp_max.ToString();
                currentHumLabel.Text = currentWeather.Main.Humidity.ToString();


            }
        }
    }
}
