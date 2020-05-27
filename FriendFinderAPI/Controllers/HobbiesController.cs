using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendFinderAPI.Context;
using FriendFinderAPI.Models;
using FriendFinderAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendFinderAPI.Dtos;
using AutoMapper;

namespace FriendFinderAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly IMapper _mapper;

        public HobbiesController(IHobbyRepository hobbyRepository, IMapper mapper)
        {
            _hobbyRepository = hobbyRepository;
            _mapper = mapper;

        }

        //GET:      api/v1.0/hobbies
        [HttpGet(Name = "GetHobbies")]
        public async Task<ActionResult<HobbyDto[]>> GetHobbies()
        {
            try
            {
                 
                var results = await _hobbyRepository.GetHobbies();
                var mappedResults = _mapper.Map<HobbyDto[]>(results);
                for(int i = 0; i<mappedResults.Length;i++)
                {
                    mappedResults[i].Links =CreateLinksForHobbies(mappedResults[i]);
                }
                return Ok(mappedResults);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET:      api/v1.0/hobbies/n
        [HttpGet("{hobbyId}", Name ="GetHobby")]
        public async Task<ActionResult<HobbyDto>> GetHobby(int hobbyId)
        {
            try
            {
                var result = await _hobbyRepository.GetHobby(hobbyId);
                
                if(result == null)
                    return NotFound();

                var mappedResult = _mapper.Map<HobbyDto>(result);
                mappedResult.Links = CreateLinksForHobbies(mappedResult);
                return Ok(mappedResult);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("hobby/{hobbyId}/city/{cityId}", Name ="GetHobbyByCity")]
        public async Task<ActionResult<HobbyDto[]>> GetHobbyByCity(int hobbyId, int cityId)
        {
            try
            {
                var result = await _hobbyRepository.GetHobbyByCity(hobbyId, cityId);
                if (result == null)
                    return NotFound();

                var mappedResults = _mapper.Map<HobbyDto[]>(result);
                for(int i = 0; i<mappedResults.Length;i++)
                {
                    mappedResults[i].Links =CreateLinksForHobbies(mappedResults[i]);
                }
                return Ok(mappedResults);            
                }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }
        [HttpGet("city/{hobbyId}", Name="GetHobbiesByCity")]
        public async Task<ActionResult<HobbyDto>> GetHobbiesByCity(int hobbyId)
        {
            try
            {
                var result = await _hobbyRepository.GetHobbiesByCity(hobbyId);
                var mappedResults = _mapper.Map<HobbyDto[]>(result);
                for(int i = 0; i<mappedResults.Length;i++)
                {
                    mappedResults[i].Links =CreateLinksForHobbies(mappedResults[i]);
                }
                return Ok(mappedResults);           
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("user/{hobbyId}", Name ="GetHobbiesByUser")]
        public async Task<ActionResult<HobbyDto>> GetHobbiesByUser(int hobbyId)
        {
            try
            {
                var result = await _hobbyRepository.GetHobbiesByUser(hobbyId);
                var mappedResults = _mapper.Map<HobbyDto[]>(result);
                for(int i = 0; i<mappedResults.Length;i++)
            {
                mappedResults[i].Links =CreateLinksForHobbies(mappedResults[i]);
            }
                return Ok(mappedResults); 
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("location/{locationId}", Name ="GetHobbiesByLocation")]
        public async Task<ActionResult<HobbyDto>> GetHobbiesByLocation(int locationId)
        {
            try
            {
                var result = await _hobbyRepository.GetHobbiesByLocation(locationId);
                var mappedResults = _mapper.Map<HobbyDto[]>(result);
                for(int i = 0; i<mappedResults.Length;i++)
            {
                mappedResults[i].Links = CreateLinksForHobbies(mappedResults[i]);
            }

                return Ok(mappedResults); 
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //POST: api/v1.0/hobbies
        [HttpPost(Name = "PostHobby")]
        public async Task<ActionResult<HobbyDto>> PostHobby(HobbyDto hobbyDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<HobbyDto>(hobbyDto);
                _hobbyRepository.Add(mappedEntity);

                if(await _hobbyRepository.Save())
                     return Created($"api/v1.0/cities/{mappedEntity.HobbyId}", _mapper.Map<HobbyDto>(mappedEntity));
                   
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //PUT:      api/v1.0/hobbies/n
        [HttpPut("{hobbyId}", Name= "PutHobby")]
        public async Task<ActionResult<HobbyDto>> PutHobby(int hobbyId, HobbyDto hobbyDto)
        {
            try
            {
                var oldHobby = await _hobbyRepository.GetHobby(hobbyId);
                if(oldHobby == null)
                    return NotFound($"There's no hobby with that id: {hobbyId}");

                var newHobby = _mapper.Map(hobbyDto, oldHobby);
                _hobbyRepository.Update(newHobby);

                if(await _hobbyRepository.Save())
                     return NoContent();

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //DELETE:       api/hobbies/n
        [HttpDelete("{hobbyId}", Name ="DeleteHobby")]
        public async Task<ActionResult> DeleteHobby(int hobbyId)
        {
            try
            {
                var hobby = await _hobbyRepository.GetHobby(hobbyId);
                if(hobby == null)
                    return NotFound($"Could not find any hobby with that id: {hobbyId}");

                _hobbyRepository.Delete(hobby);
                if(await _hobbyRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        private IEnumerable<Link> CreateLinksForHobbies(HobbyDto hobby)
        {
            var links = new[]
            {
                new Link
                {
                    Method = "GET",
                    Rel = "self",
                    Href = Url.Link("GetHobby", new {hobbyId = hobby.HobbyId}).ToLower()
                },
                new Link
                {
                    Method = "DELETE",
                    Rel = "self",
                    Href = Url.Link("DeleteHobby", new {hobbyId = hobby.HobbyId}).ToLower()
                },
                new Link
                {
                    Method = "PUT",
                    Rel = "self",
                    Href = Url.Link("PutHobby", new {hobbyId = hobby.HobbyId}).ToLower()
                }
            };
            return links;
        }
    }
}