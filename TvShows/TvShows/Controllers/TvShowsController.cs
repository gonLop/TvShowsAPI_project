using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvShows.Models;
using TvShows.Service;

namespace TvShows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowService _service;

        public TvShowsController(ITvShowService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get All TvShows
        /// </summary>
        /// <response code="200">TvShows</response>
        // GET: api/TvShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TvShow>>> GetTvShows()
        {
            return await _service.GetTvShows();
        }

        /// <summary>
        /// Get TvShow by id
        /// </summary>
        /// <response code="200">TvShow</response>
        // GET: api/TvShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TvShow>> GetTvShow(int id)
        {
            var tvShow = await _service.GetTvShow(id);

            if (tvShow == null)
            {
                return NotFound();
            }

            return tvShow;
        }

        /// <summary>
        /// Get Actors from TvShow
        /// </summary>
        /// <response code="200">Actors</response>
        // GET: api/TvShows/51/Actors
        [HttpGet("{id}/Actors")]
        public async Task<List<Actor>> GetTvShowActors(int id)
        {
            var actors = await _service.GetTvShowActors(id);

            if (actors == null)
            {
                return new List<Actor>();
            }

            return actors;
        }

        /// <summary>
        /// Get TvShows by Genre
        /// </summary>
        /// <response code="200">TvShows</response>
        // GET: api/TvShows/Genre?genre=Drama
        [HttpGet("Genre")]
        public async Task<List<TvShow>> GetTvShowsByGenre(string nameGenre)
        {
            var tvShows = await _service.GetTvShowsByGenre(nameGenre);
            if (tvShows == null)
            {
                return new List<TvShow>();
            }

            return tvShows;
        }

    }
}
