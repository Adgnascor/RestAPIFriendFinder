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
    public class UnitTestCities
    {
        
    
        [Fact]
        public async void GetCitiesTest()
        {
           //Arrange
            IList<City> cities = GenerateCities();
            var FriendFinderContextMock = new Mock<FriendFinderContext>();
            FriendFinderContextMock.Setup(u=>u.Cities).ReturnsDbSet(cities);

            var logger = Mock.Of<ILogger<CityRepository>>();
            var cityRepository = new CityRepository(FriendFinderContextMock.Object, logger);

            //Act
            var result = await cityRepository.GetCities();

            //Assert
            Assert.Equal(2, (int)result.Length);
        }
        [Fact]
        public async void GetCityByIdTest()
        {
             //Arrange
            IList<City> cities = GenerateCities();
            var FriendFinderContextMock = new Mock<FriendFinderContext>();
            FriendFinderContextMock.Setup(u=>u.Cities).ReturnsDbSet(cities);

            var logger = Mock.Of<ILogger<CityRepository>>();
            var cityRepository = new CityRepository(FriendFinderContextMock.Object, logger);

            //Act
            var result = await cityRepository.GetCity(2);

            //Assert
            Assert.Equal(2, result.CityId);
        }
        private static IList<City> GenerateCities()
    {
        return new List<City>
        {
            new City
            {
            CityId = 1,
            CityName ="Göteborg",
            CityCountry = "Sweden",
            CityCounty = "Västra Götaland"
            },
            new City{
            CityId = 2,
            CityName ="Stockholm",
            CityCountry = "Sweden",
            CityCounty = "Stockholm"
            
            }

        };
    }

 }
 }