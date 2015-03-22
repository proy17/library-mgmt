using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.Models
{
    public class LocationModel : BaseEntity
    {
        public BaseItemModel Item { get; set; }

        public string ShelfNumber { get; set; }

        public string AisleName { get; set; }

    }
}