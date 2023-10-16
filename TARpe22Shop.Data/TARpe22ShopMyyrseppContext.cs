using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopMyyrsepp.Core.Domain.Spaceship;

namespace TARpe22ShopMyyrsepp.Data
{
    public class TARpe22ShopMyyrseppContext: DbContext
    {
        public TARpe22ShopMyyrseppContext(DbContextOptions<TARpe22ShopMyyrseppContext> options) : base(options) { }
        public DbSet<Spaceship> Spaceships { get; set; }
    }
}
