using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            UserActivityLogs = new HashSet<UserActivityLog>();
        }

        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }

        public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; }
    }
}
