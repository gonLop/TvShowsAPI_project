using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvShows.Models;
using XAct.Users;
using XSystem.Security.Cryptography;
using User = TvShows.Models.User;

namespace TvShows.Service
{
    public class UserService : IUserService
    {
        private TvShowsContext _context;

        public UserService(TvShowsContext context)
        {
            _context = context;
        }

        public async Task<Favorite> PostFavorite(int idUser, int idTvShow)
        {
            var userFavorites = from f in _context.Favorites where f.IdUser == idUser select f;
            var list = await userFavorites.ToListAsync();

            foreach (var fav in list)
            {
                if (fav.IdTvShow == idTvShow)
                {
                    return fav;
                }
            }

            Favorite favorite = new Favorite();
            favorite.IdUser = idUser;
            favorite.IdTvShow = idTvShow;

            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return favorite;
        }

        public async Task<User> PostUser(User user)
        {
            user.Pwd = HashTheUserPassword(user.Pwd);
            user.Favorites = null;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> DeleteFavorite(int idUser, int idTvShow)
        {
            var userFavorites = from f in _context.Favorites where f.IdUser == idUser select f;
            var list = await userFavorites.ToListAsync();

            foreach (var fav in list)
            {
                if (fav.IdTvShow == idTvShow)
                {
                    _context.Favorites.Remove(fav);
                    await _context.SaveChangesAsync();
                    return "Favorite Deleted";
                }
            }
            return "Favorite not found";
        }

        public async Task<List<TvShow>> GetUserFavorites(int idUser)
        {
            var userFavorites = from f in _context.Favorites where f.IdUser == idUser select f;
            var list = await userFavorites.ToListAsync();

            List<TvShow> listTvShows = new List<TvShow>();
            foreach(var fav in list)
            {
                var ts = await _context.TvShows.FindAsync(fav.IdTvShow);
                listTvShows.Add(ts);
            }

            return listTvShows;
        }

        private string HashTheUserPassword(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] p = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(p);
            }
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.IdUser == id);
        }
    }
}
