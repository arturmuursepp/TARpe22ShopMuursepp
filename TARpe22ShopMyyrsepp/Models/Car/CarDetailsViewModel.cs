namespace TARpe22ShopMyyrsepp.Models.Car
{
    public class CarDetailsViewModel
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
        public List<FileToApiCarViewModel> FileToApiCarViewModels { get; set; } = new List<FileToApiCarViewModel>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
