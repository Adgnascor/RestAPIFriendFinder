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


    public class UnitTestUsers
    
    {
        [Fact]
        public async void GetUsersTest()
        {
            //Arrange
            IList<User> users = GenerateUsers();
            var FriendFinderContextMock = new Mock<FriendFinderContext>();
            FriendFinderContextMock.Setup(u=>u.Users).ReturnsDbSet(users);

            var logger = Mock.Of<ILogger<UserRepository>>();
            var userRepository = new UserRepository(FriendFinderContextMock.Object, logger);

            //Act
            var result = await userRepository.GetUsers();

            //Assert
            Assert.Equal(2, (int)result.Length);
        }

        [Fact]
        public async void GetUserByIDTest()
        {
            //Arrange
            IList<User> users = GenerateUsers();
            var FriendFinderContextMock = new Mock<FriendFinderContext>();
            FriendFinderContextMock.Setup(u=>u.Users).ReturnsDbSet(users);

            var logger = Mock.Of<ILogger<UserRepository>>();
            var userRepository = new UserRepository(FriendFinderContextMock.Object, logger);

            //Act
            var result = await userRepository.GetUser(1);

            //Assert
            Assert.Equal("Sebbe", result.UserName );
        }

    private static IList<User> GenerateUsers()
    {
        return new List<User>
        {
            new User
            {
            UserID = 1,
            UserName = "Sebbe",
            UserAdress = "Drottninggatan",
            UserPhoneNumber = "+46XXXXXXX",
            UserAge = 20,
            },
            new User{
            UserID = 2,
            UserName = "Oskar",
            UserAdress = "Kungsgatan",
            UserPhoneNumber = "+47XXXXXXX",
            UserAge = 23,
            
            }

        };
    }
}

}



