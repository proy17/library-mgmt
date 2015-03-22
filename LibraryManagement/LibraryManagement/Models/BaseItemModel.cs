using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LibraryManagement.Models
{
    using LibraryManagement.Enums;
	/// <summary>
	/// 
	/// </summary>
	public abstract class BaseItemModel : BaseModel
	{
		/// <summary>
		/// 
		/// </summary>
        /// 

        [Required]

        public string Id { get; set; }
        public ItemStatus BookStatus { get; set; }

	}
}