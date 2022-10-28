using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TvShows.Models
{
    public partial class Episode
    {
        public int IdEpisode { get; set; }
        public int? IdTvShow { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }
        public int Season { get; set; }
        public int EpisodeNumb { get; set; }
        public DateTime AirDate { get; set; }

        [JsonIgnore]
        public virtual TvShow? IdTvShowNavigation { get; set; }
    }
}
