using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.Models
{
    public class UserModel: BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Roleid { get; set; }

       
    }
}