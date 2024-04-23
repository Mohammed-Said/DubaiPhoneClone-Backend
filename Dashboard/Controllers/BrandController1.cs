using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Application.services.Brands;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class BrandController : Controller
    {
        private readonly IBrandServices _brandservice;
        private readonly IWebHostEnvironment _environment;


        public BrandController(IBrandServices brandServices , IWebHostEnvironment environment) 
        {
            _brandservice = brandServices;
            _environment =  environment;
        }
        public async Task <IActionResult> Index()
        {
            var Brands=await _brandservice.GetAllBrand();
            if (Brands == null || Brands.Count == 0)
            {
                return NoContent();
            }
            return View(Brands);
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var brand = await _brandservice.GetBrandByID(id);
                if (brand == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(brand.ImagePath))
                {
                    var oldFilePath = Path.Combine(_environment.WebRootPath, "Brands", brand.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                await _brandservice.DeleteBrand(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandservice.GetBrandByID(id); 
            var brandDto = new UpdateBrandDTO 
            { Id = brand.Id, Name = brand.Name, ArabicName = brand.ArabicName, ImagePath = brand.ImagePath }; // Assuming GetBrandDTO is the correct type

            return View(brandDto);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateBrandDTO updatedBrand)
        {
            try
            {
                if (updatedBrand.ImageFile != null && updatedBrand.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(updatedBrand.ImageFile.FileName);
                    var directoryPath = Path.Combine(_environment.WebRootPath, "Brands");
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the directory exists, if not create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(updatedBrand.ImagePath))
                    {
                        var oldFilePath = Path.Combine(_environment.WebRootPath, "Brands", updatedBrand.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await updatedBrand.ImageFile.CopyToAsync(stream);
                    }

                    // Set the image path to the relative path in wwwroot
                    updatedBrand.ImagePath = fileName;
                }

                await _brandservice.UpdateBrand(updatedBrand);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDTO brand)
        {
            try
            {
                if (brand.ImageFile != null && brand.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(brand.ImageFile.FileName);
                    var directoryPath = Path.Combine(_environment.WebRootPath, "Brands");
                    var filePath = Path.Combine(directoryPath, fileName);

                    // Check if the directory exists, if not create it
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await brand.ImageFile.CopyToAsync(stream);
                    }

                    // Set the image path to the relative path in wwwroot
                    brand.ImagePath = fileName;
                }

                await _brandservice.CreateBrand(brand);

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
                var brands = await _brandservice.SearchName(name);

                return View("Index", brands);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


    }
}
