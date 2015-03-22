using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
    using LibraryManagement.Enums;
	/// <summary>
	/// 
	/// </summary>
	public abstract class BaseItemViewModel : BaseViewModel
	{
		/// <summary>
		/// 
		/// </summary>
        /// 

        [Required]

        public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>

        [Required]

        public MetadataViewModel MetaDataViewModel { get; set; }

        public ItemStatus BookStatus { get; set; }
	}
}