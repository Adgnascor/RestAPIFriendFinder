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

        public async Task<User> GetUser(int userId)
        {
            _logger.LogInformation($"Getting user with id: {userId}");
            IQueryable<User> query = _context.Users
                                        .Include(u => u.HobbyUsers)
                                        .Include(u => u.EventUsers)
                                        .Where(u => u.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetUsersByHobby(int hobbyID)
        {
            _logger.LogInformation($"Getting Users for hobby with ID:{hobbyID}");
            IQueryable<User> query = _context.Users.Where(h=>h.HobbyUsers.Any(u=>u.Hobby.HobbyId == hobbyID));

            return await query.ToArrayAsync();
        }

        public Task<User[]> GetUsersByHobbyInCity(int hobbyID, int cityID)
        {
            throw new System.NotImplementedException();
        }
    }
}