using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NET_PS_2.Models
{
    public class Person
    {
        [Display(Name = "Imie")]
        [Required(ErrorMessage = "Pole jest obowiazkowe")]
        
        public string firstName { get; set;}

        
        [Display(Name = "Wiek")]        
        
        public int age { get; set; }


        

    }
}
