using Microsoft.AspNetCore.Mvc;
using TARpe22ShopMyyrsepp.Models.Weather;
using TARpe22ShopMyyrsepp.ApplicationServices.Services;
using TARpe22ShopMyyrsepp.Core.Dto.WeatherDtos2;

namespace TARpe22ShopMyyrsepp.Controllers
{
    public class WeatherForeCasts2Controller : Controller
    {
        private readonly IWeatherForecastsServices2 _weatherForecastsServices2;
        public WeatherForeCasts2Controller(IWeatherForecastsServices2 weatherForecastsServices2)
        {
            _weatherForecastsServices2 = weatherForecastsServices2;
        }
        public IActionResult Index()
        {
            WeatherViewModel2 vm = new WeatherViewModel2();
            return View(vm);
        }
        [HttpPost]
        public IActionResult ShowWeather2()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts2");
            }
            return View();
        }
        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto2 dto = new();
            WeatherViewModel2 vm = new();

            _weatherForecastsServices2.WeatherDetail2(dto);

            vm.City = dto.City;
            vm.Timezone = dto.Timezone;
            vm.Country = dto.Country;
            vm.Type = dto.Type;
            vm.Temperature = dto.Temperature;
            vm.Feels_like = dto.Feels_like;
            vm.Temperature_minimum = dto.Temperature_minimum;
            vm.Temperature_maximum = dto.Temperature_maximum;
            vm.Lon = dto.Lon;
            vm.Lat = dto.Lat;
            vm.Description = dto.Description;

            return View(vm);
        }
    }
}
