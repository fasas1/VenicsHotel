using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Application.Common.Interface
{
  public interface IUserRepository : IRepository<ApplicationUser>
  {
  }
    
}
