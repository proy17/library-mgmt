using LibraryManagement.Entities;
using LibraryManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class RoleModel: BaseEntity
    {
        public string Roleid { get; set; }

        public List<RoleEnum> RoleNames{ get; set; }
    }
}