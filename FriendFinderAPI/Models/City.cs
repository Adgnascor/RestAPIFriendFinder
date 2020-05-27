using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }
        public string CityCounty { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Location> Locations { get; set; }
        public IEnumerable<Link> Links {get;set;}
    }
}