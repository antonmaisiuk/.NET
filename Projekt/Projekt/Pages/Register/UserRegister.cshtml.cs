using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projekt.Models;

namespace NET_PS_5.Pages.Register
{
    public class UserRegisterModel:PageModel
    {
        public void OnGet()
        {
        }

        private readonly IConfiguration _configuration;
        public string Message { get; set; }
        [BindProperty]
        public SiteUser user { get; set; }
        public UserRegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                byte[] _salt = new byte[128 / 8];

                string myCompanyDBcs = _configuration.GetConnectionString("ProjektContext");

                SqlConnection con2 = new SqlConnection(myCompanyDBcs);
                string sql2 = "SELECT salt FROM LoginData";
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                con2.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    _salt = (byte[])reader2["Salt"];
                }
                reader2.Close();
                con2.Close();


                string login = user.userName;
                string password = user.password;

                // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
                //byte[] salt = new byte[128 / 8];
                //using (var rngCsp = new RNGCryptoServiceProvider())
                //{
                //    rngCsp.GetNonZeroBytes(salt);
                //}

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                //string hashedLogin = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                //    password: login,
                //    salt: _salt,
                //    prf: KeyDerivationPrf.HMACSHA256,
                //    iterationCount: 1000,
                //    numBytesRequested: 256 / 8));
                string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: _salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8));



                string myCompanyDB_connection_string = _configuration.GetConnectionString("ProjektContext");
                SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
                //string sql = "SELECT COUNT(*) FROM Product";
                string sql = "insert into LoginData(Login, Password) values(@Login, @Password)";
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    con.Open();
                    //cmd.CommandText = "SELECT COUNT(*) FROM Product";

                    //int count = (Int32)cmd.ExecuteScalar();
                    //cmd = new SqlCommand("insert into Product(Name,price) values(@Name, @Price)",con);
                    //cmd.CommandText = "insert into Product(Id,Name,price) values(@Id, @Name, @Price)";
                    //cmd.Parameters.AddWithValue("@Id", count + 1);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    //cmd.Parameters.AddWithValue("@Salt", salt);
                    int numAff = cmd.ExecuteNonQuery();
                    //lblInfoText += string.Format("<br />Dodano <b>{0}</b> record(s)<br />", numAff);
                }
                catch (SqlException exc)
                {
                    //lblInfoText += string.Format("<b>Blad:</b> {0}<br /><br />", exc.Message);
                }
                finally { con.Close(); }

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
