using LibraryManagement.Entities;
using LibraryManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.ViewModels
{
    public class RoleViewModel: BaseEntity
    {
        public string Roleid { get; set; }

        public List<RoleEnums> RoleNames{ get; set; }
    }
}