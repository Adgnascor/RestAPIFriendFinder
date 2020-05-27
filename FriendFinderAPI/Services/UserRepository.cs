using System.Threading.Tasks;
using FriendFinderAPI.Models;
using Microsoft.EntityFrameworkCore;
using FriendFinderAPI.Context;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace FriendFinderAPI.Services
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(FriendFinderContext context, ILogger<LocationRepository> logger) : base(context, logger)
        {
        }
       
        public async Task<User[]> GetUsers()
        {
            _logger.LogInformation("Getting Users");
            IQueryable<User> query = _context.Users;

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUser(int userID)
        {
            _logger.LogInformation($"Getting user with id: {userID}");
            IQueryable<User> query = _context.Users
                                        .Include(u => u.HobbyUsers)
                                        .Include(u => u.EventUsers)
                                        .Where(u => u.UserID == userID);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetUsersByHobby(int hobbyID)
        {
            _logger.LogInformation($"Getting Users for hobby with ID:{hobbyID}");
            IQueryable<User> query = _context.Users.Where(h => h.HobbyUsers.Any(u => u.Hobby.HobbyID == hobbyID));

            return await query.ToArrayAsync();
        }

        // public async Task<User[]> GetUserTeacherByHobby(int hobbyID)
        // {
          
        //         _logger.LogInformation($"Getting Teachers for hobby with ID:{hobbyID}");
        //         IQueryable<User> query = _context.Users.Where(u=>u.HobbyUsers.Any(h=>h.Hobby.HobbyID == hobbyID) && u.UserIsTeacher == true);

        //         return await query.ToArrayAsync();
        // }

        public async Task<User[]> GetUsersByHobbyInCity(int hobbyID, int cityID)
        {
            _logger.LogInformation($"Getting Users for hobby with ID:{hobbyID}");
            IQueryable<User> query = _context.Users.Where(h=>h.HobbyUsers
                                                   .Any(u=>u.Hobby.HobbyID == hobbyID) && h.UserCityID == cityID);

            return await query.ToArrayAsync();  
        }

    }
}