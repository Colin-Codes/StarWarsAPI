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

        public SpeciesJSONConverter () {
            this.filmIds = new List<int>();
            this.peopleIds = new List<int>();
            this.eyeColors = new List<string>();
            this.hairColors = new List<string>();
            this.skinColors = new List<string>();
        }

        public SpeciesJSONConverter (Species species, star_wars_apiContext context) {
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

            List<FilmSpecies> filmSpecies = context.FilmSpecies.Where(b => b.SpeciesId == species.id).ToList();
            foreach (FilmSpecies film in filmSpecies) {
                this.filmIds.Add(film.FilmId);
            }

            List<SpeciesCharacter> speciesCharacters = context.SpeciesCharacter.Where(b => b.speciesId == species.id).ToList();
            foreach (SpeciesCharacter character in speciesCharacters) {
                this.peopleIds.Add(character.characterId);
            }

            List<SpeciesEyeColor> speciesEyeColors = context.SpeciesEyeColor.Where(b => b.speciesId == species.id).ToList();
            foreach (SpeciesEyeColor eyeColor in speciesEyeColors) {
                this.eyeColors.Add(eyeColor.eyeColor);
            }

            List<SpeciesHairColor> speciesHairColors = context.SpeciesHairColor.Where(b => b.speciesId == species.id).ToList();
            foreach (SpeciesHairColor hairColor in speciesHairColors) {
                this.hairColors.Add(hairColor.hairColor);
            }

            List<SpeciesSkinColor> speciesSkinColors = context.SpeciesSkinColor.Where(b => b.speciesId == species.id).ToList();
            foreach (SpeciesSkinColor skinColor in speciesSkinColors) {
                this.skinColors.Add(skinColor.skinColor);
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
                        FilmSpecies filmSpecies = context.FilmSpecies.Find(filmId, this.id);
                        if (filmSpecies == null) {
                            species.filmIds.Add(new FilmSpecies(filmId, this.id));
                        } else {
                            species.filmIds.Add(filmSpecies);
                        }  
                    }
                }

                foreach (int characterId in this.peopleIds) {
                    if (context.Character.Find(characterId) != null) {
                        SpeciesCharacter speciesCharacter = context.SpeciesCharacter.Find(this.id, characterId);
                        if (speciesCharacter == null) {
                            species.peopleIds.Add(new SpeciesCharacter(this.id, characterId));
                        } else {
                            species.peopleIds.Add(speciesCharacter);
                        }  
                    }
                }

                foreach (string eyeColor in this.eyeColors) {
                    SpeciesEyeColor speciesEyeColor = context.SpeciesEyeColor.Find(this.id, eyeColor);
                    if (speciesEyeColor == null) {
                        species.eyeColors.Add(new SpeciesEyeColor(this.id, eyeColor));
                    } else {
                        species.eyeColors.Add(speciesEyeColor);
                    }  
                }

                foreach (string hairColor in this.hairColors) {
                    SpeciesHairColor speciesHairColor = context.SpeciesHairColor.Find(this.id, hairColor);
                    if (speciesHairColor == null) {
                        species.hairColors.Add(new SpeciesHairColor(this.id, hairColor));
                    } else {
                        species.hairColors.Add(speciesHairColor);
                    }  
                }

                foreach (string skinColor in this.skinColors) {
                    SpeciesSkinColor speciesSkinColor = context.SpeciesSkinColor.Find(this.id, skinColor);
                    if (speciesSkinColor == null) {
                        species.skinColors.Add(new SpeciesSkinColor(this.id, skinColor));
                    } else {
                        species.skinColors.Add(speciesSkinColor);
                    }  
                }
            }
            return species;
        }
    }
}