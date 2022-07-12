using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Projekt.Models;

namespace Projekt.Pages.Parts
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
        ViewData["CategoryID"] = new SelectList(_context.Category, "id", "brandName");
            return Page();
        }

        [BindProperty]
        public Part Part { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Part.imgUrl == null)
            {
                Part.imgUrl = "http://img.bazarek.pl/285684/16409/9947230/387636870614b036fabf7a.png";
            }

            _context.Part.Add(Part);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
