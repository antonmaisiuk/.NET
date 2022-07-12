using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_PS_3.Models;

namespace NET_PS_3.Pages
{
    public class KalkulatorModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost(Person person)
        {
            if (!ModelState.IsValid)
            {                
                //return Page();
            }

            return RedirectToPage("Result", person);



        }
    }
}
