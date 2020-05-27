using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FriendFinderAPI.Models;
using System.Collections.Generic;

namespace FriendFinderAPI.Context
{
    public class FriendFinderContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public FriendFinderContext() { }
        public FriendFinderContext(IConfiguration config, DbContextOptions options) : base(options)
        {
            _configuration = config;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hobby> Hobbies { get; set; }
        public virtual DbSet<HobbyLocation> HobbyLocations { get; set; }
        public virtual DbSet<HobbyUser> HobbyUsers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventUser> EventUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                            .AddJsonFile("appsettings.json")
                                                            .Build();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FriendFinderAPIConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Link>();
            modelBuilder.Entity<HobbyUser>()
            .HasKey(hu => new { hu.HobbyId, hu.UserId });

            modelBuilder.Entity<HobbyUser>()
            .HasOne(hu => hu.Hobby)
            .WithMany(h => h.HobbyUsers)
            .HasForeignKey(hu => hu.HobbyId);

            modelBuilder.Entity<HobbyUser>()
            .HasOne(hu => hu.User)
            .WithMany(h => h.HobbyUsers)
            .HasForeignKey(hu => hu.UserId);

            modelBuilder.Entity<HobbyLocation>()
            .HasKey(hl => new { hl.HobbyId, hl.LocationId });

            modelBuilder.Entity<HobbyLocation>()
            .HasOne(hl => hl.Hobby)
            .WithMany(h => h.HobbyLocations)
            .HasForeignKey(hl => hl.HobbyId);

            modelBuilder.Entity<HobbyLocation>()
            .HasOne(hl => hl.Location)
            .WithMany(h => h.HobbyLocations)
            .HasForeignKey(hl => hl.LocationId);

            modelBuilder.Entity<EventUser>()
            .HasKey(bc => new { bc.EventId, bc.UserId });
            modelBuilder.Entity<EventUser>()
            .HasOne(bc => bc.Event)
            .WithMany(b => b.EventUsers)
            .HasForeignKey(bc => bc.EventId);
            modelBuilder.Entity<EventUser>()
            .HasOne(bc => bc.User)
            .WithMany(c => c.EventUsers)
            .HasForeignKey(bc => bc.UserId)
            .OnDelete(DeleteBehavior.NoAction);
            

            string citiesPath = @"../Documentation/DataSets/world-cities.txt";
            string[] lines = System.IO.File.ReadAllLines(citiesPath);
            List<City> tempCities = new List<City>();
            for (int i = 1; i < 4; i++)
            {
                string[] split = lines[i].Split(',');
                City city = new City
                {
                    CityId = i,
                    CityName = split[0],
                    CityCountry = split[1],
                    CityCounty = split[2],
                };
                tempCities.Add(city);
                modelBuilder.Entity<City>().HasData(city);

            }

            modelBuilder.Entity<User>()
            .HasData(new
            {
                UserId = 1,
                UserName = "Sebbe",
                UserAdress = "Drottninggatan",
                UserPhoneNumber = "+46XXXXXXX",
                UserAge = 20,
                CityId = 2
            }
            , new
            {
                UserId = 2,
                UserName = "Oskar",
                UserAdress = "Kungsgatan",
                UserPhoneNumber = "+46XXXXXXX2",
                UserAge = 22,
                CityId = 1
            }
            , new
            {
                UserId = 3,
                UserName = "William",
                UserAdress = "MorTest",
                UserPhoneNumber = "+46XXXXXXX3",
                UserAge = 28,
                CityId = 1
            });

            modelBuilder.Entity<Location>()
            .HasData(new
            {
                LocationId = 1,
                LocationName = "Fjäderborgen",
                CityId = 2,
            }
            , new
            {
                LocationId = 2,
                LocationName = "The Castle With Zero Books...",
                CityId = 1,
            });

            modelBuilder.Entity<Event>()
            .HasData(new
            {
                EventId = 1,
                EventName = "Lets Do some Awsome Curling",
                //EventHobbyId = 297,
                HobbyId = 2,
                CityID = 1,
            }
            , new
            {
                EventId = 2,
                EventName = "BookClub All About The Books",
                //EventHobbyId = 922,
                HobbyId = 1,
                CityID = 2,
            });

            modelBuilder.Entity<HobbyLocation>()
            .HasData(new
            {
                HobbyId = 1,
                LocationId = 1,
            }
            , new
            {
                HobbyId = 2,
                LocationId = 2,
            });

            modelBuilder.Entity<EventUser>()
            .HasData(new
            {
                EventUserID = 1,
                EventId = 1,
                UserId = 2,
                UserIsResponsible = true
            }
            , new
            {
                EventUserID = 2,
                EventId = 1,
                UserId = 1,
                UserIsResponsible = false
            });

            modelBuilder.Entity<HobbyUser>()
            .HasData(new
            {
                UserId = 1,
                HobbyId = 1,
            }
            , new
            {
                UserId = 2,
                HobbyId = 2,
            }
            , new
            {
                UserId = 3,
                HobbyId = 3,
            });


            string hobbiesPath = @"../Documentation/DataSets/HobbiesList.txt";
            string[] hobbies = System.IO.File.ReadAllLines(hobbiesPath);

            for (int i = 1; i < 4; i++)
            {
                Hobby hobby = new Hobby
                {
                    HobbyId = i,
                    HobbyName = hobbies[i],
                };
                modelBuilder.Entity<Hobby>().HasData(hobby);
            }
        }
    }
}