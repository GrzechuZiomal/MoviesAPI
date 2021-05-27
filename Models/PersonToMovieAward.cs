using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class PersonToMovieAward
    {
        public int PersonToMovieAwardsId { get; set; }
        public int MovieAwardsId { get; set; }
        public long PersonId { get; set; }

        public virtual MovieAward MovieAwards { get; set; }
        public virtual Person Person { get; set; }
    }
}
