using Microsoft.AspNetCore.Mvc;
using TvShows.Models;

namespace TvShows.Service
{
    public interface ITvShowService
    {
        Task<IEnumerable<TvShow>> GetTvShows();

        Task<TvShow> GetTvShow(int id);

        Task<List<Actor>> GetTvShowActors(int id);

        Task<List<TvShow>> GetTvShowsByGenre(string nameGenre);
    }
}
