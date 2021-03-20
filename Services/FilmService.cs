using System.Collections.Generic;
using System.Linq;
using star_wars_api.Data;
using star_wars_api.Models;
using star_wars_api.Repositories;

namespace star_wars_api.Services
{
    public class FilmService
    {
        private FilmRepository _filmRepository;

        public FilmService(star_wars_apiContext context) 
        {
            _filmRepository = new FilmRepository(context);
        }

        public FilmsVM GetFilmVMs()
        {
            List<FilmDM> filmDMs = _filmRepository.GetFilmDMs();
            return new FilmsVM()
            {
                films = filmDMs
                .Select(x => new FilmVM()
                    {
                        episodeId = x.episodeId,
                        director = x.director,
                        openingCrawl = x.openingCrawl,
                        producer = x.producer,
                        title = x.title,
                        releaseDate = x.releaseDate
                    }
                ).ToList()
            };
        }
    }
}