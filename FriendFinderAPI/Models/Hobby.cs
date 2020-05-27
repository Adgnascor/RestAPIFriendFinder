using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FriendFinderAPI.Enums;
using static FriendFinderAPI.Enums.Enums;

namespace FriendFinderAPI.Models
{
    public class Hobby
    {
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public ICollection<HobbyUser> HobbyUsers { get; set; }
        public ICollection<HobbyLocation> HobbyLocations { get; set; }
    }
}