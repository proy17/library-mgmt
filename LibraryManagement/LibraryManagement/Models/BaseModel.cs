using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryManagement.Models
{
    public class BaseModel
    {
        [Required]
        public string ID { get; set; }
    }

}
