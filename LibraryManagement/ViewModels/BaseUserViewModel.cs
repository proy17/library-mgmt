using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.ViewModels
{
    public abstract class BaseUseViewModel
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
        public UserMetadataViewModel UserMetaDataViewModel { get; set; }

       
    }
}