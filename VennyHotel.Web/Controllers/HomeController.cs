using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VennyHotel.Application.Common.Interface;
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
