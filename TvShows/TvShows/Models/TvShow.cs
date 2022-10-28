
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TvShows.Models
{
    public partial class TvShow
    {
        public TvShow()
        {
            Characters = new HashSet<Character>();
            Episodes = new HashSet<Episode>();
            Favorites = new HashSet<Favorite>();
            ListGenres = new HashSet<ListGenre>();
        }

        public int IdTvShow { get; set; }
        public string Title { get; set; } = null!;
        public string ShowDescription { get; set; } = null!;
        public string ShowStatus { get; set; } = null!;
        public string Poster { get; set; } = null!;

        
        public virtual ICollection<Character> Characters { get; set; }
        
        public virtual ICollection<Episode> Episodes { get; set; }

        [JsonIgnore]
        public virtual ICollection<Favorite> Favorites { get; set; }
        
        public virtual ICollection<ListGenre> ListGenres { get; set; }
    }
}
