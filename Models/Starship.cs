using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace star_wars_api.Models {
    public class Starship : Transport {
        public string mglt { get; set; }
        public double hyperdriveRating { get; set; }
        public string starshipClass { get; set; }    
        public List<StarshipCharacter> pilotIds { get; set; } 
    }

    public class StarshipCharacter {
        [Column(Order = 0), Key, ForeignKey("Starship")]
        public int starshipId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Character")]
        public int characterId { get; set; }
        
        public StarshipCharacter () {}

        public StarshipCharacter (int _StarshipId, int _CharacterId) {
            starshipId = _StarshipId;
            characterId = _CharacterId;
        }
    }
}