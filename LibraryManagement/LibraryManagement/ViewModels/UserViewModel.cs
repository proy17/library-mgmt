using LibraryManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        /// <summary>
        /// 
        /// </summary>
       [Display(Name = "FirstName")]
        public string Firstname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "User name")]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RoleId { get; set; }




    }
}