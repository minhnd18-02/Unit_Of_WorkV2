using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhND.Asm2.Repo;
using MinhND.Asm2.Repo.Models;

namespace MinhND.Asm2.Web.Pages
{
    public class EditModel : PageModel
    {
        private UnitOfWork _unitOfWork;
        public EditModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Product Product { get; set; }
        public IActionResult OnGet(int id)
        {
            var product = _unitOfWork.ProductRepository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }

            Product = product;  
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Index");
            }

            try
            {
                var check = _unitOfWork.ProductRepository.GetByID(id);
                if (check != null)
                {
                    check.ProductName = Product.ProductName;
                    check.ProductImage = Product.ProductImage;
                    check.QuantityPerUnit = Product.QuantityPerUnit;
                    check.UnitPrice = Product.UnitPrice;

                    Product = check;

                    _unitOfWork.ProductRepository.Update(check);
                    _unitOfWork.Complete();
                    return RedirectToPage("/Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
