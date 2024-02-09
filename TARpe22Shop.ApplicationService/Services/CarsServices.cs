using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopMyyrsepp.Core.Domain;
using TARpe22ShopMyyrsepp.Core.Dto;
using TARpe22ShopMyyrsepp.Core.ServiceInterface;
using TARpe22ShopMyyrsepp.Data;

namespace TARpe22ShopMyyrsepp.ApplicationService.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARpe22ShopMyyrseppContext _context;
        private readonly IFilesServicesCar _filesServices;

        public CarsServices
            (
            TARpe22ShopMyyrseppContext context,
            IFilesServicesCar filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.ModelName = dto.ModelName;
            car.Price = dto.Price;
            car.Type = dto.Type;
            car.Color = dto.Color;
            car.FuelType = dto.FuelType;
            car.SeatCount = dto.SeatCount;
            car.Manufacturer = dto.Manufacturer;
            car.ManufactureDate = DateTime.Now;


            _filesServices.FilesToApiCar(dto, car);

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .Include(x => x.FilesToApiCar)
                .FirstOrDefaultAsync(x => x.Id == id);
            var images = await _context.FilesToApiCar
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiCarDto
                {
                    Id = y.Id,
                    CarId = y.CarId,
                    ExistingFilePath = y.ExistingFilePath
                }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.ModelName = dto.ModelName;
            car.Price = dto.Price;
            car.Type = dto.Type;
            car.Color = dto.Color;
            car.FuelType = dto.FuelType;
            car.SeatCount = dto.SeatCount;
            car.Manufacturer = dto.Manufacturer;
            car.ManufactureDate = dto.ManufactureDate;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
