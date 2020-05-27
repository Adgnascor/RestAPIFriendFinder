using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FriendFinderAPI.Models;
using static FriendFinderAPI.Enums.Enums;

namespace FriendFinderAPI.Dtos
{
    public class HobbyDto
    {
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public ICollection<HobbyUser> HobbyUsers { get; set; }
        public ICollection<HobbyLocation> HobbyLocations { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}