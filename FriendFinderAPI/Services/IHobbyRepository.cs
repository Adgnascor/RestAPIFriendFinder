using System.Threading.Tasks;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Services
{
    public interface IHobbyRepository : IRespository
    {
       Task<Hobby[]> GetHobbies();
       Task<Hobby> GetHobby(int CityId);
       Task<Hobby[]> GetHobbiesByUser(int userId);
       Task<Hobby> GetHobbyByCity(int hobbyId, int cityId);
       Task<Hobby[]> GetHobbiesByCity(int cityId);
       Task<Hobby[]> GetHobbiesByLocation(int locationId);
    }
}