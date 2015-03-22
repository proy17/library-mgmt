using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.Models
{
    public class UserMetadataModel
    {
        public string UserId { get; set; }
        public RoleModel UserRole { get; set; }
    }
}