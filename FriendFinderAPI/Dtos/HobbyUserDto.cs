using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class HobbyUserDto
    {
        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
        public HobbyDto Hobby { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<Link> Links {get; set;}
    }
}