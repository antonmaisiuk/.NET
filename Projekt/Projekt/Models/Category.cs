using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Category
    {
        public int id { get; set; }

        [Display(Name = "Marka samochodu")]
        [MaxLength(20, ErrorMessage = "Długa nazwa")]
        [Required]
        public string brandName { get; set; }

        [Display(Name = "Model samochodu")]
        [MaxLength(20, ErrorMessage = "Długa nazwa")]
        [Required]
        public string modelName { get; set; }

        [Display(Name = "Generacja samochodu")]
        [MaxLength(20, ErrorMessage = "Długa nazwa")]
        [Required]
        public string genName { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
