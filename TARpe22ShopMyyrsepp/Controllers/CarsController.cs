using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;
using TARpe22ShopMyyrsepp.Core.Dto;
using TARpe22ShopMyyrsepp.Core.ServiceInterface;
using TARpe22ShopMyyrsepp.Models.RealEstate;
using TARpe22ShopMyyrsepp.Core.Dto;
using TARpe22ShopMyyrsepp.Core.ServiceInterface;
using TARpe22ShopMyyrsepp.Data;
using TARpe22ShopMyyrsepp.Models.RealEstate;
using TARpe22ShopMyyrsepp.Models.Car;
using TARpe22ShopMyyrsepp.ApplicationServices.Services;
using TARpe22ShopMyyrsepp.Core.Domain;

namespace TARpe22ShopMyyrsepp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsServices _carsServices;
        private readonly TARpe22ShopMyyrseppContext _context;
        private readonly IFilesServicesCar _filesServices;
        public CarsController(ICarsServices carsServices, TARpe22ShopMyyrseppContext context, IFilesServicesCar filesServices)
        {
            _carsServices = carsServices;
            _context = context;
            _filesServices = filesServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    ModelName = x.ModelName,
                    Price = x.Price,
                    Manufacturer = x.Manufacturer,
                    SeatCount = x.SeatCount,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = Guid.NewGuid(),
                ModelName = vm.ModelName,
                Price = vm.Price,
                Type = vm.Type,
                Color = vm.Color,
                FuelType = vm.FuelType,
                SeatCount = vm.SeatCount,
                Manufacturer = vm.Manufacturer,
                ManufactureDate = vm.ManufactureDate,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FileToApiCarDtos = vm.FilesToApiCarViewModels
                .Select(x => new FileToApiCarDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApiCar
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiCarViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();
            vm.Id = car.Id;
            vm.ModelName = car.ModelName;
            vm.Price = car.Price;
            vm.Type = car.Type;
            vm.Color = car.Color;
            vm.FuelType = car.FuelType;
            vm.SeatCount = car.SeatCount;
            vm.Manufacturer = car.Manufacturer;
            vm.ManufactureDate = car.ManufactureDate;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = DateTime.Now;
            vm.FilesToApiCarViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = (Guid)vm.Id,
                ModelName = vm.ModelName,
                Price = vm.Price,
                Type = vm.Type,
                Color = vm.Color,
                FuelType = vm.FuelType,
                SeatCount = vm.SeatCount,
                Manufacturer = vm.Manufacturer,
                ManufactureDate = vm.ManufactureDate,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FileToApiCarDtos = vm.FilesToApiCarViewModels
                .Select(x => new FileToApiCarDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApiCar
            .Where(x => x.CarId == id)
            .Select(y => new FileToApiCarViewModel
            {
                FilePath = y.ExistingFilePath,
                ImageId = y.Id
            }).ToArrayAsync();
            var vm = new CarDetailsViewModel();
            vm.Id = car.Id;
            vm.ModelName = car.ModelName;
            vm.Price = car.Price;
            vm.Type = car.Type;
            vm.Color = car.Color;
            vm.FuelType = car.FuelType;
            vm.SeatCount = car.SeatCount;
            vm.Manufacturer = car.Manufacturer;
            vm.ManufactureDate = car.ManufactureDate;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.FileToApiCarViewModels.AddRange(images);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApiCar
            .Where(x => x.CarId == id)
            .Select(y => new FileToApiCarViewModel
            {
                FilePath = y.ExistingFilePath,
                ImageId = y.Id
            }).ToArrayAsync();
            var vm = new CarDeleteViewModel();
            vm.Id = car.Id;
            vm.ModelName = car.ModelName;
            vm.Price = car.Price;
            vm.Type = car.Type;
            vm.Color = car.Color;
            vm.FuelType = car.FuelType;
            vm.SeatCount = car.SeatCount;
            vm.Manufacturer = car.Manufacturer;
            vm.ManufactureDate = car.ManufactureDate;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.FileToApiCarViewModels.AddRange(images);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _carsServices.Delete(id);
            if (car != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiCarViewModel vm)
        {
            var dto = new FileToApiCarDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
