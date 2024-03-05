using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos2
{
    public class WeatherResultDto2
    {
        public string Country { get; set; }
        public int Type { get; set; }
        public string City { get; set; }
        public int Timezone { get; set; }
        public float Temperature { get; set; }
        public float Feels_like { get; set; }
        public float Temperature_minimum { get; set; }
        public float Temperature_maximum { get; set; }
        public int Lon { get; set; }
        public int Lat {  get; set; }
        public string Description { get; set; }
    }
}
