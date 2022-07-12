using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NET_PS_8.Data;
using NET_PS_8.Models;

namespace NET_PS_8.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly NET_PS_8.Data.ShopContext _context;
        private readonly ILogger<DetailsModel> _logger;
        public List<Product> _productList = new List<Product>();
        public List<Product> productList = new List<Product>();
        //public IQueryable productList;
        //public List<Category> categoryList = new List<Category>();

        public IConfiguration _configuration { get; }

        //public DetailsModel(IConfiguration configuration, ILogger<DetailsModel> logger)
        //{
        //    _logger = logger;
        //    _configuration = configuration;
        //}

        // Użyj DataAcesseLayer

        //public string lblInfoText;

        public DetailsModel(NET_PS_8.Data.ShopContext context)
        {
            _context = context;

        }

        public Category Category { get; set; }
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");

            //SqlConnection con = new SqlConnection(myCompanyDBcs);
            //string sql = "SELECT * FROM Product";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    int _id = Int32.Parse(reader["Id"].ToString());
            //    string _name = reader.GetString(1);
            //    int _price = Int32.Parse(String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString())));

            //    productList.Add(new Product
            //    {
            //        id = _id,
            //        name = _name,
            //        price = _price
            //    });

            //}
            //reader.Close();
            //con.Close();

            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.id == id);
            //productList = await _context.Product.Where(m => m.CategoryID == id);
            _productList = await _context.Product.ToListAsync();

            foreach (var p in _productList)
            {
                if (p.CategoryID == id)
                {
                    productList.Add(p);
                }
            }

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}