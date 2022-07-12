using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_8.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Nazwa")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Cena")]
        [Required]
        public int price { get; set; }

        [Display(Name = "Kategoria")]
        public int CategoryID { get; set; }
        [Display(Name = "Kategoria")]
        public Category Category { get; set; }
    }
}
