using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendFinderAPI.Models
{
    public class Event
    {
        public int EventID {get;set;}
        public string EventName {get;set;}
        [ForeignKey("HobbyID")]
        public int EventHobbyID { get; set; }
        public Hobby EventHobby {get;set;}
        [ForeignKey("CityID")]
        public int EventCityID { get; set; }
        public City EventCity { get;set; }
        public ICollection<EventUser> EventUsers { get; set; }

        public IEnumerable<Link> Links {get;set;}
    }
}