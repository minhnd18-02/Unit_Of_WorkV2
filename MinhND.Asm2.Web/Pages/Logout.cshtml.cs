using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinhND.Asm2.Web.Pages
{
    public class LogoutModel : PageModel
    {
        public string Username { get; private set; }

        public IActionResult OnGet()
        {
            Username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(Username))
            {

                return RedirectToPage("/Login");
            }
            else
            {
                HttpContext.Session.Remove("Username");
                return RedirectToPage("/Index");
            }
        }
    }
}
