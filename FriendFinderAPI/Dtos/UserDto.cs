using System.Collections.Generic;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAdress { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserAge { get; set; }
        public CityDto City { get; set; }
        public int CityId { get; set; }
        public ICollection<HobbyUserDto> HobbyUsers { get; set; }
        public ICollection<EventUserDto> EventUsers { get; set; }
        public IEnumerable<Link> Links {get; set;}
    }
}