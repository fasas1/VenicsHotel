using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;

namespace VennyHotel.Infrastructure.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
