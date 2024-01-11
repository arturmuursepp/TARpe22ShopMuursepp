using TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos;

namespace TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }
    }
}
