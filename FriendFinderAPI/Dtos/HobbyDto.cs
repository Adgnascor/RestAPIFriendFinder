namespace FriendFinderAPI.Dtos
{
    public enum HobbyActivationLevelDto
    {
        Beginner,
        Intermediate,
        Skilled,
        Expert
    }
    public class HobbyDto
    {
        public HobbyActivationLevelDto HobbyActivationLevel { get; set; }
        [Key]
        public int HobbyID { get; set; }
        public string HobbyName { get; set; }
        public ICollection<HobbyUserDto> HobbyUsers { get; set; }
        public ICollection<HobbyLocationDto> HobbyLocations { get; set; }
    }
}