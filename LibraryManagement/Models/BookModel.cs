using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models    
{
  
	/// <summary>
	/// 
	/// </summary>
    public class BookModel : BaseItemModel
	{

        /// <summary>
        /// 
        /// </summary>

        [Required]
        public BookMetadataModel BookMetaDataModel { get; set; }
        
	}
}