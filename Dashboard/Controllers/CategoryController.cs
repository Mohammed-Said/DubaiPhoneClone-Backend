using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Application.services.product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IWebHostEnvironment _environment;

        public CategoryController(ICategoryServices categoryServices, IWebHostEnvironment environment)
        {
            _categoryServices = categoryServices;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryServices.GetAllCategory();
            return View(category);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO category)
        {
            try
            {
                if (category.ImageFile != null && category.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(category.ImageFile.FileName);
                    var directoryPath = Path.Combine(_environment.WebRootPath, "Categories");
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the directory exists, if not create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await category.ImageFile.CopyToAsync(stream);
                    }

                    // Set the image path to the relative path in wwwroot
                    category.ImagePath = fileName;
                }

                // Create the product using the service
                await _categoryServices.CreateCategory(category);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}
