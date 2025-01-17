﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class VoteReview
    {
        public int VoteReviewId { get; set; }
        public decimal? VoteReviewRating { get; set; }
        public string VoteReviewDescription { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public DateTime VoteDatetime { get; set; }
        public decimal UserScore { get; set; }

        public virtual MovieReview Review { get; set; }
        public virtual User User { get; set; }
    }
}
