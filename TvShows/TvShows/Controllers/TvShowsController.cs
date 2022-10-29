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
        public async Task<IEnumerable<TvShow>> GetTvShows()
        {
            return await _service.GetTvShows();
        }

        /// <summary>
        /// Get TvShow by id
        /// </summary>
        /// <response code="200">TvShow</response>
        /// <response code="404">TvShow Not Found</response>
        // GET: api/TvShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TvShow>> GetTvShow(int id)
        {
            var tvShow = await _service.GetTvShow(id);

            if (tvShow.IdTvShow == 0)
            {
                return NotFound();
            }

            return tvShow;
        }

        /// <summary>
        /// Get Actors from TvShow
        /// </summary>
        /// <response code="200">Actors</response>
        /// <response code="404">Actors Not Found</response>
        // GET: api/TvShows/51/Actors
        [HttpGet("{id}/Actors")]
        public async Task<ActionResult<List<Actor>>> GetTvShowActors(int id)
        {
            var actors = await _service.GetTvShowActors(id);

            if (actors.Count == 0)
            {
                return NotFound();
            }

            return actors;
        }

        /// <summary>
        /// Get TvShows by Genre
        /// </summary>
        /// <response code="200">TvShows</response>
        /// <response code="404">TvShows Not Found</response>
        // GET: api/TvShows/Genre?genre=Drama
        [HttpGet("Genre")]
        public async Task<ActionResult<List<TvShow>>> GetTvShowsByGenre(string nameGenre)
        {
            var tvShows = await _service.GetTvShowsByGenre(nameGenre);
            if (tvShows.Count == 0)
            {
                return NotFound();
            }

            return tvShows;
        }

    }
}
