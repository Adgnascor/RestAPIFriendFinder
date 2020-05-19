namespace FriendFinderAPI.Dtos
{
    public class LocationDto
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public CityDto LocationCity { get; set; }
        public ICollection<HobbyLocationDto> HobbyLocations { get; set; }

    }
}