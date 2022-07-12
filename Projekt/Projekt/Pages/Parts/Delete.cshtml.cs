using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Projekt.Models;

namespace Projekt.Pages.Parts
{
    public class DeleteModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;

        public DeleteModel(Projekt.Data.ProjektContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Part Part { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Part = await _context.Part
                .Include(p => p.Category).FirstOrDefaultAsync(m => m.id == id);

            if (Part == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Part = await _context.Part.FindAsync(id);

            if (Part != null)
            {
                _context.Part.Remove(Part);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
