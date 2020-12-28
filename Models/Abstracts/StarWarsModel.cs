using System;

namespace star_wars_api.Models
{
    public abstract class StarWarsModel : IStarWarsModel {
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public int id { get; set; }
        
    }
}