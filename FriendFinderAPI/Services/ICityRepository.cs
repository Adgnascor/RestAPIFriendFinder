using System.Threading.Tasks;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Services
{
    public interface ICityRepository : IRespository
    {
        Task<City[]> GetCities();
        Task<City> GetCity(int cityId);
        Task<City[]> GetCitiesByHobby(int hobbyId);

    }

}