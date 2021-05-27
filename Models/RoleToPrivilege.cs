using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class RoleToPrivilege
    {
        public int RoleToPrivilegeId { get; set; }
        public int UserRoleId { get; set; }
        public int UserPrivilegeId { get; set; }

        public virtual UserPrivilege UserPrivilege { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
