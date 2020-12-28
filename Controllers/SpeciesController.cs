using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

namespace star_wars_api.Controllers {
    public class SpeciesController : APIController<Species, SpeciesJSONConverter> {

        public SpeciesController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Species;
        }

    }

    public class SpeciesJSONConverter : Species, IStarWarsJSONConverter<Species> {
        
        public new List<int> filmIds { get; set; }
        public new List<int> peopleIds { get; set; }
        public new List<string> eyeColors { get; set; }
        public new List<string> hairColors { get; set; }
        public new List<string> skinColors { get; set; }

        public SpeciesJSONConverter () {}

        public SpeciesJSONConverter (Species species) {
            this.id = species.id;
            this.created = species.created;
            this.edited = species.edited;
            this.averageHeight = species.averageHeight;
            this.averageLifespan = species.averageLifespan;
            this.classification = species.classification;
            this.designation = species.designation;
            this.homeworldId = species.homeworldId;
            this.language = species.language;
            this.name = species.name;
            this.filmIds = new List<int>();
            this.peopleIds = new List<int>();
            this.eyeColors = new List<string>();
            this.hairColors = new List<string>();
            this.skinColors = new List<string>();

            if (species.filmIds != null) {
                foreach (FilmSpecies film in species.filmIds) {
                    this.filmIds.Add(film.FilmId);
                }
            }

            if (species.peopleIds != null) {
                foreach (SpeciesCharacter character in species.peopleIds) {
                    this.peopleIds.Add(character.characterId);
                }
            }

            if (species.eyeColors != null) {
                foreach (SpeciesEyeColor eyeColor in species.eyeColors) {
                    this.eyeColors.Add(eyeColor.eyeColor);
                }
            }

            if (species.hairColors != null) {
                foreach (SpeciesHairColor hairColor in species.hairColors) {
                    this.hairColors.Add(hairColor.hairColor);
                }
            }

            if (species.skinColors != null) {
                foreach (SpeciesSkinColor skinColor in species.skinColors) {
                    this.skinColors.Add(skinColor.skinColor);
                }
            }

        }

        public Species ToModel(star_wars_apiContext context) {
            Species species = context.Species.Find(this.id);
            
            bool newObject = false;
            if (species == null) {
                newObject = true;
                species = new Species();
            }

            species.id = this.id;
            species.created = this.created;
            species.edited = this.edited;
            species.averageHeight = this.averageHeight;
            species.averageLifespan = this.averageLifespan;
            species.classification = this.classification;
            species.designation = this.designation;
            species.homeworldId = this.homeworldId;
            species.language = this.language;
            species.name = this.name;
            species.filmIds = new List<FilmSpecies>();
            species.peopleIds = new List<SpeciesCharacter>();
            species.eyeColors = new List<SpeciesEyeColor>();
            species.hairColors = new List<SpeciesHairColor>();
            species.skinColors = new List<SpeciesSkinColor>();

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int filmId in this.filmIds) {
                    if (context.Film.Find(filmId) != null) {
                        species.filmIds.Add(new FilmSpecies(filmId, this.id));
                    }
                }

                foreach (int characterId in this.peopleIds) {
                    if (context.Character.Find(characterId) != null) {
                        species.peopleIds.Add(new SpeciesCharacter(this.id, characterId));
                    }
                }

                foreach (string eyeColor in this.eyeColors) {
                    species.eyeColors.Add(new SpeciesEyeColor(this.id, eyeColor));
                }

                foreach (string hairColor in this.hairColors) {
                    species.hairColors.Add(new SpeciesHairColor(this.id, hairColor));
                }

                foreach (string skinColor in this.skinColors) {
                    species.skinColors.Add(new SpeciesSkinColor(this.id, skinColor));
                }
            }
            return species;
        }
    }
}