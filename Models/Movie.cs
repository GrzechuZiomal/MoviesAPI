using Microsoft.EntityFrameworkCore;
using MoviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieAwards = new HashSet<MovieAward>();
            MovieReviews = new HashSet<MovieReview>();
        }

        public long MovieId { get; set; }
        public string Title { get; set; }
        public decimal? Budget { get; set; }
        public string Homepage { get; set; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal? Revenue { get; set; }
        public int Runtime { get; set; }
        public string MovieStatus { get; set; }
        public string Tagline { get; set; }
        public long? VotesCount { get; set; }
        public decimal? VotesAvg { get; set; }
        [NotMapped]
        public List<ProductionCompany> production_companies { get; set; }
        [NotMapped]
        public List<Country> production_countries { get; set; }
        [NotMapped]
        public List<Language> spoken_languages { get; set; }
        [NotMapped]
        public List<Keyword> keywords { get; set; } = new List<Keyword>();
        [NotMapped]
        public List<Genre> genres { get; set; } = new List<Genre>();
        [NotMapped]
        public List<Crew> Crew { get; set; }
        [NotMapped]
        public List<Cast> Cast { get; set; }

        public virtual ICollection<MovieAward> MovieAwards { get; set; }
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
    }
}
