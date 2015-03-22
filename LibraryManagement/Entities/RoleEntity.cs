using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.Entities
{
    using LibraryManagement.Entities;
    using LibraryManagement.Enums;
    public class RoleEntity : BaseEntity
    {
        public RoleEnum RoleName{ get; set; }
    }
}