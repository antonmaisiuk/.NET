using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projekt.Models;

namespace Projekt.Pages.Admin
{
    public class AddUserModel : PageModel
    {
        private readonly IConfiguration _configuration;
        
        public AddUserModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [BindProperty]
        public SiteUser user { get; set; }


        public List<Role> roleList;

    



        public RedirectToPageResult OnGet()
        {
            //string myCompanyDBcs = _configuration.GetConnectionString("ProjektContext");

            //SqlConnection con = new SqlConnection(myCompanyDBcs);
            //SqlCommand cmd = new SqlCommand("addNewUser", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    roleList.Add(new Role
            //    {
            //        id = Int32.Parse(reader["id"].ToString()),
            //        name = reader.GetString(1)
            //    });
            //}
            //reader.Close();
            //con.Close();

            string currentUser = HttpContext.Request.Cookies["RoleId"];

            if (currentUser != "1")
            {
                return RedirectToPage("../Parts/Index");
            }
            return RedirectToPage();

        }
        public IActionResult OnPost()
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



            if (ModelState.IsValid)
            {

                //string myCompanyDBcs = _configuration.GetConnectionString("ProjektContext");

                SqlConnection con = new SqlConnection(myCompanyDBcs);
                SqlCommand cmd = new SqlCommand("addNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter login_SqlParam = new SqlParameter("@Login", SqlDbType.NVarChar, 20);
                login_SqlParam.Value = user.userName;
                cmd.Parameters.Add(login_SqlParam);

                SqlParameter pass_SqlParam = new SqlParameter("@Password", SqlDbType.NVarChar, 44);
                pass_SqlParam.Value = userPassword;
                cmd.Parameters.Add(pass_SqlParam);

                SqlParameter role_SqlParam = new SqlParameter("@RoleId", SqlDbType.Int);
                role_SqlParam.Value = user.roleId;
                cmd.Parameters.Add(role_SqlParam);

                SqlParameter id_SqlParam = new SqlParameter("@id", SqlDbType.Int);
                id_SqlParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id_SqlParam);

                con.Open();
                int numAff = cmd.ExecuteNonQuery();
                con.Close();

                return RedirectToPage("../Admin/adminarea");
            }
            return Page();
        }
    }
}
