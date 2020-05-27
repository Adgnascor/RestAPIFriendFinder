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
                    mappedResults[i].Links =CreateLinksGetAllHobbys(mappedResults[i]);
                }
                return Ok(mappedResults);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET:      api/v1.0/hobbies/n
        [HttpGet("{hobbyid}", Name ="GetHobby")]
        public async Task<ActionResult<HobbyDto>> GetHobby(int hobbyid)
        {
            try
            {
                var result = await _hobbyRepository.GetHobby(hobbyid);
                
                if(result == null)
                    return NotFound();

                var mappedResult = _mapper.Map<HobbyDto>(result);
                mappedResult.Links = CreateLinksGetAllHobbys(mappedResult);
                return Ok(mappedResult);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("hobby/{hobbyid}/city/{cityid}", Name ="GetHobbyByCity")]
        public async Task<ActionResult<HobbyDto[]>> GetHobbyByCity(int hobbyid, int cityid)
        {
            try
            {
                var result = await _hobbyRepository.GetHobbyByCity(hobbyid, cityid);
                if (result == null)
                    return NotFound();

                var mappedResults = _mapper.Map<HobbyDto[]>(result);
                for(int i = 0; i<mappedResults.Length;i++)
                {
                    mappedResults[i].Links =CreateLinksGetAllHobbys(mappedResults[i]);
                }
                return Ok(mappedResults);            
                }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }
        [HttpGet("city/{hobbyid}", Name="GetHobbiesByCity")]
        public async Task<ActionResult<HobbyDto>> GetHobbiesByCity(int hobbyid)
        {
            try
            {
                var result = await _hobbyRepository.GetHobbiesByCity(hobbyid);
                var mappedResults = _mapper.Map<HobbyDto[]>(result);
                for(int i = 0; i<mappedResults.Length;i++)
                {
                    mappedResults[i].Links =CreateLinksGetAllHobbys(mappedResults[i]);
                }
                return Ok(mappedResults);           
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("user/{hobbyid}", Name ="GetHobbiesByUser")]
        public async Task<ActionResult<HobbyDto>> GetHobbiesByUser(int hobbyid)
        {
                try
                {
                    var result = await _hobbyRepository.GetHobbiesByUser(hobbyid);
                    var mappedResults = _mapper.Map<HobbyDto[]>(result);
                    for(int i = 0; i<mappedResults.Length;i++)
                {
                    mappedResults[i].Links =CreateLinksGetAllHobbys(mappedResults[i]);
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
                     return Created($"api/v1.0/cities/{mappedEntity.HobbyID}", _mapper.Map<HobbyDto>(mappedEntity));
                   
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //PUT:      api/v1.0/hobbies/n
        [HttpPut("{hobbyid}", Name= "PutHobby")]
        public async Task<ActionResult<HobbyDto>> PutHobby(int hobbyID, HobbyDto hobbyDto)
        {
            try
            {
                var oldHobby = await _hobbyRepository.GetHobby(hobbyID);
                if(oldHobby == null)
                    return NotFound($"There's no hobby with that id: {hobbyID}");

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
        [HttpDelete("{hobbyid}", Name ="DeleteHobby")]
        public async Task<ActionResult> DeleteHobby(int hobbyID)
        {
            try
            {
                var hobby = await _hobbyRepository.GetHobby(hobbyID);
                if(hobby == null)
                    return NotFound($"Could not find any hobby with that id: {hobbyID}");

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

        
         private IEnumerable<Link> CreateLinksGetAllHobbys(HobbyDto hobby)
        {
            var links = new[]
            {
            new Link
            {
            Method = "GET",
            Rel = "self",
            Href = Url.Link("GetHobby", new {hobbyid = hobby.HobbyID})
            },
            new Link
            {
            Method = "DELETE",
            Rel = "self",
            Href = Url.Link("DeleteHobby", new {hobbyid = hobby.HobbyID})
            },
            new Link
            {
                Method = "PUT",
                Rel = "self",
                Href = Url.Link("PutHobby", new {hobbyid = hobby.HobbyID})
            }
            };
            return links;
        }
    }
}