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
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <response code="200">User created</response>
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            return await _userService.PostUser(user);
        }

        /// <summary>
        /// Add TvShow to Favorites
        /// </summary>
        /// <response code="200">Favorite added</response>
        // POST: api/Users/1/51
        [HttpPost("{idUser}/{idTvShow}")]
        public async Task<ActionResult<Favorite>> PostFavorites(int idUser, int idTvShow)
        {
            return await _userService.PostFavorite(idUser, idTvShow);
        }

        /// <summary>
        /// Get the favorites of the user with the user id
        /// </summary>
        /// <response code="200">Favorites</response>
        // GET: api/User/1/Favorites
        [HttpGet("{idUser}/Favorites")]
        public async Task<List<TvShow>> GetUserFavorites(int idUser)
        {
            return await _userService.GetUserFavorites(idUser);
        }

        /// <summary>
        /// Delete the TvShow from the user favorites
        /// </summary>
        /// <response code="200">Favorite deleted</response>
        // DELETE: api/Users/1/51
        [HttpDelete("{idUser}/{idTvShow}")]
        public async Task<string> DeleteUser(int idUser, int idTvShow)
        {
            return await _userService.DeleteFavorite(idUser, idTvShow);
        }

    }
}
