using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

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

        public CharacterJSONConverter () {}

        public CharacterJSONConverter(Character character) {
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

            if (character.filmIds != null) {
                foreach (FilmCharacter film in character.filmIds) {
                    this.filmIds.Add(film.FilmId);
                }
            }

            if (character.speciesIds != null) {
                foreach (SpeciesCharacter species in character.speciesIds) {
                    this.speciesIds.Add(species.speciesId);
                }
            }

            if (character.vehicleIds != null) {
                foreach (VehicleCharacter vehicle in character.vehicleIds) {
                    this.vehicleIds.Add(vehicle.vehicleId);
                }
            }

            if (character.starshipIds != null) {
                foreach (StarshipCharacter starship in character.starshipIds) {
                    this.starshipIds.Add(starship.starshipId);
                }
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
            character.created = this.created;
            character.edited = this.edited;
            character.name = this.name;
            character.height = this.height;
            character.hairColor = this.hairColor;
            character.eyeColor = this.eyeColor;
            character.birthYear = this.birthYear;
            character.gender = this.gender;
            character.homeworldId = this.homeworldId;
            character.filmIds = new List<FilmCharacter>();
            character.speciesIds = new List<SpeciesCharacter>();
            character.vehicleIds = new List<VehicleCharacter>();
            character.starshipIds = new List<StarshipCharacter>();

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int filmId in this.filmIds) {
                    if (context.Film.Find(filmId) != null) {
                        character.filmIds.Add(new FilmCharacter(filmId, this.id));
                    }
                }

                foreach (int speciesId in this.speciesIds) {
                    if (context.Species.Find(speciesId) != null) {
                        character.speciesIds.Add(new SpeciesCharacter(speciesId, this.id));
                    }
                }

                foreach (int vehicleId in this.vehicleIds) {
                    if (context.Vehicle.Find(vehicleId) != null) {
                        character.vehicleIds.Add(new VehicleCharacter(vehicleId, this.id));
                    }
                }

                foreach (int starshipId in this.starshipIds) {
                    if (context.Starship.Find(starshipId) != null) {
                        character.starshipIds.Add(new StarshipCharacter(starshipId, this.id));
                    }
                }
            }
            return character;
        }
    }
}