using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class MovieReview
    {
        public MovieReview()
        {
            VoteReviews = new HashSet<VoteReview>();
        }

        public int ReviewId { get; set; }
        public decimal ReviewRating { get; set; }
        public string ReviewDescription { get; set; }
        public int UserId { get; set; }
        public long MovieId { get; set; }
        public DateTime ReviewDatetime { get; set; }
        public decimal UserScore { get; set; }
        [JsonIgnore]
        public virtual Movie Movie { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public virtual ICollection<VoteReview> VoteReviews { get; set; }
    }
}
