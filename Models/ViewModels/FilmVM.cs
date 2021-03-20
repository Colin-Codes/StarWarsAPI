using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace star_wars_api.Models {
    public class FilmVM : StarWarsModel {
        public string director { get; set; }
        public int episodeId { get; set; }
        public string openingCrawl { get; set; }
        public string producer { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; } 
        public List<FilmCharacter> characterIds { get; set; }
        public List<FilmSpecies> speciesIds { get; set; }
        public List<FilmPlanet> planetIds { get; set; }
        public List<FilmVehicle> vehicleIds { get; set; }
        public List<FilmStarship> starshipIds { get; set; }
    }
}