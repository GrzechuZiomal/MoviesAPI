using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class Award
    {
        public Award()
        {
            MovieAwards = new HashSet<MovieAward>();
        }

        public int AwardId { get; set; }
        public string AwardName { get; set; }

        public virtual ICollection<MovieAward> MovieAwards { get; set; }
    }
}
