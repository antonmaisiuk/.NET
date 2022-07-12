using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projekt.Models;

namespace Projekt.Pages.Admin
{
    public class RolesListModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public RolesListModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Role> roleList;

        public void OnGet()
        {
            string myCompanyDBcs = _configuration.GetConnectionString("ProjektContext");

            SqlConnection con = new SqlConnection(myCompanyDBcs);
            SqlCommand cmd = new SqlCommand("selectRole", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roleList.Add(new Role
                {
                    id = Int32.Parse(reader["id"].ToString()),
                    name = reader.GetString(1)
                });
            }
            reader.Close();
            con.Close();
        }
    }
}
