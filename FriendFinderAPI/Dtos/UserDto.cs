using System.Collections.Generic;

namespace FriendFinderAPI.Dtos
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserAdress { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserAge { get; set; }
        public bool UserIsTeacher { get; set; }
        public CityDto UserCity { get; set; }
        public ICollection<HobbyUserDto> HobbyUsers { get; set; }
    }
}