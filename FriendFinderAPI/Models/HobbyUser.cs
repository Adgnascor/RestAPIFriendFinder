using System.ComponentModel.DataAnnotations.Schema;
using static FriendFinderAPI.Enums.Enums;

namespace FriendFinderAPI.Models
{
    public class HobbyUser
    {
        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        public UserSkillLevel SkillLevel { get; set; }
    }
}