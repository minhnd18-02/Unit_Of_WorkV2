using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhND.Asm2.Repo;
using MinhND.Asm2.Repo.Models;

namespace MinhND.Asm2.Web.Pages
{
    public class CreateModel : PageModel
    {
        private UnitOfWork _unitOfWork;
        public CreateModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<Category> Category { get; set; }
        private string errorMessage;
        public IActionResult OnGet()
        {
            Category = _unitOfWork.CategoryRepository.Get().ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            int maxProductId = _unitOfWork.ProductRepository.Get().Max().ProductID;
            int productId = maxProductId + 1;

            try
            {
                Product newProduct = new Product
                {
                    ProductID = productId,
                    ProductName = Product.ProductName,
                    ProductImage = Product.ProductImage,
                    QuantityPerUnit = Product.QuantityPerUnit,
                    UnitPrice = Product.UnitPrice,
                };

                _unitOfWork.ProductRepository.AddEntity(newProduct);
                _unitOfWork.Complete();
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
