using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }
        public string CityCounty { get; set; }
        public ICollection<User> CityUsers { get; set; }
        public ICollection<Location> CityLocations { get; set; }

        public IEnumerable<Link> Links {get;set;}
    }
}