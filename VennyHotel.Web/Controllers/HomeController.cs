using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Application.Common.Utility;
using VennyHotel.Web.Models;
using VennyHotel.Web.ViewModels;

namespace VennyHotel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                HotelList = _unitOfWork.Hotel.GetAll(includeProperties:"HotelAmenity"),
                Nights =   1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now)
            };

            return View(homeVM);
        }
        [HttpPost]
        public IActionResult Index(HomeVM homeVM)
        {
          homeVM.HotelList = _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmenity");
            foreach(var hotel in homeVM.HotelList)
            {
               if(hotel.Id % 2 == 0)
                {
                    hotel.IsAvailable = false;
                }
            }
                 return View(homeVM);
        }

        public IActionResult GetHotelsByDate(int nights, DateOnly checkInDate)
        {
            var hotelList = _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmenity").ToList();
            var hotelNumberList = _unitOfWork.HotelNumber.GetAll().ToList();
            var bookedHotels = _unitOfWork.Booking.GetAll(u => u.Status== SD.StatusApproved ||
                     u.Status == SD.StatusCheckedIn).ToList();

            foreach (var hotel in hotelList)
            {
                 int roomAvailable = SD.HotelRoomsAvailable_Count(hotel.Id,hotelNumberList, checkInDate, nights, bookedHotels);

                 hotel.IsAvailable = roomAvailable > 0 ? true : false;
            }

            HomeVM homeVM = new()
            {
                HotelList = hotelList,
                Nights = nights,
                CheckInDate = checkInDate
            };

            return PartialView("_HotelList", homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
