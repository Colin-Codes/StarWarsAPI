using System;
using System.Collections.Generic;

namespace star_wars_api.Models {
    public abstract class Transport : StarWarsModel {
        public int cargoCapacity { get; set; }
        public string consumables { get; set; }
        public int costInCredits { get; set; }        
        public string crew { get; set; }
        public string length { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public int passengers { get; set; }
        public List<FilmVehicle> filmIds { get; set; }
    }
}