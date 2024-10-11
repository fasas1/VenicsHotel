using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Application.Common.Interface;
using VennyHotel.Domain.Entities;
using VennyHotel.Infrastructure.Data;

namespace VennyHotel.Infrastructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
    }
}
