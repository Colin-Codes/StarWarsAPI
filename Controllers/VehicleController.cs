using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

namespace star_wars_api.Controllers {
    public class VehicleController : APIController<Vehicle, VehicleJSONConverter> {

        public VehicleController(star_wars_apiContext _context) {
            context = _context;
            dbSet = context.Vehicle;
        }

    }

    public class VehicleJSONConverter : Vehicle, IStarWarsJSONConverter<Vehicle> {
        
        public new List<int> filmIds { get; set; }
        public new List<int> pilotIds { get; set; }

        public VehicleJSONConverter () {}

        public VehicleJSONConverter (Vehicle Vehicle) {
            this.id = Vehicle.id;
            this.created = Vehicle.created;
            this.edited = Vehicle.edited;
            this.vehicleClass = Vehicle.vehicleClass;
            this.cargoCapacity = Vehicle.cargoCapacity;
            this.consumables = Vehicle.consumables;
            this.costInCredits = Vehicle.costInCredits;
            this.crew = Vehicle.crew;
            this.length = Vehicle.length;
            this.manufacturer = Vehicle.manufacturer;
            this.model = Vehicle.model;
            this.name = Vehicle.name;
            this.passengers = Vehicle.passengers;
            this.filmIds = new List<int>();
            this.pilotIds = new List<int>();

            if (Vehicle.filmIds != null) {
                foreach (FilmVehicle film in Vehicle.filmIds) {
                    this.filmIds.Add(film.FilmId);
                }
            }

            if (Vehicle.pilotIds != null) {
                foreach (VehicleCharacter character in Vehicle.pilotIds) {
                    this.pilotIds.Add(character.characterId);
                }
            }

        }

        public Vehicle ToModel(star_wars_apiContext context) {
            Vehicle Vehicle = context.Vehicle.Find(this.id);
            
            bool newObject = false;
            if (Vehicle == null) {
                newObject = true;
                Vehicle = new Vehicle();
            }

            Vehicle.id = this.id;
            Vehicle.created = this.created;
            Vehicle.edited = this.edited;
            Vehicle.vehicleClass = this.vehicleClass;
            Vehicle.cargoCapacity = this.cargoCapacity;
            Vehicle.consumables = this.consumables;
            Vehicle.costInCredits = this.costInCredits;
            Vehicle.crew = this.crew;
            Vehicle.length = this.length;
            Vehicle.manufacturer = this.manufacturer;
            Vehicle.model = this.model;
            Vehicle.name = this.name;
            Vehicle.passengers = this.passengers;
            Vehicle.filmIds = new List<FilmVehicle>();
            Vehicle.pilotIds = new List<VehicleCharacter>();

            if (newObject == false) {
                // many-many mapping classes have the IDs as foreign keys - if the object does not yet exist it cannot be linked to other objects.
                foreach (int filmId in this.filmIds) {
                    if (context.Film.Find(filmId) != null) {
                        Vehicle.filmIds.Add(new FilmVehicle(filmId, this.id));
                    }
                }

                foreach (int characterId in this.pilotIds) {
                    if (context.Character.Find(characterId) != null) {
                        Vehicle.pilotIds.Add(new VehicleCharacter(this.id, characterId));
                    }
                }
            }
            return Vehicle;
        }
    }
}