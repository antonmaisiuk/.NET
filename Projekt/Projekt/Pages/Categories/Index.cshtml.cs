using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Projekt.Models;

namespace Projekt.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;

        public IndexModel(Projekt.Data.ProjektContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
