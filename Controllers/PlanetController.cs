using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

namespace star_wars_api.Controllers {
    public class PlanetController : APIController<Planet, PlanetJSONConverter> {

        public PlanetController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Planet;
        }

    }

    public class PlanetJSONConverter : Planet, IStarWarsJSONConverter<Planet> {
        
        public new List<int> filmIds { get; set; }
        public new List<int> residentIds { get; set; }

        public PlanetJSONConverter () {}

        public PlanetJSONConverter (Planet planet) {
            this.id = planet.id;
            this.created = planet.created;
            this.edited = planet.edited;
            this.climate = planet.climate;
            this.diameter = planet.diameter;
            this.gravity = planet.gravity;
            this.name = planet.name;
            this.orbitalPeriod = planet.orbitalPeriod;
            this.population = planet.population;
            this.rotationPeriod = planet.rotationPeriod;
            this.surfaceWater = planet.surfaceWater;
            this.population = planet.population;
            this.terrain = planet.terrain;
            this.filmIds = new List<int>();
            this.residentIds = new List<int>();

            if (planet.filmIds != null) {
                foreach (FilmPlanet film in planet.filmIds) {
                    this.filmIds.Add(film.FilmId);
                }
            }

            if (planet.residentIds != null) {
                foreach (PlanetCharacter character in planet.residentIds) {
                    this.residentIds.Add(character.characterId);
                }
            }

        }

        public Planet ToModel(star_wars_apiContext context) {
            Planet planet = context.Planet.Find(this.id);
            
            bool newObject = false;
            if (planet == null) {
                newObject = true;
                planet = new Planet();
            }

            planet.id = this.id;
            planet.created = this.created;
            planet.edited = this.edited;
            planet.climate = this.climate;
            planet.diameter = this.diameter;
            planet.gravity = this.gravity;
            planet.name = this.name;
            planet.orbitalPeriod = this.orbitalPeriod;
            planet.population = this.population;
            planet.rotationPeriod = this.rotationPeriod;
            planet.surfaceWater = this.surfaceWater;
            planet.population = this.population;
            planet.terrain = this.terrain;
            planet.filmIds = new List<FilmPlanet>();
            planet.residentIds = new List<PlanetCharacter>();

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int filmId in this.filmIds) {
                    if (context.Film.Find(filmId) != null) {
                        planet.filmIds.Add(new FilmPlanet(filmId, this.id));
                    }
                }

                foreach (int characterId in this.residentIds) {
                    if (context.Character.Find(characterId) != null) {
                        planet.residentIds.Add(new PlanetCharacter(this.id, characterId));
                    }
                }
            }
            return planet;
        }
    }
}