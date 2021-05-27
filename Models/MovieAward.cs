using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class MovieAward
    {
        public MovieAward()
        {
            PersonToMovieAwards = new HashSet<PersonToMovieAward>();
        }

        public int MovieAwardsId { get; set; }
        public long MovieId { get; set; }
        public int AwardId { get; set; }
        public int AwardTypeId { get; set; }
        public DateTime? MovieAwardsDatetime { get; set; }

        public virtual Award Award { get; set; }
        public virtual AwardType AwardType { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<PersonToMovieAward> PersonToMovieAwards { get; set; }
    }
}
