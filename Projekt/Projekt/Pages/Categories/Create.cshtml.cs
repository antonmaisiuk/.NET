using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Projekt.Models;

namespace Projekt.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;

        public CreateModel(Projekt.Data.ProjektContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            string currentUser = HttpContext.Request.Cookies["RoleId"];

            if (currentUser != "1" || currentUser != "2")
            {
                return RedirectToPage("../Parts/Index");
            }
            //return RedirectToPage();
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
