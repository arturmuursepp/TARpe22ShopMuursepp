using TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos2;

namespace TARpe22ShopMyyrsepp.ApplicationServices.Services
{
    public interface IWeatherForecastsServices2
    {
        Task<WeatherResultDto2> WeatherDetail2(WeatherResultDto2 dto);
    }
}