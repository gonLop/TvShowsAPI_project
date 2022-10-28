using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TvShows.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Characters = new HashSet<Character>();
        }

        public int IdActor { get; set; }
        public string ActorName { get; set; } = null!;
        public byte Age { get; set; }

        [JsonIgnore]
        public virtual ICollection<Character> Characters { get; set; }
    }
}
