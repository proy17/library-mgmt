﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
    public class UserMetadataViewModel
    {
        public string UserId { get; set; }
        public List<RoleViewModel> UserRoleViewModel { get; set; }
    }
}