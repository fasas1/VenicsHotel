using Microsoft.AspNetCore.Mvc;
using VennyHotel.Application.Common.Interface;
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
        public IActionResult FinalizedBooking(int hotelId, DateOnly checkInDate, int nights)
        {
            Booking booking = new Booking
            {
                HotelId = hotelId,
                Hotel = _unitOfWork.Hotel.Get(u=> u.Id == hotelId, includeProperties:"HotelAmenity"),
                CheckInDate = checkInDate,
                Nights = nights,
                CheckOutDate = checkInDate.AddDays(nights)
            };
            booking.TotalCost = booking.Hotel.Price * nights;
            return View(booking);
        }
    }
}
