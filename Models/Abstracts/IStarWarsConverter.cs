using System;
using star_wars_api.Data;

namespace star_wars_api.Models
{
    public interface IStarWarsJSONConverter<Model>
    {
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public int id { get; set; }
        public Model ToModel(star_wars_apiContext context);      
    }
}