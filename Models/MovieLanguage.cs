using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class MovieLanguage
    {
        public long MovieId { get; set; }
        public string Iso6391 { get; set; }
        public bool IsOriginal { get; set; }

        public virtual Language Iso6391Navigation { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
