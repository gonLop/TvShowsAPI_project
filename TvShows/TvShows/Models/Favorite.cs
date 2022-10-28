using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TvShows.Models
{
    public partial class Favorite
    {
        public int IdFavorites { get; set; }
        public int? IdUser { get; set; }
        public int? IdTvShow { get; set; }

        [JsonIgnore]
        public virtual TvShow? IdTvShowNavigation { get; set; }
        [JsonIgnore]
        public virtual User? IdUserNavigation { get; set; }
    }
}
