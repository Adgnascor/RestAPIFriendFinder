using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendFinderAPI.Context;
using FriendFinderAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendFinderAPI.Services;
using FriendFinderAPI.Dtos;
using AutoMapper;

namespace FriendFinderAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        //GET:      api/v1.0/events
        [HttpGet( Name = "GetEvents")]
        public async Task<ActionResult<EventDto[]>> GetEvents()
        {
            try
            {
                var results = await _eventRepository.GetEvents();
                var mappedResults = _mapper.Map<EventDto[]>(results);
                 for(int i = 0; i<mappedResults.Length;i++)
                 {
                    mappedResults[i].Links = CreateLinksGetAllEvents(mappedResults[i]);
                 }
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET:      api/v1.0/events/n

        [HttpGet("{eventId}",  Name = "GetEvent")]
        public async Task<ActionResult<EventDto>> GetEvent(int eventId)
        {
            try
            {
                var result = await _eventRepository.GetEvent(eventId);
                // result.EventLink = CreateLinksGetLocation(result);
                if (result == null)
                {
                    return NotFound();
                }
                var mappedResult = _mapper.Map<EventDto>(result);
                mappedResult.Links = CreateLinksGetAllEvents(mappedResult);
                
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("hobby/{hobbyId}",  Name = "GetEventsByHobby")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByHobby(int hobbyId)
        {
            try
            {
                var results = await _eventRepository.GetEventsByHobby(hobbyId);
                var mappedResults = _mapper.Map<IEnumerable<EventDto>>(results);
                return Ok(mappedResults);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("hobby/{hobbyId}/city/{cityid}", Name = "GetEventsByHobbyCity")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsByHobbyCity(int hobbyId, int cityid)
        {
            try
            {
                var results = await _eventRepository.GetEventsByHobbyCity(hobbyId, cityid);
                var mappedResults = _mapper.Map<IEnumerable<EventDto>>(results);
                return Ok(mappedResults);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("city{cityid}", Name = "GetEventsByCity")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsByCity(int cityid)
        {
            try
            {
                var results = await _eventRepository.GetEventsByCity(cityid);
                var mappedResults = _mapper.Map<IEnumerable<EventDto>>(results);
                return Ok(mappedResults);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //POST:      api/v1.0/events
        [HttpPost(Name = "PostEvent")]
        public async Task<ActionResult<EventDto>> PostEvents(EventDto eventDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Event>(eventDto);
                _eventRepository.Add(mappedEntity);

                if(await _eventRepository.Save())
                return Created($"api/v1.0/cities/{mappedEntity.EventId}", _mapper.Map<EventDto>(mappedEntity));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //PUT:      api/v1.0/events/n
        [HttpPut("{eventId}", Name = "PutEvent")]
        public async Task<ActionResult<EventDto>> PutEvent(int eventId, EventDto eventDto)
        {
            try
            {
                var oldEvent = await _eventRepository.GetEvent(eventId);
                if(oldEvent == null)
                    return NotFound($"Could not find the event with id {eventId}");
                
                var newEvent =_mapper.Map(eventDto, oldEvent);
                _eventRepository.Update(newEvent);

                if(await _eventRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //DELETE:       api/v1.0/events/n
        [HttpDelete("{eventId}", Name = "DeleteEvent")]
        public async Task<ActionResult> DeleteEvent(int eventId)
        {
            try
            {
                var eventToRemove = await _eventRepository.GetEvent(eventId);
                if(eventToRemove == null)
                    return NotFound($"Could not find an event with the id: {eventId}");
                
                _eventRepository.Delete(eventToRemove);
                if(await _eventRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }
        
        private IEnumerable<Link> CreateLinksGetAllEvents(EventDto events)
        {
            var links = new[]
            {
            new Link
            {
            Method = "GET",
            Rel = "self",
            Href = Url.Link("GetEvent", new {eventId = events.EventId}).ToLower()
            },
            new Link
            {
            Method = "DELETE",
            Rel = "self",
            Href = Url.Link("DeleteEvent", new {eventId = events.EventId}).ToLower()
            },
            new Link
            {
            Method = "PUT",
            Rel = "self",
            Href = Url.Link("PutEvent", new {eventId = events.EventId}).ToLower()
            },
            };
            return links;
        }

    }
}