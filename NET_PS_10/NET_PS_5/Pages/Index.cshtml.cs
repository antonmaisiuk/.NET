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

namespace NET_PS_5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> productList = new List<Product>();
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
                productList.Add(new Product
                {
                    id = Int32.Parse(reader["Id"].ToString()),
                    name = reader.GetString(1),
                    price = Decimal.Parse(String.Format("{0:0.00}", Decimal.Parse(reader["Price"].ToString())))
                });
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
            }
            reader.Close(); 
            con.Close();
            //lblInfoText = htmlStr.ToString();
        }

    }
}
