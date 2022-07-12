using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_PS_1.Pages
{
    public class ThanksModel : PageModel
    {
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");            
        }
        public void OnGet()
        {
        }
    }
}
