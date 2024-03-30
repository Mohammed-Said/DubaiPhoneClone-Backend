using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Application.services.Brands;
using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Application.services.product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Dashboard.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProuductService _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IBrandServices _brandServices;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProuductService productService, ICategoryServices categoryServices, IBrandServices brandServices, IWebHostEnvironment environment)
        {
            _productServices = productService;
            _categoryServices = categoryServices;
            _brandServices = brandServices;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productServices.GetAllProduct();
            return View(product);
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _productServices.GetProductByID(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            var categoryDetails = await _categoryServices.GetCategoryByID(productDetails.CategoryId);

            ViewData["CategoryName"] = categoryDetails.Name;

            if (productDetails.BrandId.HasValue)
            {
                var brandDetails = await _brandServices.GetBrandByID(productDetails.BrandId.Value);
                ViewData["BrandName"] = brandDetails.Name;
            }
            else
            {
                ViewData["BrandName"] = "Not found";
            }
            return View(productDetails);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryList = await _categoryServices.GetAllCategory();
            ViewBag.BrandList = await _brandServices.GetAllBrand();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatingAndUpdatingProduct product)
        {
            try
            {
                if (product.ImageFile != null && product.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(product.ImageFile.FileName);
                    var directoryPath = Path.Combine(_environment.WebRootPath, "Products");
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the directory exists, if not create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(stream);
                    }

                    // Set the image path to the relative path in wwwroot
                    product.Cover = fileName;
                }

                // Create the product using the service
                await _productServices.CreateProduct(product);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _productServices.GetProductByID(id);
            var product = new CreatingAndUpdatingProduct
            {
                Id = productDetails.Id,
                ImageFile = productDetails.ImageFile,
                Cover = productDetails.Cover,
                ArabicName = productDetails.ArabicName,
                Name  = productDetails.Name,
                NormalPrice = productDetails.NormalPrice,
                SalePercent = productDetails.SalePrice,
                Stock = productDetails.Stock,
                Description = productDetails.Description,
                BrandId = productDetails.BrandId,
                CategoryId = productDetails.CategoryId,
            };
            ViewBag.CategoryList = await _categoryServices.GetAllCategory();

            ViewBag.BrandList = await _brandServices.GetAllBrand();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreatingAndUpdatingProduct updatedProduct)
        {
            try
            {
                if (updatedProduct.ImageFile != null && updatedProduct.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedProduct.ImageFile.FileName);
                    var directoryPath = Path.Combine(_environment.WebRootPath, "Products");
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the directory exists, if not create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(updatedProduct.Cover))
                    {
                        var oldFilePath = Path.Combine(_environment.WebRootPath, "Products", updatedProduct.Cover.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedProduct.ImageFile.CopyToAsync(stream);
                    }

                    // Set the image path to the relative path in wwwroot
                    updatedProduct.Cover = fileName;
                }

                // Update the product using the service
                await _productServices.UpdateProduct(updatedProduct);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productServices.GetProductByID(id);
                if (product == null)
                {
                    return NotFound();
                }

                // Delete the image file from the Products folder
                if (!string.IsNullOrEmpty(product.Cover))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, "Products", product.Cover.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // Delete the product using the service
                await _productServices.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Search(string name)
        {
            try
            { 
                if ( string.IsNullOrWhiteSpace(name))
                {
                    return RedirectToAction("Index");
                }
                var products = await _productServices.SearchName(name);
               
                return View("Index", products);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }

}
