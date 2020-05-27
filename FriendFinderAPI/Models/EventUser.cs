using System.ComponentModel.DataAnnotations.Schema;

namespace FriendFinderAPI.Models
{
    public class EventUser
    {
        public int EventUserId { get; set; }
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        public bool UserIsResponsible { get; set; }
    }
}