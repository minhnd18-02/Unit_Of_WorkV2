using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhND.Asm2.Repo;
using MinhND.Asm2.Repo.Models;


namespace MinhND.Asm2.Web.Pages
{
    public class LoginModel : PageModel
    {
        private UnitOfWork _unitOfWork;

        public LoginModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Account Login { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var check = _unitOfWork.AccountRepository.Get(x => x.UserName.Equals(Login.UserName) && x.Password.Equals(Login.Password)).FirstOrDefault();
            if (check != null)
            {
                HttpContext.Session.SetString("Username", Login.UserName);
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}
