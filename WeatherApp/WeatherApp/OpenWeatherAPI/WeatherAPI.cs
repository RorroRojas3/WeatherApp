using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.OpenWeatherAPI;

namespace WeatherApp.OpenWeatherAPI
{
    public class WeatherAPI
    {
        public async Task<OpenWeatherRoot> GetCurrentWeather()
        {
            try
            {
                HttpClient client = new HttpClient();
                string units = "metric";
                string apiKey = "9d3692f574b8ba802d57747928cf6442";
                string apiURL = string.Format("http://api.openweathermap.org/data/2.5/weather?q=Douglasville&units={0}&appid={1}", units, apiKey);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiURL);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    OpenWeatherRoot result = JsonConvert.DeserializeObject<OpenWeatherRoot>(json);
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string GetWeatherImage(OpenWeatherRoot weather)
        {
            string imageSource = string.Format("http://openweathermap.org/img/w/{0}.png", weather.Weather[0].Icon);
            return imageSource;
        }
    }
}
