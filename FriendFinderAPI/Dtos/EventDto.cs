using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class EventDto
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        [ForeignKey("HobbyID")]
        public int EventHobbyID { get; set; }
        public HobbyDto EventHobby { get; set; }
        [ForeignKey("CityID")]
        public int EventCityID { get; set; }
        public CityDto EventCity { get; set; }
        public ICollection<EventUserDto> EventUsers { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }

}