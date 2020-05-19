namespace FriendFinderAPI.Models
{
    public class Event
    {
        public int EventID {get;set;}
        public string EventName {get;set;}

        // [ForeignKey("HobbyID")]
        // public int EventHobbyID { get; set; }
        public Hobby EventHobby {get;set;}

        // [ForeignKey("UserID")]
        // public int EventResposibleID { get; set; }
        public User EventResposible {get;set;}

        // [ForeignKey("CityID")]
        // public int EventCityID { get; set; }
        public City EventCity {get;set;}
    }
}