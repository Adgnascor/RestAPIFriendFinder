using AutoMapper;
using FriendFinderAPI.Dtos;
using FriendFinderAPI.Models;

namespace FriendFinderAPI.Configuration
{
    public class MappedProfile: Profile
    {
        public MappedProfile()
        {
            CreateMap<City, CityDto>()
                .ReverseMap();
                
            CreateMap<Event, EventDto>()
                .ReverseMap();
 
            CreateMap<EventUser, EventUserDto>()
                .ReverseMap();

            CreateMap<Hobby, HobbyDto>()
                .ReverseMap();

            CreateMap<HobbyLocation, HobbyLocationDto>()
                .ReverseMap();

            CreateMap<HobbyUser, HobbyUserDto>()
                .ReverseMap();
                
            CreateMap<Location, LocationDto>()
                .ReverseMap();
                
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
        
    }
}