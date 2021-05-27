using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class RoleChangeLog
    {
        public int RoleChangeLogId { get; set; }
        public DateTime EventTime { get; set; }
        public int UserId { get; set; }
        public int ChangeRoleFrom { get; set; }
        public int ChangeRoleTo { get; set; }
        public int SetByUser { get; set; }

        public virtual UserRole ChangeRoleFromNavigation { get; set; }
        public virtual UserRole ChangeRoleToNavigation { get; set; }
        public virtual User SetByUserNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
