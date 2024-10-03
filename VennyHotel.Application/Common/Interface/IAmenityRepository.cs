using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Application.Common.Interface
{
    public interface IAmenityRepository : IRepository<Amenity>
    {
      void Update(Amenity entity);

    }
}
