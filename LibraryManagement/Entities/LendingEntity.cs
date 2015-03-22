using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.Entities
{
    using LibraryManagement.Entities;
    using LibraryManagement.Enums;
    public class LendingEntity : BaseEntity
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
        public DateTime IssueDate { get; set; }
     
    }
}