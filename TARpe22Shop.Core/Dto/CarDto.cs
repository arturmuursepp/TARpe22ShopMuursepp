using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopMyyrsepp.Core.Domain;

namespace TARpe22ShopMyyrsepp.Core.Dto
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public int SeatCount { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufactureDate { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiCarDto> FileToApiCarDtos { get; set; } = new List<FileToApiCarDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
