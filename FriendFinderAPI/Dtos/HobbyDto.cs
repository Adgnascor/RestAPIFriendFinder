using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FriendFinderAPI.Models;
using static FriendFinderAPI.Enums.Enums;

namespace FriendFinderAPI.Dtos
{
    public class HobbyDto
    {
        public HobbyActivationLevel HobbyActivationLevel{get;set;}
        [Key]
        public int HobbyID { get; set; }
        public string HobbyName { get; set; }
        public ICollection<HobbyUserDto> HobbyUsers { get; set; }
        public ICollection<HobbyLocationDto> HobbyLocations { get; set; }
        public IEnumerable<Link> Links {get; set;}
    }
}