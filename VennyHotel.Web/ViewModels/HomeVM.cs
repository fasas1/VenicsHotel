﻿using VennyHotel.Domain.Entities;

namespace VennyHotel.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Hotel>? HotelList { get; set; }
        public DateOnly? CheckInDate { get; set; }
        public DateOnly? CheckOutDate { get; set; }
        public int Nights { get; set; }
    }
}
