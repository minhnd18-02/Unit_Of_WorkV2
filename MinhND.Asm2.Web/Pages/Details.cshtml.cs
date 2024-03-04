using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhND.Asm2.Repo;
using MinhND.Asm2.Repo.Models;

namespace MinhND.Asm2.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private UnitOfWork _unitOfWork;
        public DetailsModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Product Product { get; set; }
        public Category Category { get; set; }

        public IActionResult OnGet(int? id)
        {
            var product = _unitOfWork.ProductRepository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }
    }
}
