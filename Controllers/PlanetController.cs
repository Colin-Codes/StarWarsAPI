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
    public class PlanetController : APIController<Planet, PlanetJSONConverter> {

        public PlanetController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Planet;
        }

    }

    public class PlanetJSONConverter : Planet, IStarWarsJSONConverter<Planet> {
        
        public new List<int> filmIds { get; set; }
        public new List<int> residentIds { get; set; }

        public PlanetJSONConverter () {
            this.filmIds = new List<int>();
            this.residentIds = new List<int>();
        }

        public PlanetJSONConverter (Planet planet, star_wars_apiContext context) {
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

            List<FilmPlanet> filmPlanets = context.FilmPlanet.Where(b => b.PlanetId == planet.id).ToList();
                foreach (FilmPlanet film in filmPlanets) {
                this.filmIds.Add(film.FilmId);
            }
            List<PlanetCharacter> planetCharacters = context.PlanetCharacter.Where(b => b.planetId == planet.id).ToList();
            foreach (PlanetCharacter character in planetCharacters) {
                this.residentIds.Add(character.characterId);
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
                        FilmPlanet filmPlanet = context.FilmPlanet.Find(filmId, this.id);
                        if (filmPlanet == null) {
                            planet.filmIds.Add(new FilmPlanet(filmId, this.id));
                        } else {
                            planet.filmIds.Add(filmPlanet);
                        }  
                    }
                }

                foreach (int characterId in this.residentIds) {
                    if (context.Character.Find(characterId) != null) {
                        PlanetCharacter planetCharacter = context.PlanetCharacter.Find(this.id, characterId);
                        if (planetCharacter == null) {
                            planet.residentIds.Add(new PlanetCharacter(this.id, characterId));
                        } else {
                            planet.residentIds.Add(planetCharacter);
                        }  
                    }
                }
            }
            return planet;
        }
    }
}