using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class TopMovie
    {
        public string Title { get; set; }
        public decimal Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal? VotesAvg { get; set; }
        public long MovieId { get; set; }
    }
}
