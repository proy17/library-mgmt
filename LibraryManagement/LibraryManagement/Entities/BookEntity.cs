using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.Entities
{
    using LibraryManagement.Entities;
    
    public class BookEntity : BaseItemEntity
	{
	    [Required]
        public string BookMetaData { get; set; }
	}
}