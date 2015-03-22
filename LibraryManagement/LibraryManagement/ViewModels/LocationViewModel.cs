using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        public BaseItemViewModel Item { get; set; }

        public string ShelfNumber { get; set; }

        public string AisleName { get; set; }

    }
}