﻿// <auto-generated />
using FriendFinderAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FriendFinderAPI.Migrations
{
    [DbContext(typeof(FriendFinderContext))]
    [Migration("20200526131938_RemoveTeacherColumn")]
    partial class RemoveTeacherColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FriendFinderAPI.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCounty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CityCountry = "Andorra",
                            CityCounty = "Andorra la Vella",
                            CityName = "Andorra la Vella"
                        },
                        new
                        {
                            CityID = 2,
                            CityCountry = "United Arab Emirates",
                            CityCounty = "Umm al Qaywayn",
                            CityName = "Umm al Qaywayn"
                        },
                        new
                        {
                            CityID = 3,
                            CityCountry = "United Arab Emirates",
                            CityCounty = "Raʼs al Khaymah",
                            CityName = "Ras al-Khaimah"
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventCityID")
                        .HasColumnType("int");

                    b.Property<int>("EventHobbyID")
                        .HasColumnType("int");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.HasIndex("EventCityID");

                    b.HasIndex("EventHobbyID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventID = 1,
                            EventCityID = 1,
                            EventHobbyID = 2,
                            EventName = "Lets Do some Awsome Curling"
                        },
                        new
                        {
                            EventID = 2,
                            EventCityID = 2,
                            EventHobbyID = 1,
                            EventName = "BookClub All About The Books"
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.EventUser", b =>
                {
                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("EventUserID")
                        .HasColumnType("int");

                    b.Property<bool>("UserIsResponsible")
                        .HasColumnType("bit");

                    b.HasKey("EventID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("EventUsers");

                    b.HasData(
                        new
                        {
                            EventID = 1,
                            UserID = 2,
                            EventUserID = 1,
                            UserIsResponsible = true
                        },
                        new
                        {
                            EventID = 1,
                            UserID = 1,
                            EventUserID = 2,
                            UserIsResponsible = false
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HobbyActivationLevel")
                        .HasColumnType("int");

                    b.Property<string>("HobbyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HobbyID");

                    b.ToTable("Hobbies");

                    b.HasData(
                        new
                        {
                            HobbyID = 1,
                            HobbyActivationLevel = 0,
                            HobbyName = "Abseiling"
                        },
                        new
                        {
                            HobbyID = 2,
                            HobbyActivationLevel = 0,
                            HobbyName = "Acting"
                        },
                        new
                        {
                            HobbyID = 3,
                            HobbyActivationLevel = 0,
                            HobbyName = "Action figure"
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.HobbyLocation", b =>
                {
                    b.Property<int>("HobbyID")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.HasKey("HobbyID", "LocationID");

                    b.HasIndex("LocationID");

                    b.ToTable("HobbyLocations");

                    b.HasData(
                        new
                        {
                            HobbyID = 1,
                            LocationID = 1
                        },
                        new
                        {
                            HobbyID = 2,
                            LocationID = 2
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.HobbyUser", b =>
                {
                    b.Property<int>("HobbyID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("HobbyID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("HobbyUsers");

                    b.HasData(
                        new
                        {
                            HobbyID = 1,
                            UserID = 1
                        },
                        new
                        {
                            HobbyID = 2,
                            UserID = 2
                        },
                        new
                        {
                            HobbyID = 3,
                            UserID = 3
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationCityID")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.HasIndex("LocationCityID");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationID = 1,
                            LocationCityID = 2,
                            LocationName = "Fjäderborgen"
                        },
                        new
                        {
                            LocationID = 2,
                            LocationCityID = 1,
                            LocationName = "The Castle With Zero Books..."
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAge")
                        .HasColumnType("int");

                    b.Property<int>("UserCityID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("UserCityID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            UserAdress = "Drottninggatan",
                            UserAge = 20,
                            UserCityID = 2,
                            UserName = "Sebbe",
                            UserPhoneNumber = "+46XXXXXXX"
                        },
                        new
                        {
                            UserID = 2,
                            UserAdress = "Kungsgatan",
                            UserAge = 22,
                            UserCityID = 1,
                            UserName = "Oskar",
                            UserPhoneNumber = "+46XXXXXXX2"
                        },
                        new
                        {
                            UserID = 3,
                            UserAdress = "MorTest",
                            UserAge = 28,
                            UserCityID = 1,
                            UserName = "William",
                            UserPhoneNumber = "+46XXXXXXX3"
                        });
                });

            modelBuilder.Entity("FriendFinderAPI.Models.Event", b =>
                {
                    b.HasOne("FriendFinderAPI.Models.City", "EventCity")
                        .WithMany()
                        .HasForeignKey("EventCityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FriendFinderAPI.Models.Hobby", "EventHobby")
                        .WithMany()
                        .HasForeignKey("EventHobbyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FriendFinderAPI.Models.EventUser", b =>
                {
                    b.HasOne("FriendFinderAPI.Models.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FriendFinderAPI.Models.User", "User")
                        .WithMany("EventUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("FriendFinderAPI.Models.HobbyLocation", b =>
                {
                    b.HasOne("FriendFinderAPI.Models.Hobby", "Hobby")
                        .WithMany("HobbyLocations")
                        .HasForeignKey("HobbyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FriendFinderAPI.Models.Location", "Location")
                        .WithMany("HobbyLocations")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FriendFinderAPI.Models.HobbyUser", b =>
                {
                    b.HasOne("FriendFinderAPI.Models.Hobby", "Hobby")
                        .WithMany("HobbyUsers")
                        .HasForeignKey("HobbyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FriendFinderAPI.Models.User", "User")
                        .WithMany("HobbyUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FriendFinderAPI.Models.Location", b =>
                {
                    b.HasOne("FriendFinderAPI.Models.City", "LocationCity")
                        .WithMany("CityLocations")
                        .HasForeignKey("LocationCityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FriendFinderAPI.Models.User", b =>
                {
                    b.HasOne("FriendFinderAPI.Models.City", "UserCity")
                        .WithMany("CityUsers")
                        .HasForeignKey("UserCityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
