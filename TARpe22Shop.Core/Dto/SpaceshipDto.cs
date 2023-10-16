using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopMyyrsepp.Core.Dto
{
    public class SpaceshipDto
    {
        public Guid Id { get; set; } // unique id
        public int Price { get; set; } // prcie of the spaceship
        public string Type { get; set; } // spaceship type [Rocket, Saucer, Cruise ship, Cargoship]
        public string Name { get; set; } // name of the ship not build make or model
        public string Description { get; set; } // description of the ship, containing misc info
        public string FuelType { get; set; } // what type of fuel the ship uses
        public int FuelCapacity { get; set; } // how much fuel it can hold
        public int FuelConsumption { get; set; } // how much fuel the ship consumes per day on day
        public int PassengerCount { get; set; } // how many passengers fit on the ship
        public int EnginePower { get; set; } // how powerful the engine is in kWh
        public bool DoesHaveAutoPilot { get; set; } // does the ship have automatic piloting feature
        public int CrewCount { get; set; } // how many people does it take to man the ship
        public int CargoWeight { get; set; } // how much cargo can the ship carry
        public bool DoesHaveLifeSupporySystems { get; set; } // does the ship have life support systems
        public DateTime BuiltDate { get; set; } // when the ship was built
        public DateTime LastMaintenenance { get; set; } // when was the ship last maintained at
        public int MaintenanceCount { get; set; } // how many maintenance sessions has been performed on the ship
        public int FullTripCount { get; set; } // how many voyages the ship has gone through
        public DateTime MaidenLaunch { get; set; } // when did the ship take it's first voyage
        public string Manufacturer { get; set; } //who manufactured the ship

        //Database info only, do not display to user

        public DateTime CreatedAt { get; set; } //when was the entry created into the database
        public DateTime ModifiedAt { get; set; } // when the entry was last modified at
    }
}
