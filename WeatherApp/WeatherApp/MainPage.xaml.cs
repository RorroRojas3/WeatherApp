using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using WeatherAndroidiOS.WeahterAPI;

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

        private async void ButtonOne_Clicked(object sender, EventArgs e)
        {
            var info = await WeatherAPI.GetWeatherAsync();
            if (info != null)
            {
                buttonOne.Text = info.Main.Temp;
            }
        }
    }
}
