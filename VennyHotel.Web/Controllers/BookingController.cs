using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Application.Common.Utility;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult FinalizedBooking(int hotelId, DateOnly checkInDate, int nights)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var UserId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ApplicationUser user = _unitOfWork.User.Get(u => u.Id == UserId);


            Booking booking = new Booking
            {
                HotelId = hotelId,
                Hotel = _unitOfWork.Hotel.Get(u => u.Id == hotelId, includeProperties: "HotelAmenity"),
                CheckInDate = checkInDate,
                Nights = nights,
                CheckOutDate = checkInDate.AddDays(nights),
                Phone = user.PhoneNumber,
                UserId = UserId,
                Name = user.Name,
                Email = user.Email
            };
            booking.TotalCost = booking.Hotel.Price * nights;
            return View(booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult FinalizedBooking(Booking booking)
        {
            var hotel = _unitOfWork.Hotel.Get(u => u.Id == booking.HotelId);

            booking.TotalCost = booking.Hotel.Price * booking.Nights;
            booking.Status = SD.StatusPending;
            booking.BookingDate = DateTime.Now;

            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();

            return RedirectToAction(nameof(BookingConfirmation), new { bookingId = booking.Id });
        }


        [Authorize]

        public IActionResult BookingConfirmation(int bookingId)
        {
            return View(bookingId);
        }
    }
}
