using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using FriendFinderAPI.Context;
using FriendFinderAPI.Services;
using FriendFinderAPI.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;

namespace FriendFinderAPI.Tests
{
    public class UnitTestLocations
    {
        
        [Fact]
        public async void GetLocationsTest()
        {
            //Arrange
             IList<Location> locations = GenerateLocations();
            var FriendFinderContextMock = new Mock<FriendFinderContext>();
            FriendFinderContextMock.Setup(l=>l.Locations).ReturnsDbSet(locations);

            var logger = Mock.Of<ILogger<LocationRepository>>();
            var locationRepository = new LocationRepository(FriendFinderContextMock.Object, logger);
            //Act
            var result = await locationRepository.GetLocations();
            //Assert
            Assert.Equal(2, (int)result.Length);
        }
        [Fact]
        public async void GetLocationTest()
        {
          //Arrange
             IList<Location> locations = GenerateLocations();
            var FriendFinderContextMock = new Mock<FriendFinderContext>();
            FriendFinderContextMock.Setup(l=>l.Locations).ReturnsDbSet(locations);

            var logger = Mock.Of<ILogger<LocationRepository>>();
            var locationRepository = new LocationRepository(FriendFinderContextMock.Object, logger);

            //Act 
            var result = await locationRepository.GetLocation(2);
            //Assert
            Assert.Equal("Fysiken", result.LocationName);
        }

         private static IList<Location> GenerateLocations()
        {
        return new List<Location>
        {
            new Location
            {
            LocationId = 1,
            LocationName = "Fjäderborgen",

            },
            new Location{
           
            LocationId = 2,
            LocationName = "Fysiken",

            }

        };
    }
}
}