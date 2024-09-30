﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelNumber> HotelNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Landmark Suite",
                   Description = "Sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x400",
                   Occupancy = 4,
                   Price = 400,
                   Sqft = 650,
               },
             new Hotel
             {
                 Id = 2,
                 Name = "Premium Pool Resort",
                 Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                 ImageUrl = "https://placehold.co/600x401",
                 Occupancy = 3,
                 Price = 200,
                 Sqft = 350,
             },
             new Hotel
             {
                 Id = 3,
                 Name = "Luxury Pool Hotel",
                 Description = "Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                 ImageUrl = "https://placehold.co/600x402",
                 Occupancy = 4,
                 Price = 400,
                 Sqft = 750,
             });
            modelBuilder.Entity<HotelNumber>().HasData(
                new HotelNumber
                {
                    Hotel_Number = 101,
                    HotelId = 1
                },
                  new HotelNumber
                  {
                      Hotel_Number = 102,
                      HotelId = 1
                  },
                     new HotelNumber
                     {
                         Hotel_Number = 103,
                         HotelId = 1
                     },
                        new HotelNumber
                        {
                            Hotel_Number = 104,
                            HotelId = 1
                        },
                          new HotelNumber
                          {
                              Hotel_Number = 201,
                              HotelId = 2
                          },
                            new HotelNumber
                            {
                                Hotel_Number = 202,
                                HotelId = 2
                            },
                             new HotelNumber
                             {
                                 Hotel_Number = 203,
                                 HotelId = 2
                             },
                              new HotelNumber
                              {
                                  Hotel_Number = 301,
                                  HotelId = 3
                              },
                               new HotelNumber
                               {
                                   Hotel_Number = 302,
                                   HotelId = 3
                               }
                );
        }
    }
}
