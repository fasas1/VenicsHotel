using Microsoft.AspNetCore.Mvc;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;

namespace VennyHotel.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HotelController(ApplicationDbContext db) 
        {
          _db = db;
        }
        public IActionResult Index()
        {
            var hotels = _db.Hotels.ToList();
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
                _db.Hotels.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The hotel has been created.";
                return RedirectToAction("Index");
            }
               return View();
        }
        public IActionResult Update(int hotelId)
        {
            Hotel? obj = _db.Hotels.FirstOrDefault(u => u.Id == hotelId);
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
                _db.Hotels.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The hotel has been updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int hotelId)
        {
            Hotel? obj = _db.Hotels.FirstOrDefault(u => u.Id == hotelId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Hotel obj)
        {
            Hotel? objFromDb = _db.Hotels.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {

                _db.Hotels.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "The hotel has been deleted successfully!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "The hotel could not be deleted.";
            return View();
        }
    }
}
