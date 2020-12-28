using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

namespace star_wars_api.Controllers {
    public abstract class APIController<T> : Controller where T : class, IStarWarsModel {

        public star_wars_apiContext _context { get; set; }
        public DbSet<T> _dbSet { get; set; }

        public APIController() {}
        
        [HttpPost]
        public string Create() {    
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                List<T> models = JsonSerializer.Deserialize<List<T>>(reader.ReadToEnd());
                string names = "";
                foreach (T model in models) {
                    _dbSet.Add(model);
                    names += model.id + ", ";
                }                
                _context.SaveChanges();
                return names.Substring(0, names.Length - 2) + " created";
            }       
        }
        
        public string Retrieve(int? id) {
            T model = _dbSet.Find(id);
            return model.id + " found";
        }
        
        public string Retrieve(int? pageSize = 0, int? pageIndex = 0) {
            // Film film = _context.Film.Find(id);
            return "all films found";
        }

        [HttpPost]
        public string Update() {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                List<T> models = JsonSerializer.Deserialize<List<T>>(reader.ReadToEnd());
                string names = "";
                foreach (T model in models) {
                    _dbSet.Update(model);
                    names += model.id + ", ";
                }                
                _context.SaveChanges();
                return names.Substring(0, names.Length - 2) + " updated";
            }   
        }

        public string Delete(int id) {
            T model = _dbSet.Find(id);
            _dbSet.Remove(model);
            _context.SaveChanges();            
            return model.id + " removed";
        }


    }
}