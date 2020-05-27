using FriendFinderAPI.Context;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FriendFinderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Services
{
    public class EventRepository : Repository, IEventRepository
    {
     public EventRepository(FriendFinderContext context, ILogger<EventRepository> logger) : base(context,logger){

     }

      public async Task<Event> GetEvent(int eventId)
      {
          _logger.LogInformation($"Getting Event with id: {eventId}");
          Event query = await _context.Events.Where(e=>e.EventId == eventId).FirstOrDefaultAsync();

          return query;
      }  

      public async Task<Event[]> GetEvents()
      {
         _logger.LogInformation("Getting events");
         IQueryable<Event> query = _context.Events;
         return await query.ToArrayAsync();
      
      }

       public async Task<Event[]> GetEventsByHobby(int hobbyId)
       {
            _logger.LogInformation($"Getting Events for hobby with ID:{hobbyId}");
            IQueryable<Event> query = _context.Events.Where(h=>h.Hobby.HobbyId == hobbyId);

            return await query.ToArrayAsync();
       }
       public async Task<Event[]> GetEventsByHobbyCity(int hobbyId, int cityId)
       {
           _logger.LogInformation($"Getting Events for hobby with ID:{hobbyId} and in the location with id: {cityId}");
            IQueryable<Event> query = _context.Events.Where(h=>h.Hobby.HobbyId == hobbyId && h.City.CityId == cityId);

            return await query.ToArrayAsync();
       }
        public async Task<Event[]> GetEventsByCity(int cityId)
        {
            _logger.LogInformation($"Getting Events in location with location id{cityId}");
            IQueryable<Event> query = _context.Events.Where(l=>l.City.CityId == cityId);

            return await query.ToArrayAsync();
            
        }

    }
}