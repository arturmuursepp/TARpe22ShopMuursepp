using Nancy.Json;
using System.Net;
using TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos2;

namespace TARpe22ShopMyyrsepp.ApplicationServices.Services
{
    public class WeatherForecastsServices2 : IWeatherForecastsServices2
    {
        public async Task<WeatherResultDto2> WeatherDetail2(WeatherResultDto2 dto)
        {

            string apikey = "c2f19baf224d7c08f5988443fe939d9a";
            var url = $"https://api.openweathermap.org/data/2.5/weather?q=tallinn&appid={apikey}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherRootDto2 weatherInfo = new JavaScriptSerializer().Deserialize<WeatherRootDto2>(json);

                dto.Country = weatherInfo.Sys.Country;
                dto.Type = weatherInfo.Sys.Type;
                dto.City = weatherInfo.Name;
                dto.Timezone = weatherInfo.Timezone;
                dto.Temperature = weatherInfo.Main.Temp;
                dto.Feels_like = weatherInfo.Main.Feels_like;
                dto.Temperature_minimum = weatherInfo.Main.Temp_min;
                dto.Temperature_maximum = weatherInfo.Main.Temp_max;
                dto.Lon = weatherInfo.Coord.Lon;
                dto.Lat = weatherInfo.Coord.Lat;
                dto.Description = weatherInfo.Weather[0].Description;
            }

            return dto;
        }
    }
}