using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt.Pages.Login
{
    public class UserLogOutModel : PageModel
    {        
        public async Task<IActionResult> OnGet()
        {

            //Response.Cookies.Delete("RoleId");
            CookieOptions cookieOptions = new CookieOptions();
            Response.Cookies.Append("RoleId", "3", cookieOptions);
            await HttpContext.SignOutAsync("CookieAuthentication");
            return this.RedirectToPage("/index");
        }
    }
}
