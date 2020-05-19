namespace FriendFinderAPI.Models
{
    public class HobbyLocation
    {
        // [ForeignKey("HobbyID")]
        // public int HobbyID { get; set; }
        public Hobby Hobby { get; set; }
        
        // [ForeignKey("LocationID")]
        // public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}