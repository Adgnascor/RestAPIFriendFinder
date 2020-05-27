using System.ComponentModel.DataAnnotations.Schema;
using static FriendFinderAPI.Enums.Enums;

namespace FriendFinderAPI.Models
{
    public class HobbyUser
    {
        [ForeignKey("HobbyID")]
        public int HobbyID { get; set; }
        public Hobby Hobby { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User User { get; set; }
        public UserSkillLevel SkillLevel { get; set; }
    }
}