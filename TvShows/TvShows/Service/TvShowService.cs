using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvShows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace TvShows.Service
{
    public class TvShowService : ITvShowService
    {
        private TvShowsContext _context;

        public TvShowService(TvShowsContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TvShow>>> GetTvShows()
        {
            return await _context.TvShows.ToListAsync();
        }

        public async Task<ActionResult<TvShow>> GetTvShow(int id)
        {
            var tvShow = await _context.TvShows.FindAsync(id);

            await _context.Entry(tvShow).Collection(character => character.Characters).LoadAsync();
            await _context.Entry(tvShow).Collection(episodes => episodes.Episodes).LoadAsync();
            await _context.Entry(tvShow).Collection(listGenres => listGenres.ListGenres).LoadAsync();


            return tvShow;
        }

        public async Task<List<Actor>> GetTvShowActors(int id)
        {
            var tvShow = _context.TvShows.Where(c => c.IdTvShow.Equals(id)).SingleOrDefault();

            if (tvShow == null)
            {
                return new List<Actor>();
            }

            var characters = from s in _context.Characters where s.IdTvShow == tvShow.IdTvShow select s;
            var list = await characters.ToListAsync();
            List<Actor> actors = new List<Actor>();
            
            foreach (var character in list)
            {
                var actor = await _context.Actors.FindAsync(character.IdActor);   
                actors.Add(actor);
            }

            return actors;            
        }

        public async Task<List<TvShow>> GetTvShowsByGenre(string nameGenre)
        {
            var genre = _context.Genres.Where(g => g.Title.Equals(nameGenre)).SingleOrDefault();

            if (genre == null)
            {
                return new List<TvShow>();
            }

            var listGenres = from list in _context.ListGenres where list.IdGenre == genre.IdGenre select list;
            var tvShows = await listGenres.ToListAsync();

            List<TvShow> listTvShows = new List<TvShow>();

            foreach (var tvShow in tvShows)
            {
                var ts = await _context.TvShows.FindAsync(tvShow.IdTvShow);
                listTvShows.Add(ts);
            }

            return listTvShows;
        }

        private bool TvShowExists(int id)
        {
            return _context.TvShows.Any(e => e.IdTvShow == id);
        }
    }
}
