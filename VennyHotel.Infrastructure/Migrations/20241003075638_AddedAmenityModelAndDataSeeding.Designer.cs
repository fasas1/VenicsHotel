﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VennyHotel.Infrastructure.Data;

#nullable disable

namespace VennyHotel.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241003075638_AddedAmenityModelAndDataSeeding")]
    partial class AddedAmenityModelAndDataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VennyHotel.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HotelId = 1,
                            Name = "Private Pool"
                        },
                        new
                        {
                            Id = 2,
                            HotelId = 1,
                            Name = "Microwave"
                        },
                        new
                        {
                            Id = 3,
                            HotelId = 1,
                            Name = "Private Balcony"
                        },
                        new
                        {
                            Id = 4,
                            HotelId = 1,
                            Name = "1 king bed and 1 sofa bed"
                        },
                        new
                        {
                            Id = 5,
                            HotelId = 2,
                            Name = "Private Plunge Pool"
                        },
                        new
                        {
                            Id = 6,
                            HotelId = 2,
                            Name = "Microwave and Mini Refrigerator"
                        },
                        new
                        {
                            Id = 7,
                            HotelId = 2,
                            Name = "Private Balcony"
                        },
                        new
                        {
                            Id = 8,
                            HotelId = 2,
                            Name = "king bed or 2 double beds"
                        },
                        new
                        {
                            Id = 9,
                            HotelId = 3,
                            Name = "Private Pool"
                        },
                        new
                        {
                            Id = 10,
                            HotelId = 3,
                            Name = "Jacuzzi"
                        },
                        new
                        {
                            Id = 11,
                            HotelId = 3,
                            Name = "Private Balcony"
                        });
                });

            modelBuilder.Entity("VennyHotel.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Landmark Suite",
                            Occupancy = 4,
                            Price = 400.0,
                            Sqft = 650
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x401",
                            Name = "Premium Pool Resort",
                            Occupancy = 3,
                            Price = 200.0,
                            Sqft = 350
                        },
                        new
                        {
                            Id = 3,
                            Description = "Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                            ImageUrl = "https://placehold.co/600x402",
                            Name = "Luxury Pool Hotel",
                            Occupancy = 4,
                            Price = 400.0,
                            Sqft = 750
                        });
                });

            modelBuilder.Entity("VennyHotel.Domain.Entities.HotelNumber", b =>
                {
                    b.Property<int>("Hotel_Number")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Hotel_Number");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelNumbers");

                    b.HasData(
                        new
                        {
                            Hotel_Number = 101,
                            HotelId = 1
                        },
                        new
                        {
                            Hotel_Number = 102,
                            HotelId = 1
                        },
                        new
                        {
                            Hotel_Number = 103,
                            HotelId = 1
                        },
                        new
                        {
                            Hotel_Number = 104,
                            HotelId = 1
                        },
                        new
                        {
                            Hotel_Number = 201,
                            HotelId = 2
                        },
                        new
                        {
                            Hotel_Number = 202,
                            HotelId = 2
                        },
                        new
                        {
                            Hotel_Number = 203,
                            HotelId = 2
                        },
                        new
                        {
                            Hotel_Number = 301,
                            HotelId = 3
                        },
                        new
                        {
                            Hotel_Number = 302,
                            HotelId = 3
                        });
                });

            modelBuilder.Entity("VennyHotel.Domain.Entities.Amenity", b =>
                {
                    b.HasOne("VennyHotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("VennyHotel.Domain.Entities.HotelNumber", b =>
                {
                    b.HasOne("VennyHotel.Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}