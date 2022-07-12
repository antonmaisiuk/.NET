using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_PS_3.Pages
{
    public class ResultModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string firstName { get; set; }


        [BindProperty(SupportsGet = true)]
        public int age { get; set; }


        [BindProperty(SupportsGet = true)]
        public string email { get; set; }

        [BindProperty(SupportsGet = true)]
        public float height { get; set; }


        [BindProperty(SupportsGet = true)]
        public float weight { get; set; }

        [BindProperty(SupportsGet = true)]
        public int unit { get; set; }


        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
    }
}
