using FriendFinderAPI.Context;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FriendFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Services
{
    public class HobbyRepository : Repository, IHobbyRepository
    {
        public HobbyRepository(FriendFinderContext context, ILogger<HobbyRepository> logger) : base(context, logger)
        {
        }
        public async Task<Hobby> GetHobby(int hobbyId)
        {
            _logger.LogInformation($"Getting Hobby with id: {hobbyId}");
            IQueryable<Hobby> query = _context.Hobbies
                                        .Where(u => u.HobbyId == hobbyId);

            return await query.FirstOrDefaultAsync();
        }
       public async Task<Hobby[]> GetHobbies()
        {
            _logger.LogInformation("Getting Hobbies");
            IQueryable<Hobby> query = _context.Hobbies;
            return await query.ToArrayAsync();
        }

        public async Task<Hobby> GetHobbyByCity(int hobbyId, int cityId)
        {
             _logger.LogInformation($"Getting Hobby in city with id: {cityId}");
             IQueryable<Hobby> query = _context.Hobbies
                                        .Where(h=>h.HobbyLocations
                                        .Any(l=>l.Location.City.CityId == cityId) && h.HobbyId ==hobbyId);

             return await query.FirstOrDefaultAsync();
        }

        public async Task<Hobby[]> GetHobbiesByCity(int cityId)
        {
            _logger.LogInformation($"Getting Hobbies in city with id: {cityId}");
            IQueryable<Hobby> query = _context.Hobbies
                                        .Where(h=>h.HobbyLocations
                                        .Any(l=>l.Location.City.CityId == cityId));

            return await query.ToArrayAsync();
        }

        public async Task<Hobby[]> GetHobbiesByUser(int userId)
        {
            _logger.LogInformation($"Getting Hobbies in city with id: {userId}");
            IQueryable<Hobby> query = _context.Hobbies
                                        .Where(h=>h.HobbyUsers
                                        .Any(u=>u.UserId == userId));

            return await query.ToArrayAsync();

        }
        public async Task<Hobby[]> GetHobbiesByLocation(int locationId)
        {
            _logger.LogInformation($"Getting Hobbies in location with id: {locationId}");
            IQueryable<Hobby> query = _context.Hobbies
                                    .Where(hl=>hl.HobbyLocations
                                    .Any(x => x.LocationId == locationId));

            return await query.ToArrayAsync();

        }
    }
}