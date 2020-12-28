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
    public abstract class APIController<Model, JsonConverter> : Controller where Model : class, IStarWarsModel where JsonConverter: class, IStarWarsJSONConverter<Model>{

        public star_wars_apiContext context { get; set; }
        public DbSet<Model> dbSet { get; set; }

        T GetJSON < T > (params object[] lstArgument)  
        {  
            return (T) Activator.CreateInstance(typeof (T), lstArgument);  
        } 
                
        [HttpPost]
        public string Create() {    
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                List<JsonConverter> JSONinputs = JsonSerializer.Deserialize<List<JsonConverter>>(reader.ReadToEnd());
                List<JsonConverter> JSONoutputs = new List<JsonConverter>();
                foreach (JsonConverter json in JSONinputs) {
                    dbSet.Add(json.ToModel(context));
                    JSONoutputs.Add(GetJSON<JsonConverter>(dbSet.Find(json.id)));
                }                
                context.SaveChanges();
                return JsonSerializer.Serialize<List<JsonConverter>>(JSONoutputs);
            }       
        }
        
        public string Retrieve(int? id) {
            Model model = dbSet.Find(id);
            return model.id + " found";
        }
        
        public string Retrieve(int? pageSize = 0, int? pageIndex = 0) {
            // Film film = _context.Film.Find(id);
            return "all films found";
        }

        [HttpPost]
        public string Update() {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                List<JsonConverter> JSONinputs = JsonSerializer.Deserialize<List<JsonConverter>>(reader.ReadToEnd());
                List<JsonConverter> JSONoutputs = new List<JsonConverter>();
                foreach (JsonConverter json in JSONinputs) {
                    dbSet.Update(json.ToModel(context));
                    JSONoutputs.Add(GetJSON<JsonConverter>(dbSet.Find(json.id)));
                }                
                context.SaveChanges();
                return JsonSerializer.Serialize<List<JsonConverter>>(JSONoutputs);
            } 
        }

        public string Delete(int id) {
            Model model = dbSet.Find(id);
            dbSet.Remove(model);
            context.SaveChanges();            
            return model.id + " removed";
        }


    }
}