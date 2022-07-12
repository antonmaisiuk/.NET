using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projekt.Models;

namespace Projekt.Pages.Login
{
    public class UserLoginModel:PageModel
    {

        private readonly IConfiguration _configuration;
        public string passwordFromDB = "";

        [BindProperty]
        public SiteUser user { get; set; }
        public UserLoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private bool ValidateUser(SiteUser user)
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

            string userPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.password,
                salt: _salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));

            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT Password FROM LoginData WHERE Login = @login";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@login", user.userName);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                passwordFromDB = reader.GetString(0);
                //UsersList.Add(new SiteUser
                //{
                //    userName = reader.GetString(0),
                //    password = reader.GetString(1),
                //    salt = (byte[])reader["Salt"],
                //    roleId = Int32.Parse(reader["roleId"].ToString()),
                //});
            }

            reader.Close();
            con.Close();



            SqlConnection con3 = new SqlConnection(myCompanyDBcs);
            string sql3 = "SELECT roleId FROM LoginData WHERE Login = @login";
            SqlCommand cmd3 = new SqlCommand(sql3, con3);
            cmd3.Parameters.AddWithValue("@login", user.userName);
            con3.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();

            while (reader3.Read())
            {
                user.roleId = Int32.Parse(reader3["roleId"].ToString());
            }
            reader3.Close();
            con3.Close();

            //string userName = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            //    password: user.userName,
            //    salt: UsersList.ElementAt(0).salt,
            //    prf: KeyDerivationPrf.HMACSHA256,
            //    iterationCount: 1000,
            //    numBytesRequested: 256 / 8));



            if (passwordFromDB == userPassword )
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            if (ValidateUser(user))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.userName),
                    new Claim(ClaimTypes.Surname, user.roleId.ToString() ),
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));

                

                CookieOptions cookieOptions = new CookieOptions();
                Response.Cookies.Append("RoleId", user.roleId.ToString(), cookieOptions);
                

                //ClaimsPrincipal us = HttpContext.;
                return RedirectToPage("../Admin/adminarea", user);
            }
            return Page();
        }

    }
}
