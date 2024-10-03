using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VennyHotel.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
