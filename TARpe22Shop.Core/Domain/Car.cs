using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopMyyrsepp.Core.Domain
{
    public class Car
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
        public IEnumerable<FileToApiCar> FilesToApiCar { get; set; } = new List<FileToApiCar>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
