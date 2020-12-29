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
    public class FilmController : APIController<Film, FilmJSONConverter> {

        public FilmController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Film;
        }
        
        public string List() {    
            List<ChallengeOutput> challengeOutputs = new List<ChallengeOutput>();
            List<Film> films = dbSet.Where(b => b.id != null).ToList();
            foreach (Film film in films) { 
                // Load character mapping objects           
                film.characterIds = context.FilmCharacter.Where(b => b.FilmId == film.id).ToList();

                challengeOutputs.Add(new ChallengeOutput(film, context));
            }
            return JsonSerializer.Serialize<List<ChallengeOutput>>(challengeOutputs);
        }

    }

    public class ChallengeOutput {
        // Defines the output format for the challenge
        public string filmName { get; set; }
        public List<String> filmCharacters { get; set; }

        public ChallengeOutput () {}

        public ChallengeOutput (Film film, star_wars_apiContext context) {
            this.filmName = film.title;
            filmCharacters = new List<string>();
            foreach (FilmCharacter filmCharacter in film.characterIds) {
                Character character = context.Character.Find(filmCharacter.CharacterId);
                filmCharacters.Add(character.name);
            }
        }

    }

    public class FilmJSONConverter : Film, IStarWarsJSONConverter<Film> {
        
        public new List<int> characterIds { get; set; }
        public new List<int> planetIds { get; set; }
        public new List<int> speciesIds { get; set; }
        public new List<int> starshipIds { get; set; }
        public new List<int> vehicleIds { get; set; }

        public FilmJSONConverter () {
            this.characterIds = new List<int>();
            this.planetIds = new List<int>();
            this.speciesIds = new List<int>();
            this.starshipIds = new List<int>();
            this.vehicleIds = new List<int>();
        }

        public FilmJSONConverter (Film film, star_wars_apiContext context) {
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

            List<FilmCharacter> filmCharacters = context.FilmCharacter.Where(b => b.FilmId == film.id).ToList();
            foreach (FilmCharacter character in filmCharacters) {
                this.characterIds.Add(character.CharacterId);
            }

            List<FilmPlanet> filmPlanets = context.FilmPlanet.Where(b => b.FilmId == film.id).ToList();
            foreach (FilmPlanet planet in filmPlanets) {
                this.planetIds.Add(planet.PlanetId);
            }

            List<FilmSpecies> filmSpecies = context.FilmSpecies.Where(b => b.FilmId == film.id).ToList();
            foreach (FilmSpecies species in filmSpecies) {
                this.speciesIds.Add(species.SpeciesId);
            }

            List<FilmStarship> filmStarship = context.FilmStarship.Where(b => b.FilmId == film.id).ToList();
            foreach (FilmStarship starship in filmStarship) {
                this.starshipIds.Add(starship.StarshipId);
            }

            List<FilmVehicle> filmVehicle = context.FilmVehicle.Where(b => b.FilmId == film.id).ToList();
            foreach (FilmVehicle vehicle in filmVehicle) {
                this.vehicleIds.Add(vehicle.VehicleId);
            }

        }

        public Film ToModel(star_wars_apiContext context) {
            Film film = context.Film.Find(this.id);
            
            bool newObject = false;
            if (film == null) {
                newObject = true;
                film = new Film();
                film.characterIds = new List<FilmCharacter>();
                film.planetIds = new List<FilmPlanet>();
                film.speciesIds = new List<FilmSpecies>();
                film.starshipIds = new List<FilmStarship>();
                film.vehicleIds = new List<FilmVehicle>();
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

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int characterId in this.characterIds) {
                    if (context.Character.Find(characterId) != null) {
                        FilmCharacter filmCharacter = context.FilmCharacter.Find(this.id, characterId);
                        if (filmCharacter == null) {
                            filmCharacter = new FilmCharacter(this.id, characterId);
                        }
                        if (film.characterIds.Contains(filmCharacter) == false) {
                            film.characterIds.Add(filmCharacter);
                        }
                    }
                }

                foreach (int planetId in this.planetIds) {
                    if (context.Planet.Find(planetId) != null) {
                        FilmPlanet filmPlanet = context.FilmPlanet.Find(this.id, planetId);
                        if (filmPlanet == null) {
                            filmPlanet = new FilmPlanet(this.id, planetId);
                        }
                        if (film.planetIds.Contains(filmPlanet) == false) {
                            film.planetIds.Add(filmPlanet);
                        }
                    }
                }

                foreach (int speciesId in this.speciesIds) {
                    if (context.Species.Find(speciesId) != null) {
                        FilmSpecies filmSpecies = context.FilmSpecies.Find(this.id, speciesId);
                        if (filmSpecies == null) {
                            filmSpecies = new FilmSpecies(this.id, speciesId);
                        }
                        if (film.speciesIds.Contains(filmSpecies) == false) {
                            film.speciesIds.Add(filmSpecies);
                        }
                    }
                }

                foreach (int starshipId in this.starshipIds) {
                    if (context.Starship.Find(starshipId) != null) {
                        FilmStarship filmStarship = context.FilmStarship.Find(this.id, starshipId);
                        if (filmStarship == null) {
                            filmStarship = new FilmStarship(this.id, starshipId);
                        } 
                        if (film.starshipIds.Contains(filmStarship) == false) {
                            film.starshipIds.Add(filmStarship);
                        }
                    }
                }

                foreach (int vehicleId in this.vehicleIds) {
                    if (context.Vehicle.Find(vehicleId) != null) {
                        FilmVehicle filmVehicle = context.FilmVehicle.Find(this.id, vehicleId);
                        if (filmVehicle == null) {
                            filmVehicle = new FilmVehicle(this.id, vehicleId);
                        } 
                        if (film.vehicleIds.Contains(filmVehicle) == false) {
                            film.vehicleIds.Add(filmVehicle);
                        }
                    }
                }
            }
            return film;
        }
    }
}