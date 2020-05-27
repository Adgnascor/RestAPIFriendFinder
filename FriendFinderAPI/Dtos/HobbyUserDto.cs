using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class HobbyUserDto
    {
        [ForeignKey("HobbyID")]
        public int HobbyID { get; set; }
        public HobbyDto Hobby { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<Link> Links {get; set;}
    }
}