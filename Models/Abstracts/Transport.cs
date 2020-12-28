using System;
using System.Collections.Generic;

namespace star_wars_api.Models {
    public abstract class Transport : StarWarsModel {
        public long? cargoCapacity { get; set; }
        public string consumables { get; set; }
        public long? costInCredits { get; set; }        
        public int? crew { get; set; }
        public int? length { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public int? passengers { get; set; }
    }
}