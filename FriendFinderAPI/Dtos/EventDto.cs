namespace FriendFinderAPI.Dtos
{
    public class EventDto
    {
        public int EventID {get;set;}
        public string EventName {get;set;}
        public HobbyDto EventHobby {get;set;}
        public UserDto EventResposible {get;set;}
        public CityDto EventCity {get;set;}
    }
}