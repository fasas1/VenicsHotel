using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.BillingPortal;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Application.Common.Utility;
using VennyHotel.Domain.Entities;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;
using SessionService = Stripe.Checkout.SessionService;
using Session = Stripe.Checkout.Session;

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

            booking.TotalCost = hotel.Price * booking.Nights;
            booking.Status = SD.StatusPending;
            booking.BookingDate = DateTime.Now;

            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();




            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"booking/BookingConfirmation?bookingId={booking.Id}",
                CancelUrl = domain + $"booking/finalizeBooking?villaId={booking.HotelId}&checkInDate={booking.CheckInDate}&nights={booking.Nights}",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            options.LineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(booking.TotalCost * 100), // $20.50 => 2050
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = hotel.Name,
                        //Images = new List<string>()
                        //        {
                        //            Request.Scheme + "://" + Request.Host.Value + villa.ImageUrl.Replace('\\','/')
                        //        },

                    }

                },
                Quantity = 1
            });


            var service = new SessionService();



            Session session = service.Create(options);
            _unitOfWork.Booking.UpdateStripePaymentId(booking.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }


        [Authorize]

        public IActionResult BookingConfirmation(int bookingId)
        {
            return View(bookingId);
        }
    }
}
