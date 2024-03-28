using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhoneClone.Application.services.Brands;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandServices _brandservice;

        public BrandController(IBrandServices brandServices) {
         _brandservice=brandServices;
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
        
        public async Task <IActionResult> Delete(int id)
        {
            var brand = await _brandservice.GetBrandByID(id); // Assuming GetBrandByID is an asynchronous method
            var brandDto = new List<GetBrandDTO> { brand }; // Assuming GetBrandDTO is the correct type

            return View(brandDto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, GetBrandDTO dTO)
        {
            var Brands = await _brandservice.DeleteBrand(id);

            return Redirect("Index");
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var brand = await _brandservice.GetBrandByID(Id); // Assuming GetBrandByID is an asynchronous method
            var brandDto = new UpdateBrandDTO { Id=brand.Id,Name=brand.Name,ArabicName=brand.ArabicName,ImagePath=brand.ImagePath }; // Assuming GetBrandDTO is the correct type

            return View(brandDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit( UpdateBrandDTO dTO)
        {
           var updTO = new UpdateBrandDTO { Id = dTO.Id, Name = dTO.Name, ArabicName = dTO.ArabicName, ImagePath = dTO.ImagePath }; // Assuming GetBrandDTO is the correct type

            await _brandservice.UpdateBrand(updTO);

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDTO dTO)
        {
            
            await _brandservice.CreateBrand(dTO);

            return RedirectToAction("Index");
        }
    }
}
