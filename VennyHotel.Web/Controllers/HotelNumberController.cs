using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;
using VennyHotel.Infrastructure.Repository;
using VennyHotel.Web.ViewModels;

namespace VennyHotel.Web.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var hotelNumbers = _unitOfWork.HotelNumber.GetAll(includeProperties: "Hotel");
            return View(hotelNumbers);
        }
        public IActionResult Create()
        {
            HotelNumberVM hotelNumberVM = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
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
          bool roomNumberExist = _unitOfWork.HotelNumber.Any(u =>u.Hotel_Number == obj.HotelNumber.Hotel_Number);
          if (ModelState.IsValid && !roomNumberExist)
           {
                _unitOfWork.HotelNumber.Add(obj.HotelNumber);
                _unitOfWork.Save();
                TempData["success"] = "The hotel has been created.";
                return RedirectToAction("Index");
            }
            if (roomNumberExist)
            {
                TempData["error"] = "The Hotel Number already exist";
            }
            obj.HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
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
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                HotelNumber = _unitOfWork.HotelNumber.Get(u => u.Hotel_Number == hotelNumberId)
            };
            if(hotelNumberVM.HotelNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(hotelNumberVM);
        }

        [HttpPost]
        public IActionResult Update(HotelNumberVM hotelNumberVM)
        {
            
            if (ModelState.IsValid )
            {
                _unitOfWork.HotelNumber.Update(hotelNumberVM.HotelNumber);
                _unitOfWork.Save();
                TempData["success"] = "The hotel has been created.";
                return RedirectToAction(nameof(Index));
            }
          
            hotelNumberVM.HotelList= _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(hotelNumberVM);
        }

        public IActionResult Delete(int hotelNumberId)
        {
            HotelNumberVM hotelNumberVM = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                HotelNumber = _unitOfWork.HotelNumber.Get(u => u.Hotel_Number == hotelNumberId)
            };
            if (hotelNumberVM.HotelNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(hotelNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(HotelNumberVM hotelNumberVM)
        {
            HotelNumber? objFromDb = _unitOfWork.HotelNumber.Get
                           (u => u.Hotel_Number == hotelNumberVM.HotelNumber.Hotel_Number);
            if (objFromDb is not null)
            {

               _unitOfWork.HotelNumber.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The hotel has been deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            if (hotelNumberVM?.HotelNumber?.Hotel_Number == null)
            {
                TempData["error"] = "Invalid hotel number data.";
                return View();
            }

            TempData["error"] = "The hotel could not be deleted.";
            return View();
        }
    }
}
