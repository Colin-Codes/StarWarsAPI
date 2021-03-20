using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using star_wars_api.Controllers;
using star_wars_api.Data;
using star_wars_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace star_wars_api.Repositories
{
    public class FilmRepository 
    {
        private star_wars_apiContext _context { get; set; }

        public DbSet<Film> dbSet { get; set; }

        public FilmRepository(star_wars_apiContext context) {
            _context = context;
            dbSet = _context.Film;
        }

        public List<FilmDM> GetFilmDMs()
        {
            return _context.Film
                .Select(x => new FilmDM()
                    {
                        episodeId = x.episodeId,
                        director = x.director,
                        openingCrawl = x.openingCrawl,
                        producer = x.producer,
                        title = x.title,
                        releaseDate = x.releaseDate
                    }
            ).ToList();
        }
    }
}