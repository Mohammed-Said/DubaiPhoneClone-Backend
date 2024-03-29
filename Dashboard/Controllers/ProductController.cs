using DubaiPhoneClone.Application.services.product;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProuductService _productServices;
        public ProductController(IProuductService productService)
        {
            _productServices = productService;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productServices.GetAllProduct();   
            return View(product);
        }
    }
}
