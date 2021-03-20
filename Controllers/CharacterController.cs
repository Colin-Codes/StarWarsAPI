using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using star_wars_api.Models.EntityModels;

namespace star_wars_api.Controllers {
    public class CharacterController : APIController<Character, CharacterJSONConverter> {

        public CharacterController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Character;
        }

    }

    public class CharacterJSONConverter : Character, IStarWarsJSONConverter<Character> {
        
        public new List<int> filmIds { get; set; }
        public new List<int> speciesIds { get; set; }
        public new List<int> vehicleIds { get; set; }
        public new List<int> starshipIds { get; set; }

        public CharacterJSONConverter () {
            this.filmIds = new List<int>();
            this.speciesIds = new List<int>();
            this.vehicleIds = new List<int>();
            this.starshipIds = new List<int>();
        }

        public CharacterJSONConverter(Character character, star_wars_apiContext context) {
            this.id = character.id;
            this.created = character.created;
            this.edited = character.edited;
            this.name = character.name;
            this.height = character.height;
            this.mass = character.mass;
            this.hairColor = character.hairColor;
            this.eyeColor = character.eyeColor;
            this.birthYear = character.birthYear;
            this.gender = character.gender;
            this.homeworldId = character.homeworldId;
            this.filmIds = new List<int>();
            this.speciesIds = new List<int>();
            this.vehicleIds = new List<int>();
            this.starshipIds = new List<int>();

            List<FilmCharacter> filmCharacters = context.FilmCharacter.Where(b => b.CharacterId == character.id).ToList();
            foreach (FilmCharacter film in filmCharacters) {
                this.filmIds.Add(film.FilmId);
            }

            List<SpeciesCharacter> speciesCharacters = context.SpeciesCharacter.Where(b => b.characterId == character.id).ToList();
            foreach (SpeciesCharacter species in speciesCharacters) {
                this.speciesIds.Add(species.speciesId);
            }

            List<VehicleCharacter> vehicleCharacters = context.VehicleCharacter.Where(b => b.characterId == character.id).ToList();
            foreach (VehicleCharacter vehicle in vehicleCharacters) {
                this.vehicleIds.Add(vehicle.vehicleId);
            }

            List<StarshipCharacter> starshipCharacters = context.StarshipCharacter.Where(b => b.characterId == character.id).ToList();
            foreach (StarshipCharacter starship in starshipCharacters) {
                this.starshipIds.Add(starship.starshipId);
            }

        }

        public Character ToModel(star_wars_apiContext context) {
            Character character = context.Character.Find(this.id);
            
            bool newObject = false;
            if (character == null) {
                newObject = true;
                character = new Character();
            }

            character.id = this.id;
            if (newObject == true) {
                character.created = DateTime.Now;
            } else {
                character.created = this.created;
            }
            character.edited = DateTime.Now;
            if (this.name == null) {
                throw new ArgumentException("The character name is mandatory");
            } else {
                character.name = this.name;
            }
            character.height = this.height;
            character.hairColor = this.hairColor;
            character.eyeColor = this.eyeColor;
            character.birthYear = this.birthYear;
            character.gender = this.gender;
            character.homeworldId = this.homeworldId;
            character.filmIds = new List<FilmCharacter>(); //Mandatory - at least one
            character.speciesIds = new List<SpeciesCharacter>(); //Mandatory - one only
            character.vehicleIds = new List<VehicleCharacter>();
            character.starshipIds = new List<StarshipCharacter>();
            if (this.filmIds.Count <=1) {
                throw new ArgumentException("The character must be linked to at least one film");
            }
            if (this.speciesIds.Count !=1) {
                throw new ArgumentException("The character must be linked to one and only one species");
            }

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int filmId in this.filmIds) {
                    if (context.Film.Find(filmId) != null) {
                        FilmCharacter filmCharacter = context.FilmCharacter.Find(filmId, this.id);
                        if (filmCharacter == null) {
                            character.filmIds.Add(new FilmCharacter(filmId, this.id));
                        } else {
                            character.filmIds.Add(filmCharacter);
                        }                        
                    }
                }

                foreach (int speciesId in this.speciesIds) {
                    if (context.Species.Find(speciesId) != null) {
                        SpeciesCharacter speciesCharacter = context.SpeciesCharacter.Find(speciesId, this.id);
                        if (speciesCharacter == null) {
                            character.speciesIds.Add(new SpeciesCharacter(speciesId, this.id));
                        } else {
                            character.speciesIds.Add(speciesCharacter);
                        }    
                    }
                }

                foreach (int vehicleId in this.vehicleIds) {
                    if (context.Vehicle.Find(vehicleId) != null) {
                        VehicleCharacter vehicleCharacter = context.VehicleCharacter.Find(vehicleId, this.id);
                        if (vehicleCharacter == null) {
                            character.vehicleIds.Add(new VehicleCharacter(vehicleId, this.id));
                        } else {
                            character.vehicleIds.Add(vehicleCharacter);
                        }  
                    }
                }

                foreach (int starshipId in this.starshipIds) {
                    if (context.Starship.Find(starshipId) != null) {
                        StarshipCharacter starshipCharacter = context.StarshipCharacter.Find(starshipId, this.id);
                        if (starshipCharacter == null) {
                            character.starshipIds.Add(new StarshipCharacter(starshipId, this.id));
                        } else {
                            character.starshipIds.Add(starshipCharacter);
                        }  
                    }
                }
            }
            return character;
        }
    }
}