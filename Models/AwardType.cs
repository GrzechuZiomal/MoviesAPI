using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class AwardType
    {
        public AwardType()
        {
            MovieAwards = new HashSet<MovieAward>();
        }

        public int AwardTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<MovieAward> MovieAwards { get; set; }
    }
}
