using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NET_PS_5.Models;

namespace NET_PS_5.Pages.Admin.Login
{
    public class UserLoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public string Message { get; set; }
        [BindProperty]
        public SiteUser user { get; set; }
        public UserLoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private bool ValidateUser(SiteUser user)
        {
            string myCompanyDBcs = _configuration.GetConnectionString("Projekt10");
            string hashLogin ="", hashPassword = "";
            byte[] _salt = new byte[128 / 8];

            SqlConnection con = new SqlConnection(myCompanyDBcs);
            string sql = "SELECT * FROM LoginData";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                hashLogin = reader.GetString(0);
                hashPassword = reader.GetString(1);
                _salt = (byte[])reader["Salt"];

            }
            reader.Close();
            con.Close();


            string userName = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.userName,
                salt: _salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
            string userPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.password,
                salt: _salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));


            if ((userName == hashLogin) && (userPassword == hashPassword))
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ValidateUser(user))
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.userName)
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
