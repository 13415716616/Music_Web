using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Music_web.Views.Shared
{
    public class _LayoutModel : PageModel
    {
        public void OnGet()
        {
            var login_user=HttpContext.Session.GetInt32("Login");
            var lgoin_username = HttpContext.Session.GetString("User_name");
            var login_img = HttpContext.Session.GetString("img");
            ViewData["Login"] = login_user;
            ViewData["User_Name"] = lgoin_username.ToString();
            ViewData["img"] = login_img;
        }

        public void OnPost()
        {

        }
    }
}