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
                .ReverseMap()
                .ForPath(x => x.Links, x => x.Ignore());
                
            CreateMap<Event, EventDto>()
                .ReverseMap()
                .ForPath(x => x.Links, x => x.Ignore());
 
            CreateMap<EventUser, EventUserDto>()
                .ReverseMap();

            CreateMap<Hobby, HobbyDto>()
                .ReverseMap()
                .ForPath(x => x.Links, x => x.Ignore());

            CreateMap<HobbyLocation, HobbyLocationDto>()
                .ReverseMap();

            CreateMap<HobbyUser, HobbyUserDto>()
                .ReverseMap();
                
                
            CreateMap<Location, LocationDto>()
                .ReverseMap()
                .ForPath(x => x.Links, x => x.Ignore());
                
            CreateMap<User, UserDto>()
                .ReverseMap()
               .ForPath(x => x.Links, x => x.Ignore());
        }
        
    }
}