using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class SiteUser
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Imie")]
        [MaxLength(20,ErrorMessage ="Długie imie")]
        public string userName { get; set; }

        //[Display(Name = "Email")]
        //public string Email { get; set; }
        [Required]
        [MaxLength(44, ErrorMessage = "Długie hasło")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Potwierdzenie hasła")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage = "Hasła nie zgadzają się")]
        public string confirmPassword { get; set; }

        public byte[] salt { get; set; }

        [Required]
        public int? roleId { get; set; }
        public Role Role { get; set; }

    }
}
