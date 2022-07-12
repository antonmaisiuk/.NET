using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_PS_8.Data;
using NET_PS_8.Models;

namespace NET_PS_8.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly NET_PS_8.Data.ShopContext _context;

        public IndexModel(NET_PS_8.Data.ShopContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.Include(p => p.Category).ToListAsync();
        }
    }
}
