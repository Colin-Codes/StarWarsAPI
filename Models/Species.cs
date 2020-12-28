using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace star_wars_api.Models {
    public class Species : StarWarsModel {
        public double averageHeight { get; set; }
        public int averageLifespan { get; set; }
        public string classification { get; set; }
        public string designation { get; set; }
        public List<SpeciesEyeColor> eyeColors { get; set; }
        public List<SpeciesHairColor> hairColors { get; set; }
        public int homeworldId { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public List<SpeciesCharacter> peopleIds { get; set; }
        public List<FilmSpecies> filmIds { get; set; }
        public List<SpeciesSkinColor> skinColors { get; set; }        
    }

    public class SpeciesEyeColor {
        [Column(Order = 0), Key, ForeignKey("Species")]
        public int speciesId { get; set; }

        public string eyeColor { get; set; }
    }

    public class SpeciesHairColor {
        [Column(Order = 0), Key, ForeignKey("Species")]
        public int speciesId { get; set; }

        public string hairColor { get; set; }
    }

    public class SpeciesSkinColor {
        [Column(Order = 0), Key, ForeignKey("Species")]
        public int speciesId { get; set; }

        public string skinColor { get; set; }
    }

    public class SpeciesCharacter {
        [Column(Order = 0), Key, ForeignKey("Species")]
        public int speciesId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Character")]
        public int characterId { get; set; }
    }
}