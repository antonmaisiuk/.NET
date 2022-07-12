using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_PS_1.Models;

namespace NET_PS_1.Pages
{
    public class WelcomeModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string firstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string lastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int age { get; set; }

        [BindProperty(SupportsGet = true)]
        public string gender {get; set; }

        [BindProperty(SupportsGet = true)]
        public string tel { get; set; }
        
        public char lang { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool csharp { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool cpp { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool java { get; set; }

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
        }        
    }
}
