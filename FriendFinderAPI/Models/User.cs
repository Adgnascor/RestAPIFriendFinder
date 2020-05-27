
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FriendFinderAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserAdress { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserAge { get; set; }
        public City UserCity { get; set; }
        public int UserCityID { get; set; }
        public ICollection<HobbyUser> HobbyUsers { get; set; }
        public ICollection<EventUser> EventUsers { get; set; }
        public ICollection<Link> UserLinks {get;set;}
    }
}