using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Pages.Parts
{
    public class IndexModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;

        public IndexModel(Projekt.Data.ProjektContext context)
        {
            _context = context;

        }

        

        public IList<Part> Part { get;set; }

        public async Task OnGetAsync()
        {
            //_context.Find()
            CookieOptions cookieOptions = new CookieOptions();
            //Response.Cookies.Append("RoleId", "3", cookieOptions);

            Part = await _context.Part
                .Include(p => p.Category).ToListAsync();
        }
    }
}
