using System;
using System.Collections.Generic;

namespace TvShows.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int IdUser { get; set; }
        public string Nickname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pwd { get; set; } = null!;

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
