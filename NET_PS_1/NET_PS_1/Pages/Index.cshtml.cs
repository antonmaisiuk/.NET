using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET_PS_1.Models;

namespace NET_PS_1.Pages
{
    public class IndexModel : PageModel
    {
        
        public IActionResult OnPost(Person person)
        {
            if (person.age < 18)
            {
                return RedirectToPage("Thanks");
            }
            else
            {
                return RedirectToPage("Welcome", person);
            }
        }

    }
}
