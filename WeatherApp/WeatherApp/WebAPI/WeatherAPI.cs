using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAndroidiOS.WeahterAPI
{
    public class Main
    {
        public string Temp { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Visibility { get; set; }
    }

    public class Coord
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
    }

    public class WeatherInfo
    {
        public Coord Coord { get; set; }
        public Main Main { get; set; }
    }

    public static class WeatherAPI
    {
        public static async Task<WeatherInfo> GetWeatherAsync()
        {
            string apiName = "appid";
            string apiKey = "fd927b17103cb228f51abd437902ffa2";
            HttpClient client = new HttpClient();
            // client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add(apiName, apiKey);

            try
            {
                var main = await GetWeatherInfoAsync(client);
                return main;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static async Task<WeatherInfo> GetWeatherInfoAsync(HttpClient client)
        {
            WeatherInfo result = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=Atlanta&appid=fd927b17103cb228f51abd437902ffa2");
                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsStringAsync();
                    result = await response.Content.ReadAsAsync<WeatherInfo>();

                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
