using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TvShows.Models
{
    public partial class Character
    {
        public int IdCharacter { get; set; }
        public int? IdActor { get; set; }
        public int? IdTvShow { get; set; }
        public string CharacterName { get; set; } = null!;

        [JsonIgnore]
        public virtual Actor? IdActorNavigation { get; set; }
        [JsonIgnore]
        public virtual TvShow? IdTvShowNavigation { get; set; }
    }
}
