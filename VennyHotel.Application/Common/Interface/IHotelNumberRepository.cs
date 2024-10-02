using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Application.Common.Interface
{
    public interface IHotelNumberRepository : IRepository<HotelNumber>
    {
      void Update(HotelNumber entity);
      
    }
}
