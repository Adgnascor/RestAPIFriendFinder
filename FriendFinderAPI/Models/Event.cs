using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendFinderAPI.Models
{
    public class Event
    {
        public int EventId {get;set;}
        public string EventName {get;set;}
        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
        public Hobby Hobby {get;set;}
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get;set; }
        public ICollection<EventUser> EventUsers { get; set; }

        public IEnumerable<Link> Links {get;set;}
    }
}