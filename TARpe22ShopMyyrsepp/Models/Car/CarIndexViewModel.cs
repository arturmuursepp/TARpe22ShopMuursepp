using TARpe22ShopMyyrsepp.Core.Domain;

namespace TARpe22ShopMyyrsepp.Models.Car
{
    public class CarIndexViewModel
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

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
