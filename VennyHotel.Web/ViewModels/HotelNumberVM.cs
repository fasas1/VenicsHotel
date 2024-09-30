using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Web.ViewModels
{
    public class HotelNumberVM
    {
        public HotelNumber? HotelNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? HotelList { get; set; }
    }
}
