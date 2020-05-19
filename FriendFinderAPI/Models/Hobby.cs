using System.Collections.Generic;

using System.Collections.Generic;

namespace FriendFinderAPI.Models
{
    public enum HobbyActivationLevel 
        {
            Beginner,
            Intermediate,
            Skilled,
            Expert
        }
    public class Hobby
    {
        public HobbyActivationLevel HobbyActivationLevel{get;set;}
        [Key]
        public int HobbyID { get; set; }
        public string HobbyName { get; set; }
        public ICollection<HobbyUser> HobbyUsers { get; set; }
        public ICollection<HobbyLocation> HobbyLocations { get; set; }
    }
}