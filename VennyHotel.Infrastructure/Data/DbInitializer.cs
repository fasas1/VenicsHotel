//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VennyHotel.Application.Common.Interface;
//using VennyHotel.Domain.Entities;

//namespace VennyHotel.Infrastructure.Data
//{
//    public class DbInitializer : IDbInitializer
//    {

//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;
//        private readonly ApplicationDbContext _db;

//        public DbInitializer(
//            UserManager<ApplicationUser> userManager,
//            RoleManager<IdentityRole> roleManager,
//            ApplicationDbContext db)
//        {
//            _roleManager = roleManager;
//            _userManager = userManager;
//            _db = db;
//        }
//    }
//}
