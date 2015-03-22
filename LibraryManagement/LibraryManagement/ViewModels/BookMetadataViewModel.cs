using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace LibraryManagement.ViewModels
{
    public class BookMetadataViewModel: BaseViewModel
    {
        public string BookName { get; set; }
        public string BookVersion { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }        
        public string Language { get; set; }
        public string IssueDate { get; set; }
    }
}