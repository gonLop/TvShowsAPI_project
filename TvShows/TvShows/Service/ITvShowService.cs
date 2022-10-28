using Microsoft.AspNetCore.Mvc;
using TvShows.Models;

namespace TvShows.Service
{
    public interface ITvShowService
    {
        Task<ActionResult<IEnumerable<TvShow>>> GetTvShows();

        Task<ActionResult<TvShow>> GetTvShow(int id);

        Task<List<Actor>> GetTvShowActors(int id);

        Task<List<TvShow>> GetTvShowsByGenre(string nameGenre);
    }
}
