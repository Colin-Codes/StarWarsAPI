using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace star_wars_api.Models {
    public class Planet : StarWarsModel {
        public string climate { get; set; }
        public int diameter { get; set; }
        public List<FilmPlanet> filmIds { get; set; }
        public string gravity { get; set; }
        public string name { get; set; }
        public int orbitalPeriod { get; set; }
        public int population { get; set; }
        public List<PlanetCharacter> residentIds { get; set; }
        public string rotationPeriod { get; set; }
        public string surfaceWater { get; set; }
        public string terrain { get; set; }
    }

    public class PlanetCharacter {
        [Column(Order = 0), Key, ForeignKey("Planet")]
        public int planetId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Character")]
        public int characterId { get; set; }
        
        public PlanetCharacter () {}

        public PlanetCharacter (int _PlanetId, int _CharacterId) {
            planetId = _PlanetId;
            characterId = _CharacterId;
        }
    }
}