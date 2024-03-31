using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Application.services.product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using DubaiPhoneClone.Models;

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

                await _categoryServices.CreateCategory(category);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoryServices.GetCategoryByID(id);
                if (category == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(category.ImagePath))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, "Categories", category.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                await _categoryServices.DeleteCategory(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _categoryServices.GetCategoryByID(id);
            var category = new UpdateCategoryDTO
            {
                Id = categoryDetails.Id ,
                Name = categoryDetails.Name ,
                ArabicName = categoryDetails.ArabicName ,
                ImagePath = categoryDetails.ImagePath ,
                
            };
            return View(category);
        }
    
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateCategoryDTO updatedCategory)
        {
            try
            {
                if (updatedCategory.ImageFile != null && updatedCategory.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedCategory.ImageFile.FileName);
                    var directoryPath = Path.Combine(_environment.WebRootPath, "Categories");
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the directory exists, if not create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(updatedCategory.ImagePath))
                    {
                        var oldFilePath = Path.Combine(_environment.WebRootPath, "Categories", updatedCategory.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedCategory.ImageFile.CopyToAsync(stream);
                    }

                    // Set the image path to the relative path in wwwroot
                    updatedCategory.ImagePath = fileName;
                }

                // Update the product using the service
                await _categoryServices.UpdateCategory(updatedCategory);

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
                if (string.IsNullOrWhiteSpace(name))
                {
                    return RedirectToAction("Index");
                }
                var products = await _categoryServices.SearchName(name);

                return View("Index", products);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

    }
}
