using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class UserActivityLog
    {
        public int ActivityId { get; set; }
        public DateTime ActivityDatetime { get; set; }
        public int UserId { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityDescription { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual User User { get; set; }
    }
}
