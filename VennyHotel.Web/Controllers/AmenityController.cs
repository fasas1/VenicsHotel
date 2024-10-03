using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;
using VennyHotel.Infrastructure.Repository;
using VennyHotel.Web.ViewModels;

namespace VennyHotel.Web.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AmenityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) 
        {
          _unitOfWork = unitOfWork;
         _webHostEnvironment = webHostEnvironment;
        }
  
        public IActionResult Index()
        {
            List<Amenity> AmenityList = _unitOfWork.Amenity.GetAll(includeProperties: "Hotel").ToList();
            return View(AmenityList);
        }
        public IActionResult Create()
        {

            AmenityVM AmenityVM = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(AmenityVM);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM AmenityVM)
        {
            //Remove some validations
            ModelState.Remove("Amenity.Hotel");


            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Add(AmenityVM.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(AmenityVM);
        }

        public IActionResult Update(int amenityId)
        {
            AmenityVM AmenityVM = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };
            if (AmenityVM.Amenity == null)
            {
                return RedirectToAction("error", "home");
            }
            return View(AmenityVM);
        }

        [HttpPost]
        public IActionResult Update(AmenityVM AmenityVM)
        {
            ModelState.Remove("Amenity.Villa");
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Update(AmenityVM.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(AmenityVM);
        }

        public IActionResult Delete(int amenityId)
        {
            AmenityVM AmenityVM = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };
            if (AmenityVM.Amenity == null)
            {
                return RedirectToAction("error", "home");
            }
            return View(AmenityVM);
        }

        [HttpPost]
        public IActionResult Delete(AmenityVM AmenityVM)
        {
            Amenity? objFromDb = _unitOfWork.Amenity.Get(x => x.Id == AmenityVM.Amenity.Id);
            if (objFromDb != null)
            {
                _unitOfWork.Amenity.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Amenity Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(AmenityVM);
        }
    }
}
