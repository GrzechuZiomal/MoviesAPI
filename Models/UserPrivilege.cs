using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class UserPrivilege
    {
        public UserPrivilege()
        {
            RoleToPrivileges = new HashSet<RoleToPrivilege>();
        }

        public int UserPrivilegeId { get; set; }
        public string PrivilegeName { get; set; }

        public virtual ICollection<RoleToPrivilege> RoleToPrivileges { get; set; }
    }
}
