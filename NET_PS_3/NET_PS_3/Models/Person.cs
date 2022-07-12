using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NET_PS_3.Models
{
    public class Person
    {
        [Display(Name = "Imie")]
        [Required(ErrorMessage = "Pole jest obowiazkowe")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,15}$", ErrorMessage = "Imie może składać się wyłącznie z liter, długość do 15 znaków")]
        public string firstName { get; set; }


        [Display(Name = "Wiek")]
        [Range(1, 120, ErrorMessage = "Dozwolone tylko całkowite liczby od 1 do 120.")]
        public int? age { get; set; }


        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        public string email { get; set; }

        [Display(Name = "Wzrost")]
        [Required(ErrorMessage = "Pole jest obowiazkowe")]
        [Range(0, 999.99, ErrorMessage = "Dozwolone tylko liczby")]
        public float height { get; set; }


        [Display(Name = "Waga")]
        [Required(ErrorMessage = "Pole jest obowiazkowe")]
        [Range(0, 300, ErrorMessage = "Wprowadź poprawną wagę (0-300kg)")]
        public float weight { get; set; }

        public int unit { get; set; }
    }
}
