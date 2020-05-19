
using System.Collections.Generic;

using System.Collections.Generic;

namespace FriendFinderAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserAdress { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserAge { get; set; }
        public bool UserIsTeacher { get; set; }
        public City UserCity { get; set; }
        public ICollection<HobbyUser> HobbyUsers { get; set; }
    }
}