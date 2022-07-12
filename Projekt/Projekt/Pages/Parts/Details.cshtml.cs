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
    public class DetailsModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;

        public DetailsModel(Projekt.Data.ProjektContext context)
        {
            _context = context;
        }

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
    }
}
