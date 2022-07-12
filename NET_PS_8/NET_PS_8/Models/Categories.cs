using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_8.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Długa nazwa")]
        [Required]
        public string longName { get; set; }

        [Display(Name = "Krótka nazwa")]
        [Required]
        public string shortName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
