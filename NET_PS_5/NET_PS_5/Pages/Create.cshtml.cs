using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NET_PS_5.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NET_PS_5.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public List<Product> productList = new List<Product>();
        public IConfiguration _configuration { get; }

        public CreateModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // Użyj DataAcesseLayer

        public string lblInfoText;
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                
                string myCompanyDB_connection_string = _configuration.GetConnectionString("myCompanyDB");
                SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
                //string sql = "SELECT COUNT(*) FROM Product";
                string sql = "insert into Product(Name,price) values(@Name, @Price)";
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    con.Open();
                    //cmd.CommandText = "SELECT COUNT(*) FROM Product";
                    
                    //int count = (Int32)cmd.ExecuteScalar();
                    //cmd = new SqlCommand("insert into Product(Name,price) values(@Name, @Price)",con);
                    //cmd.CommandText = "insert into Product(Id,Name,price) values(@Id, @Name, @Price)";
                    //cmd.Parameters.AddWithValue("@Id", count + 1);
                    cmd.Parameters.AddWithValue("@Name", newProduct.name);
                    cmd.Parameters.AddWithValue("@Price", newProduct.price);
                    int numAff = cmd.ExecuteNonQuery();
                    lblInfoText += string.Format("<br />Dodano <b>{0}</b> record(s)<br />", numAff);
                }
                catch (SqlException exc)
                {
                    lblInfoText += string.Format("<b>Blad:</b> {0}<br /><br />", exc.Message);
                }
                finally { con.Close(); }

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
