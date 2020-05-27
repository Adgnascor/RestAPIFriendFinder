using FriendFinderAPI.Context;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FriendFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Services
{
    public class CityRepository : Repository, ICityRepository
    {
        public CityRepository(FriendFinderContext context, ILogger<CityRepository> logger) : base(context, logger)
        {
        }
        public async Task<City> GetCity(int cityId)
        {
            _logger.LogInformation($"Getting City with id: {cityId}");
            IQueryable<City> query = _context.Cities.Where(u => u.CityId == cityId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<City[]> GetCities()
        {
            _logger.LogInformation("Getting Cities");
            IQueryable<City> query = _context.Cities;
            return await query.ToArrayAsync();
        }

        public async Task<City[]> GetCitiesByHobby(int hobbyId)
        {
            _logger.LogInformation($"Getting Cities Where hobby with id {hobbyId} exists");
             IQueryable<City> query = _context.Cities
                                        .Where(city=>city.Locations
                                        .Any(i=>i.HobbyLocations
                                        .Any(h=>h.Hobby.HobbyId == hobbyId)));

             return await query.ToArrayAsync();

        }
    }
}