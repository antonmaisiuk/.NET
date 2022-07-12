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
using System.Data;
using NET_PS_7.Models;

namespace NET_PS_5.Pages
{
    public class EditModel : PageModel
    {
        public List<Product> productList;

        [BindProperty]
        public Product editProduct { get; set; }
        public List<Category> categoryList = new List<Category>();

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
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");

            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT * FROM Category";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categoryList.Add(new Category
                {
                    id = Int32.Parse(reader["Id"].ToString()),
                    shortName = reader.GetString(1),
                    longName = reader.GetString(2)
                });
            }
            reader.Close();
            con.Close();
        }
        public IActionResult OnPost()
        {
            int idOfProduct = Int32.Parse(HttpContext.Request.Query["id"]);
            string myCompanyDB_connection_string = _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
            SqlCommand cmd = new SqlCommand("sp_productUpd", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar,
            50);
            name_SqlParam.Value = editProduct.name;
            cmd.Parameters.Add(name_SqlParam);

            SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.Money);
            price_SqlParam.Value = editProduct.price;
            cmd.Parameters.Add(price_SqlParam);

            SqlParameter categoryId_SqlParam = new SqlParameter("@categoryId", SqlDbType.Money);
            categoryId_SqlParam.Value = editProduct.categoryId;
            cmd.Parameters.Add(categoryId_SqlParam);

            SqlParameter productID_SqlParam = new SqlParameter("@productID", SqlDbType.Int);
            productID_SqlParam.Value = idOfProduct;
            cmd.Parameters.Add(productID_SqlParam);


            con.Open();
            int numAff = cmd.ExecuteNonQuery();
            con.Close();
            //lblInfoText += String.Format("Inserted <b>{0}</b> record(s)<br />", numAff);
            //int productID = (int)cmd.Parameters["@productID"].Value;
            //lblInfoText += "New ID: " + productID.ToString();

            return RedirectToPage("Index");
        }
    }
}
