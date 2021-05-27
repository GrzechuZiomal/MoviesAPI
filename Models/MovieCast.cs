using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class MovieCast
    {
        public long MovieId { get; set; }
        public long PersonId { get; set; }
        public string CharacterName { get; set; }

        public virtual Movie Movie { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
    }
}
