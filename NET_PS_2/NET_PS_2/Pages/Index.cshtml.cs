using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NET_PS_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_2.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
               return Page();
            
            return RedirectToPage("hello.html");
            
        }
    }
}
