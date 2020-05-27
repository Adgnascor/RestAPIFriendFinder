using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendFinderAPI.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City { get; set; }
        
        public ICollection<HobbyLocation> HobbyLocations { get; set; }
        public IEnumerable<Link> Links{get;set;}
        
    }
}