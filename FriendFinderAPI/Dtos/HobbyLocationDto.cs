using System.ComponentModel.DataAnnotations.Schema;

namespace FriendFinderAPI.Dtos
{
    public class HobbyLocationDto
    {
        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
        public HobbyDto Hobby { get; set; }

        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
    }
}