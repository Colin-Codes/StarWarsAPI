using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace star_wars_api.Models {
    public class Film : StarWarsModel {
        public List<FilmCharacter> characterIds { get; set; }
        public string director { get; set; }
        public int episodeId { get; set; }
        public string openingCrawl { get; set; }
        public List<FilmPlanet> planetIds { get; set; }
        public string producer { get; set; }
        public DateTime releaseDate { get; set; } 
        public List<FilmSpecies> speciesIds { get; set; }
        public List<FilmStarship> starshipIds { get; set; }
        public string title { get; set; }
        public List<FilmVehicle> vehicleIds { get; set; }
        
    }

    public class FilmCharacter {
        [Column(Order = 0), Key, ForeignKey("Film")]
        public int FilmId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Character")]
        public int CharacterId { get; set; }

    }

    public class FilmPlanet {
        [Column(Order = 0), Key, ForeignKey("Film")]
        public int FilmId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Planet")]
        public int PlanetId { get; set; }

    }

    public class FilmSpecies {
        [Column(Order = 0), Key, ForeignKey("Film")]
        public int FilmId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Species")]
        public int SpeciesId { get; set; }

    }

    public class FilmStarship {
        [Column(Order = 0), Key, ForeignKey("Film")]
        public int FilmId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Starship")]
        public int StarshipId { get; set; }

    }

    public class FilmVehicle {
        [Column(Order = 0), Key, ForeignKey("Film")]
        public int FilmId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

    }
}