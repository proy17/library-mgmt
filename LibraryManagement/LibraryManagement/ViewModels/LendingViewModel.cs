using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
    public class LendingViewModel:BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Issuer { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ItemIssued { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime Issuedate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string LendingStatus { get; set; }
    }
}