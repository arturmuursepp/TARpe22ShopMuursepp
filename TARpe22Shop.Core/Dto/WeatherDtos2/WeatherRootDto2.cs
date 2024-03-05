using System.Text.Json.Serialization;

namespace TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos2
{
    public class WeatherRootDto2
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cod")]
        public int Cod {  get; set; }

        public Sys Sys { get; set; }
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
    }
    public class Coord
    {
        [JsonPropertyName("lon")]
        public int Lon { get; set; }
        [JsonPropertyName("lat")]
        public int Lat { get; set; }
    }
    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
    public class Main
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float Feels_like { get; set; }

        [JsonPropertyName("temp_min")]
        public float Temp_min { get; set; }

        [JsonPropertyName("temp_max")]
        public float Temp_max { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int Sea_level { get; set; }

        [JsonPropertyName("grnd_level")]
        public int Grnd_level { get; set; }
    }
    public class Wind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public float Deg { get; set; }

        [JsonPropertyName("gust")]
        public float Gust { get; set; }
    }
    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set;}
    }
}
