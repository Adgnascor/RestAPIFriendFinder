using System.ComponentModel.DataAnnotations.Schema;

namespace FriendFinderAPI.Models
{
    public class HobbyLocation
    {
        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
        
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}