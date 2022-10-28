using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TvShows.Models
{
    public partial class Genre
    {
        public Genre()
        {
            ListGenres = new HashSet<ListGenre>();
        }

        public int IdGenre { get; set; }
        public string Title { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ListGenre> ListGenres { get; set; }
    }
}
