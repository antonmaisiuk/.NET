using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_PS_8.Data;
using NET_PS_8.Models;

namespace NET_PS_8.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly NET_PS_8.Data.ShopContext _context;

        public IndexModel(NET_PS_8.Data.ShopContext context)
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
