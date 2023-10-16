using Microsoft.AspNetCore.Mvc;
using TARpe22ShopMyyrsepp.Data;
using TARpe22ShopMyyrsepp.Models.SpaceShip;

namespace TARpe22ShopMyyrsepp.Controllers
{
    public class SpaceshipsContoller : Controller
    {
        private readonly TARpe22ShopMyyrseppContext _context;
        public SpaceshipsContoller(TARpe22ShopMyyrseppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower
                });
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
