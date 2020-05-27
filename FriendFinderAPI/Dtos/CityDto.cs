using System.Collections.Generic;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class CityDto
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }
        public string CityCounty { get; set; }
        public ICollection<UserDto> CityUsers { get; set; }
        public ICollection<LocationDto> CityLocations { get; set; }
        public IEnumerable<Link> Links {get; set;}
    }
}
