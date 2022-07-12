using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_5.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string name { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        [Range(0, int.MaxValue, ErrorMessage = "Cena musi być >= 0")]
        public decimal price { get; set; }
    }
}
