using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_3.Pages
{
    public class IndexModel : PageModel
    {  

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Kalkulator");
        }
    }
}
