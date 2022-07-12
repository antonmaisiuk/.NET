using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NET_PS_5.Models;
using NET_PS_7.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace NET_PS_5.Pages
{
    public class CreateCatModel : PageModel
    {
        [BindProperty]
        public Category newCat { get; set; }

        private readonly ILogger<IndexModel> _logger;
        //public List<Product> productList = new List<Product>();
        public IConfiguration _configuration { get; }

        public CreateCatModel(IConfiguration configuration, ILogger<IndexModel> logger)
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
                SqlCommand cmd = new SqlCommand("sp_catAdd", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter name_SqlParam = new SqlParameter("@shortName", SqlDbType.VarChar,
                50);
                name_SqlParam.Value = newCat.shortName;
                cmd.Parameters.Add(name_SqlParam);

                SqlParameter price_SqlParam = new SqlParameter("@longName", SqlDbType.VarChar);
                price_SqlParam.Value = newCat.longName;
                cmd.Parameters.Add(price_SqlParam);

                SqlParameter productID_SqlParam = new SqlParameter("@productID", SqlDbType.Int);
                productID_SqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(productID_SqlParam);


                con.Open();
                int numAff = cmd.ExecuteNonQuery();
                con.Close();
                //lblInfoText += String.Format("Inserted <b>{0}</b> record(s)<br />", numAff);
                //int productID = (int)cmd.Parameters["@productID"].Value;
                //lblInfoText += "New ID: " + productID.ToString();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
