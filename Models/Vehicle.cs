using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace star_wars_api.Models {
    public class Vehicle : Transport {
        public string vehicleClass { get; set; }
        public List<VehicleCharacter> pilotIds { get; set; } 
        public List<FilmVehicle> filmIds { get; set; }
    }

    public class VehicleCharacter {
        [Column(Order = 0), Key, ForeignKey("Vehicle")]
        public int vehicleId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Character")]
        public int characterId { get; set; }
        
        public VehicleCharacter () {}

        public VehicleCharacter (int _VehicleId, int _CharacterId) {
            vehicleId = _VehicleId;
            characterId = _CharacterId;
        }
    }
}