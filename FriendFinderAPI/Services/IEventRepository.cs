using System.Threading.Tasks;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Services
{
    public interface IEventRepository : IRespository
    {
         Task<Event> GetEvent(int eventId);

         Task<Event[]> GetEvents();

         Task<Event[]> GetEventsByHobby(int hobbyId);

         Task<Event[]> GetEventsByHobbyCity(int hobbyId, int cityId);

         Task<Event[]> GetEventsByCity(int cityId);
    }
}