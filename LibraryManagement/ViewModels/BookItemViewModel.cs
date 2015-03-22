using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
    public class BookItemViewModel : BaseItemViewModel
	{
        public BookMetadataViewModel BookMetaDataModel { get; set; }
	}
}