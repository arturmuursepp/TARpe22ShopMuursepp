using TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos;

namespace TARpe22ShopMyyrsepp.ApplicationServices.Services
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}