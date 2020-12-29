using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace star_wars_api.Controllers {
    public class StarshipController : APIController<Starship, StarshipJSONConverter> {

        public StarshipController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Starship;
        }

    }

    public class StarshipJSONConverter : Starship, IStarWarsJSONConverter<Starship> {
        
        public new List<int> filmIds { get; set; }
        public new List<int> pilotIds { get; set; }

        public StarshipJSONConverter () {
            this.filmIds = new List<int>();
            this.pilotIds = new List<int>();
        }

        public StarshipJSONConverter (Starship starship, star_wars_apiContext context) {
            this.id = starship.id;
            this.created = starship.created;
            this.edited = starship.edited;
            this.mglt = starship.mglt;
            this.hyperdriveRating = starship.hyperdriveRating;
            this.starshipClass = starship.starshipClass;
            this.cargoCapacity = starship.cargoCapacity;
            this.consumables = starship.consumables;
            this.costInCredits = starship.costInCredits;
            this.crew = starship.crew;
            this.length = starship.length;
            this.manufacturer = starship.manufacturer;
            this.model = starship.model;
            this.name = starship.name;
            this.passengers = starship.passengers;
            this.filmIds = new List<int>();
            this.pilotIds = new List<int>();

            List<FilmStarship> filmStarships = context.FilmStarship.Where(b => b.StarshipId == starship.id).ToList();
            foreach (FilmStarship film in filmStarships) {
                this.filmIds.Add(film.FilmId);
            }

            List<StarshipCharacter> starshipCharacters = context.StarshipCharacter.Where(b => b.starshipId == starship.id).ToList();
            foreach (StarshipCharacter character in starshipCharacters) {
                this.pilotIds.Add(character.characterId);
            }

        }

        public Starship ToModel(star_wars_apiContext context) {
            Starship starship = context.Starship.Find(this.id);
            
            bool newObject = false;
            if (starship == null) {
                newObject = true;
                starship = new Starship();
            }

            starship.id = this.id;
            starship.created = this.created;
            starship.edited = this.edited;
            starship.mglt = this.mglt;
            starship.hyperdriveRating = this.hyperdriveRating;
            starship.starshipClass = this.starshipClass;
            starship.cargoCapacity = this.cargoCapacity;
            starship.consumables = this.consumables;
            starship.costInCredits = this.costInCredits;
            starship.crew = this.crew;
            starship.length = this.length;
            starship.manufacturer = this.manufacturer;
            starship.model = this.model;
            starship.name = this.name;
            starship.passengers = this.passengers;
            starship.filmIds = new List<FilmStarship>();
            starship.pilotIds = new List<StarshipCharacter>();

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int filmId in this.filmIds) {
                    if (context.Film.Find(filmId) != null) {
                        FilmStarship filmStarship = context.FilmStarship.Find(filmId, this.id);
                        if (filmStarship == null) {
                            starship.filmIds.Add(new FilmStarship(filmId, this.id));
                        } else {
                            starship.filmIds.Add(filmStarship);
                        }  
                    }
                }

                foreach (int characterId in this.pilotIds) {
                    if (context.Character.Find(characterId) != null) {
                        StarshipCharacter starshipCharacter = context.StarshipCharacter.Find(this.id, characterId);
                        if (starshipCharacter == null) {
                            starship.pilotIds.Add(new StarshipCharacter(this.id, characterId));
                        } else {
                            starship.pilotIds.Add(starshipCharacter);
                        }  
                    }
                }
            }
            return starship;
        }
    }
}