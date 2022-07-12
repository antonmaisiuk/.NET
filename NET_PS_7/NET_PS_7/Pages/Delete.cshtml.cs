using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NET_PS_5.Models;
using NET_PS_7.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace NET_PS_5.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //public List<Product> productList = new List<Product>();
        public IConfiguration _configuration { get; }

        public DeleteModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // Użyj DataAcesseLayer

        public string lblInfoText;
        public IActionResult OnGet()
        {            
            int idOfProduct = Int32.Parse(HttpContext.Request.Query["id"]);
            string myCompanyDB_connection_string =
            _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
            SqlCommand cmd = new SqlCommand("sp_productDel", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter productID_SqlParam = new SqlParameter("@productID", SqlDbType.Int);
            productID_SqlParam.Value = idOfProduct;
            cmd.Parameters.Add(productID_SqlParam);


            con.Open();
            int numAff = cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToPage("Index");
        }
    }
}
