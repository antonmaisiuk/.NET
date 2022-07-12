using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Projekt.Pages.Admin
{
    public class adminareaModel : PageModel
    {
        private readonly Projekt.Data.ProjektContext _context;
        private readonly IConfiguration _configuration;
        //public List<Claim> us;

        public adminareaModel(Projekt.Data.ProjektContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        //public adminareaModel(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}


        //public Claim claims = Claim

        //[BindProperty(SupportsGet = true)]
        //public int id { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string userName { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string password { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public byte[] salt { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public int? roleId { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public Role Role { get; set; }

        //int userId = _context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


        public IList<Part> Part { get; set; }
        //public Part Part { get; set; }
        //public string currentUser = 
        
        //public int getRoleId(string userName)
        //{
        //    int id = 0;
        //    string myCompanyDBcs = _configuration.GetConnectionString("ProjektContext");
        //    SqlConnection con = new SqlConnection(myCompanyDBcs);
        //    string sql = "SELECT Password FROM LoginData WHERE Login = " + userName /*@login"*/;
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    //cmd.Parameters.AddWithValue("@login", userName);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        id = Int32.Parse(reader["Login"].ToString());
        //    }

        //   return id;
        //}
        //public void OnGet()
        //{
        //    us = HttpContext.User.Claims.ToList();
        //}

        public string currentUser;
        public async Task OnGetAsync()
        {
            //id = getRoleId(userName);

            //User.Identities
            //currentUser = HttpContext.Request.Cookies["RoleId"];
             //= Response.Cookies["RoleId"]


            Part = await _context.Part
                .Include(p => p.Category).ToListAsync();
        }
    }
}
