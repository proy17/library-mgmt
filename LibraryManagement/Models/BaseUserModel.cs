using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public abstract class BaseUserModel
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
        public UserMetadataModel UserMetaDataModel { get; set; }

       
    }
}