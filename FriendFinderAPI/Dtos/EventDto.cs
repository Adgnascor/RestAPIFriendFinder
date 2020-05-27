using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class EventDto
    {
        public int EventId {get;set;}
        public string EventName {get;set;}

        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
        public HobbyDto Hobby {get;set;}
        
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public CityDto City { get;set; }
        public ICollection<EventUserDto> EventUsers { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}