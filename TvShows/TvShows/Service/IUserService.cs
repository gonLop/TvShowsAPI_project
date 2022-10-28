using Microsoft.AspNetCore.Mvc;
using TvShows.Models;

namespace TvShows.Service
{
    public interface IUserService
    {
        Task<User> PostUser(User user);

        Task<Favorite> PostFavorite(int idUser, int idTvShow);

        Task<string> DeleteFavorite(int idUser, int idTvShow);

        Task<List<TvShow>> GetUserFavorites(int idUser);
    }
}
