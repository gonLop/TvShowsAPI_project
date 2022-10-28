using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TvShows.Models
{
    public partial class ListGenre
    {
        public int IdListGenres { get; set; }
        public int? IdGenre { get; set; }
        public int? IdTvShow { get; set; }

        [JsonIgnore]
        public virtual Genre? IdGenreNavigation { get; set; }
        [JsonIgnore]
        public virtual TvShow? IdTvShowNavigation { get; set; }
    }
}
