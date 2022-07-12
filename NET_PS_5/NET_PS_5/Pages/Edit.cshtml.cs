using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NET_PS_5.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;

namespace NET_PS_5.Pages
{
    public class EditModel : PageModel
    {
        public List<Product> productList;

        [BindProperty]
        public Product editProduct { get; set; }

        private readonly ILogger<IndexModel> _logger;
        //public List<Product> productList = new List<Product>();
        public IConfiguration _configuration { get; }

        public EditModel(IConfiguration configuration, ILogger<IndexModel> logger)
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
            int idOfProduct = Int32.Parse(HttpContext.Request.Query["id"]);
            string myCompanyDB_connection_string = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
            string sql = "UPDATE Product SET Name = @name, price = @price WHERE Id = @idOfProduct";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idOfProduct", idOfProduct);
            cmd.Parameters.AddWithValue("@name", editProduct.name);
            cmd.Parameters.AddWithValue("@price", editProduct.price);
            try
            {
                con.Open();
                int numAff = cmd.ExecuteNonQuery();
                //lblInfoText += string.Format("<br />Edited <b>{0}</b> record(s)<br />", numAff);
            }
            catch (SqlException exc)
            {
                lblInfoText += string.Format("<b>Error:</b> {0}<br /><br />", exc.Message);
            }
            finally { con.Close(); }
            return RedirectToPage("Index");
        }
    }
}
