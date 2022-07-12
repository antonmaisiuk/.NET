using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Projekt.Models;

namespace Projekt.Pages.Parts
{
    public class EditModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;

        public EditModel(Projekt.Data.ProjektContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Part Part { get; set; }

        [Authorize(Roles = "admin")]
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
           ViewData["CategoryID"] = new SelectList(_context.Category, "id", "brandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(Part.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartExists(int id)
        {
            return _context.Part.Any(e => e.id == id);
        }
    }
}
