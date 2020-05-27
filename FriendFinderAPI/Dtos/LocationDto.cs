using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Dtos
{
    public class LocationDto
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        [ForeignKey("CityID")]
        public int LocationCityID { get; set; }
        public CityDto LocationCity { get; set; }

        public ICollection<HobbyLocationDto> HobbyLocations { get; set; }
        public IEnumerable<Link> Links {get; set;}
    }
}