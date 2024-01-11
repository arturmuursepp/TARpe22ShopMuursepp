using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopMyyrsepp.Core.Domain;

namespace TARpe22ShopMyyrsepp.Data
{
    public class TARpe22ShopMyyrseppContext: DbContext
    {
        public TARpe22ShopMyyrseppContext(DbContextOptions<TARpe22ShopMyyrseppContext> options) : base(options) { }
        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
    }
}
