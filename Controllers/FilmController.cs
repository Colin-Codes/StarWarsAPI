using Microsoft.AspNetCore.Mvc;
using star_wars_api.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using star_wars_api.Data;
using System.Collections.Generic;
using System;

namespace star_wars_api.Controllers {
    public class FilmController : APIController<Film> {

        public FilmController(star_wars_apiContext context) {
            _context = context;
            _dbSet = context.Film;
        }

    }
}