using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhND.Asm2.Repo;
using MinhND.Asm2.Repo.Models;

namespace MinhND.Asm2.Web.Pages
{
    public class IndexModel : PageModel
    {
        private UnitOfWork _unitOfWork;
        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Product EditPizza { get; set; }

        public List<Product> Product { get; set; }
        public string Username { get; private set; }

        public IActionResult OnGet()
        {
            Product = _unitOfWork.ProductRepository.Get(
                orderBy: q => q.OrderBy(d => d.ProductName),
                includeProperties: "Category,Supplier").ToList();
            return Page();
        }
    }
}
