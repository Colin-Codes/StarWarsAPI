using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

namespace star_wars_api.Controllers {
    public class FilmController : APIController<Film, FilmJSONConverter> {

        public FilmController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Film;
        }

    }

    public class FilmJSONConverter : Film, IStarWarsJSONConverter<Film> {
        
        public new List<int> characterIds { get; set; }
        public new List<int> planetIds { get; set; }
        public new List<int> speciesIds { get; set; }
        public new List<int> starshipIds { get; set; }
        public new List<int> vehicleIds { get; set; }

        public FilmJSONConverter () {}

        public FilmJSONConverter (Film film) {
            this.id = film.id;
            this.created = film.created;
            this.edited = film.edited;
            this.director = film.director;
            this.episodeId = film.episodeId;
            this.openingCrawl = film.openingCrawl;
            this.producer = film.producer;
            this.releaseDate = film.releaseDate;
            this.title = film.title;
            this.characterIds = new List<int>();
            this.planetIds = new List<int>();
            this.speciesIds = new List<int>();
            this.starshipIds = new List<int>();
            this.vehicleIds = new List<int>();

            if (film.characterIds != null) {
                foreach (FilmCharacter character in film.characterIds) {
                    this.characterIds.Add(character.CharacterId);
                }
            }

            if (film.planetIds != null) {
                foreach (FilmPlanet planet in film.planetIds) {
                    this.planetIds.Add(planet.PlanetId);
                }
            }

            if (film.speciesIds != null) {
                foreach (FilmSpecies species in film.speciesIds) {
                    this.speciesIds.Add(species.SpeciesId);
                }
            }

            if (film.starshipIds != null) {
                foreach (FilmStarship starship in film.starshipIds) {
                    this.starshipIds.Add(starship.StarshipId);
                }
            }

            if (film.vehicleIds != null) {
                foreach (FilmVehicle vehicle in film.vehicleIds) {
                    this.vehicleIds.Add(vehicle.VehicleId);
                }
            }

        }

        public Film ToModel(star_wars_apiContext context) {
            Film film = context.Film.Find(this.id);
            
            bool newObject = false;
            if (film == null) {
                newObject = true;
                film = new Film();
            }

            film.id = this.id;
            film.created = this.created;
            film.edited = this.edited;
            film.director = this.director;
            film.episodeId = this.episodeId;
            film.openingCrawl = this.openingCrawl;
            film.producer = this.producer;
            film.releaseDate = this.releaseDate;
            film.title = this.title;
            film.characterIds = new List<FilmCharacter>();
            film.planetIds = new List<FilmPlanet>();
            film.speciesIds = new List<FilmSpecies>();
            film.starshipIds = new List<FilmStarship>();
            film.vehicleIds = new List<FilmVehicle>();

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int characterId in this.characterIds) {
                    if (context.Character.Find(characterId) != null) {
                        film.characterIds.Add(new FilmCharacter(this.id, characterId));
                    }
                }

                foreach (int planetId in this.planetIds) {
                    if (context.Planet.Find(planetId) != null) {
                        film.planetIds.Add(new FilmPlanet(this.id, planetId));
                    }
                }

                foreach (int speciesId in this.speciesIds) {
                    if (context.Species.Find(speciesId) != null) {
                        film.speciesIds.Add(new FilmSpecies(this.id, speciesId));
                    }
                }

                foreach (int starshipId in this.starshipIds) {
                    if (context.Starship.Find(starshipId) != null) {
                        film.starshipIds.Add(new FilmStarship(this.id, starshipId));
                    }
                }

                foreach (int vehicleId in this.vehicleIds) {
                    if (context.Vehicle.Find(vehicleId) != null) {
                        film.vehicleIds.Add(new FilmVehicle(this.id, vehicleId));
                    }
                }
            }
            return film;
        }
    }
}