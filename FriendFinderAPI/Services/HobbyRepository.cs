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
        public async Task<Hobby> GetHobby(int HobbyID)
        {
            _logger.LogInformation($"Getting Hobby with id: {HobbyID}");
            IQueryable<Hobby> query = _context.Hobbies.Where(u => u.HobbyID == HobbyID);

            return await query.FirstOrDefaultAsync();
        }
       public async Task<Hobby[]> GetHobbies()
        {
            _logger.LogInformation("Getting Hobbies");
            IQueryable<Hobby> query = _context.Hobbies;
            return await query.ToArrayAsync();
        }
    }
}