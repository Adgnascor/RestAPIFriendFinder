using FriendFinderAPI.Context;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FriendFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Services
{
    public class LocationRepository : Repository, ILocationRepository
    {
        public LocationRepository(FriendFinderContext context, ILogger<LocationRepository> logger): base(context, logger)
        {
        }

        public async Task<Location> GetLocation(int locationId)
        {
            _logger.LogInformation($"Getting Location with ID: {locationId}");
            IQueryable<Location> query = _context.Locations.Where(l=> l.LocationId == locationId);

            return await query.FirstOrDefaultAsync();

        }

        public async Task<Location> GetLocationByHobby(int locationId, int hobbyId)
        {
            _logger.LogInformation($" Getting location with id{locationId} if it includes hobby with id {hobbyId}");
            IQueryable<Location> query = _context.Locations.Where(l=>l.LocationId == locationId)
            .Include(t=>t.HobbyLocations).Where(h=>h.HobbyLocations.Any(i=>i.HobbyId == hobbyId));

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Location[]> GetLocations()
        {
            _logger.LogInformation("Getting Locations");
            IQueryable<Location> query = _context.Locations;
            return await query.ToArrayAsync();
            
        }
        public async Task<Location[]> GetLocationsByHobby(int hobbyId)
        {
            _logger.LogInformation($" Getting locations for hobby with id {hobbyId}");
            IQueryable<Location> query = _context.Locations.Where(l=>l.HobbyLocations.Any(h=>h.Hobby.HobbyId == hobbyId));

            return await query.ToArrayAsync();

        }

        
        
        
    }
}