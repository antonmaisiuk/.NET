using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text;
using NET_PS_5.Models;
using NET_PS_7.Models;

namespace NET_PS_5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> productList = new List<Product>();
        public List<Category> categoryList = new List<Category>();

        public IConfiguration _configuration { get; }

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // Użyj DataAcesseLayer

        public string lblInfoText;

        //public int id;
        public void OnGet()
        {
            string myCompanyDBcs = _configuration.GetConnectionString("myCompanyDB");

            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int _id = Int32.Parse(reader["Id"].ToString());
                string _name = reader.GetString(1);
                decimal _price = Decimal.Parse(String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString())));
                int _categoryId = Int32.Parse(reader["categoryId"].ToString());
                string _categoryLongName = "";

                SqlConnection conCatName = new SqlConnection(myCompanyDBcs);
                string sqlCatName = "SELECT longName FROM Category WHERE Id = " + _categoryId;
                SqlCommand cmdCatName = new SqlCommand(sqlCatName, conCatName);
                conCatName.Open();
                SqlDataReader readerCatName = cmdCatName.ExecuteReader();
                while (readerCatName.Read())
                {
                    _categoryLongName = readerCatName.GetString(0);
                }
                readerCatName.Close();
                conCatName.Close();

                productList.Add(new Product 
                { 
                    id = _id,
                    name = _name,
                    price = _price,
                    categoryId = _categoryId,
                    categoryLongName = _categoryLongName
                });

            }
            reader.Close();
            con.Close();


            SqlConnection conCat = new SqlConnection(myCompanyDBcs);
            string sqlCat = "SELECT * FROM Category";
            SqlCommand cmdCat = new SqlCommand(sqlCat, conCat);
            conCat.Open();
            SqlDataReader readerCat = cmdCat.ExecuteReader();
            while (readerCat.Read())
            {
                categoryList.Add(new Category
                {
                    id = Int32.Parse(readerCat["Id"].ToString()),
                    shortName = readerCat.GetString(1),
                    longName = readerCat.GetString(2)
                });
            }
            readerCat.Close();
            conCat.Close();
            //Product prod = new Product
            //{
            //    id = Int32.Parse(reader["Id"].ToString()),
            //    name = reader.GetString(1),
            //    price = Decimal.Parse(String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString())))
            //};
            //htmlStr.Append("<tr>");
            //    htmlStr.Append("<th scope= \"row\">");
            //    reader["Id"].ToString();
            //        htmlStr.Append(id + " ");
            //    htmlStr.Append("</th>");
            //    htmlStr.Append("<td>");
            //        htmlStr.Append(reader.GetString(1) + " ");
            //    htmlStr.Append("</td>");
            //    htmlStr.Append("<td>");
            //        htmlStr.Append(String.Format("{0:0.00}",
            //        Decimal.Parse(reader["Price"].ToString())));
            //    htmlStr.Append("</td>");
            //lblInfoText = htmlStr.ToString();
            //htmlStr.Append("<td>");
            //    htmlStr.Append("<a asp-page=\"Edit\" asp-route-id=" + id + "> Edytuj </a> | <a asp-page=\"Delete\" asp-route-id=" + id + ">Kasuj</a>");
            //    htmlStr.Append("</td>");
            //htmlStr.Append("<tr>");
        
            
            //lblInfoText = htmlStr.ToString();
        }

    }
}
