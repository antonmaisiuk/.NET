using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_7.Models
{
    public class Category
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int id { get; set; }
        [Display(Name = "Krótka nazwa")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string shortName { get; set; }
        [Display(Name = "Długa nazwa")]
        [Required(ErrorMessage = "Pole obowiązkowe")]        
        public string longName { get; set; }
    }
}
