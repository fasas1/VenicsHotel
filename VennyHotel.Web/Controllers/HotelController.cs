using Microsoft.AspNetCore.Mvc;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;
using VennyHotel.Infrastructure.Repository;

namespace VennyHotel.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) 
        {
          _unitOfWork = unitOfWork;
         _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var hotels = _unitOfWork.Hotel.GetAll();
            return View(hotels);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel obj)
        {
          if(obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The Description cannot exactly match the Name");
            }
          if (ModelState.IsValid)
           { 
              if(obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Hotel");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);
                    
                    obj.ImageUrl = @"\images\Hotel\" + fileName;

                }
                else
                {
                    obj.ImageUrl = "https://placeholde.co/600x400";
                }

                _unitOfWork.Hotel.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "The hotel has been created.";
                return RedirectToAction("Index");
            }
               return View();
        }
        public IActionResult Update(int hotelId)
        {
            Hotel? obj = _unitOfWork.Hotel.Get(u => u.Id == hotelId);
            if(obj == null)
            {
               return RedirectToAction("Error","Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Hotel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Hotel");

                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\Hotel\" + fileName;

                }
                _unitOfWork.Hotel.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "The hotel has been updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int hotelId)
        {
            Hotel? obj = _unitOfWork.Hotel.Get(u => u.Id == hotelId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Hotel obj)
        {
            Hotel? objFromDb = _unitOfWork.Hotel.Get(u => u.Id == obj.Id);
            if (objFromDb != null)
            {

                _unitOfWork.Hotel.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The hotel has been deleted successfully!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "The hotel could not be deleted.";
            return View();
        }
    }
}
