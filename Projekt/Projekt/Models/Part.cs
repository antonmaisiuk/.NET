using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Part
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        [MaxLength(50, ErrorMessage ="Długa nazwa")]
        [Required]
        public string partName { get; set; }

        [Display(Name = "Opis")]
        [MaxLength(200, ErrorMessage = "Długa nazwa")]
        public string descript { get; set; }

        [Display(Name = "Cena")]
        [Required]
        public int price { get; set; }

        [Display(Name = "Link do zdjęć")]
        [MaxLength(200, ErrorMessage = "Długi link")]
        public string imgUrl { get; set; }

        [Display(Name = "Kategoria")]
        public int CategoryID { get; set; }

        [Display(Name = "Kategoria")]
        public Category Category { get; set; }
    }
}
