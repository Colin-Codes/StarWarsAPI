using System;
using System.Collections.Generic;

namespace star_wars_api.Models
{
    public class Character : StarWarsModel {
        public string name { get; set; }
        public int? height { get; set; }
        public int? mass { get; set; }
        public string hairColor { get; set; }
        public string eyeColor { get; set; }
        public string birthYear { get; set; }
        public string gender { get; set; }
        public int homeworldId { get; set; }
        public List<FilmCharacter> filmIds { get; set; }
        public List<SpeciesCharacter> speciesIds { get; set; }
        public List<VehicleCharacter> vehicleIds { get; set; }
        public List<StarshipCharacter> starshipIds { get; set; }
        
    }
}