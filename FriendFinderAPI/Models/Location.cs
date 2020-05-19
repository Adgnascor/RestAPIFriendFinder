using System.Collections.Generic;

using System.Collections.Generic;

namespace FriendFinderAPI.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        // [ForeignKey("CityID")]
        // public int LocationCityID { get; set; }
        public City LocationCity { get; set; }
        public ICollection<HobbyLocation> HobbyLocations { get; set; }
    }
}