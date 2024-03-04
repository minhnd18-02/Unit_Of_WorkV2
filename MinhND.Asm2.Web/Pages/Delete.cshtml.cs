using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhND.Asm2.Repo.Models;
using MinhND.Asm2.Repo;

namespace MinhND.Asm2.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private UnitOfWork _unitOfWork;
        public DeleteModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return RedirectToPage("/Index");
            }

            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Complete();
            return RedirectToPage("/Index");
        }
    }
}
