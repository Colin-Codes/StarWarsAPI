using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace star_wars_api.Controllers {
    public abstract class APIController<Model, JsonConverter> : Controller where Model : class, IStarWarsModel where JsonConverter: class, IStarWarsJSONConverter<Model>{

        public star_wars_apiContext context { get; set; }
        public DbSet<Model> dbSet { get; set; }

        T GetJSON < T > (params object[] lstArgument)  
        {  
            return (T) Activator.CreateInstance(typeof (T), lstArgument);  
        } 
        
        public string Index() {    
            List<JsonConverter> JSONoutputs = new List<JsonConverter>();
            bool finished = false;
            List<Model> models = dbSet.Where(b => b.id != null).ToList();
            foreach (Model model in models) {
                JSONoutputs.Add(GetJSON<JsonConverter>(model, context));
            }
            return JsonSerializer.Serialize<List<JsonConverter>>(JSONoutputs);
        }
        
        [HttpPost]
        public string Create() {    
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                List<JsonConverter> JSONinputs = JsonSerializer.Deserialize<List<JsonConverter>>(reader.ReadToEnd());
                List<JsonConverter> JSONoutputs = new List<JsonConverter>();
                foreach (JsonConverter json in JSONinputs) {
                    Model model = json.ToModel(context);
                    dbSet.Add(model);
                    JSONoutputs.Add(GetJSON<JsonConverter>(model, context));
                }                
                context.SaveChanges();
                return JsonSerializer.Serialize<List<JsonConverter>>(JSONoutputs);
            }       
        }
        
        public string Retrieve(int id) {
            List<JsonConverter> JSONoutputs = new List<JsonConverter>();
            JSONoutputs.Add(GetJSON<JsonConverter>(dbSet.Find(id), context));
            return JsonSerializer.Serialize<List<JsonConverter>>(JSONoutputs);
        }

        [HttpPost]
        public string Update() {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) {
                List<JsonConverter> JSONinputs = JsonSerializer.Deserialize<List<JsonConverter>>(reader.ReadToEnd());
                List<JsonConverter> JSONoutputs = new List<JsonConverter>();
                foreach (JsonConverter json in JSONinputs) {
                    Model model = json.ToModel(context);
                    dbSet.Update(model);
                    JSONoutputs.Add(GetJSON<JsonConverter>(model, context));
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