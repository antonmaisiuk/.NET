using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NET_PS_9.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NET_PS_9.DAL
{
    public class ProductSqlDB : IProductDB
    {        
        public List<Product> productList = new List<Product>();
        public IConfiguration _configuration { get; }
        string project9_connection_string;
        public ProductSqlDB(IConfiguration configuration)
        {           
            _configuration = configuration;
            project9_connection_string = _configuration.GetConnectionString("Projekt9");
        }
        
        public void Add(Product _product)
        {
            SqlConnection con = new SqlConnection(project9_connection_string);
            //string sql = "SELECT COUNT(*) FROM Product";
            string sql = "insert into Products(name,price) values(@Name, @Price)";
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                
                cmd.Parameters.AddWithValue("@Name", _product.name);
                cmd.Parameters.AddWithValue("@Price", _product.price);
                int numAff = cmd.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                string lblInfoText = string.Format("<b>Blad:</b> {0}<br /><br />", exc.Message);
            }
            finally { con.Close(); }

        }

        public void Delete(int _id)
        {
            int idOfProduct = _id;
            
            SqlConnection con = new SqlConnection(project9_connection_string);
            string sql = "DELETE FROM Products WHERE Id = @idOfProduct";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idOfProduct", idOfProduct);
            
            con.Open();
            int numAff = cmd.ExecuteNonQuery();            
            
            con.Close();
        }
        public void Update(Product _product)
        {
            int idOfProduct = _product.id;
            SqlConnection con = new SqlConnection(project9_connection_string);
            string sql = "UPDATE Products SET name = @name, price = @price WHERE Id = @idOfProduct";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@idOfProduct", idOfProduct);
            cmd.Parameters.AddWithValue("@name", _product.name);
            cmd.Parameters.AddWithValue("@price", _product.price);
            
            con.Open();
            int numAff = cmd.ExecuteNonQuery();
                //lblInfoText += string.Format("<br />Edited <b>{0}</b> record(s)<br />", numAff);
            
            con.Close();
        }

        public Product Get(int _id)
        { return null; }

        public List<Product> List()
        {
            SqlConnection con = new SqlConnection(project9_connection_string);
            productList.Clear();
            string sql = "SELECT * FROM Products";
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

            }
            reader.Close();
            con.Close();

            return productList;
        }
    }
}
