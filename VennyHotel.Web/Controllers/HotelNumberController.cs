using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;
using VennyHotel.Web.ViewModels;

namespace VennyHotel.Web.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HotelNumberController(ApplicationDbContext db) 
        {
          _db = db;
        }
        public IActionResult Index()
        {
            var hotelNumbers = _db.HotelNumbers.Include(u=>u.Hotel).ToList();
            return View(hotelNumbers);
        }
        public IActionResult Create()
        {
            HotelNumberVM hotelNumberVM = new()
            {
                HotelList = _db.Hotels.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(hotelNumberVM);
        }

        [HttpPost]
        public IActionResult Create(HotelNumberVM obj)
        {
          bool roomNumberExist = _db.HotelNumbers.Any(u =>u.Hotel_Number == obj.HotelNumber.Hotel_Number);
          if (ModelState.IsValid && !roomNumberExist)
           {
                _db.HotelNumbers.Add(obj.HotelNumber);
                _db.SaveChanges();
                TempData["success"] = "The hotel has been created.";
                return RedirectToAction("Index");
            }
            if (roomNumberExist)
            {
                TempData["error"] = "The Hotel Number already exist";
            }
            obj.HotelList = _db.Hotels.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
               return View(obj);
        }
        public IActionResult Update(int hotelNumberId)
        {
            HotelNumberVM hotelNumberVM = new()
            {
                HotelList = _db.Hotels.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                HotelNumber = _db.HotelNumbers.FirstOrDefault(u => u.Hotel_Number == hotelNumberId)
            };
            if(hotelNumberVM.HotelNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(hotelNumberVM);
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
