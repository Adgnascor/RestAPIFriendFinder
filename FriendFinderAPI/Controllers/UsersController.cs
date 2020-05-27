using FriendFinderAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendFinderAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using FriendFinderAPI.Services;
using System.Collections.Generic;
using FriendFinderAPI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace FriendFinderAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private LinkGenerator _linkGenerator;
        public UsersController(IUserRepository userRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        //GET:      api/v1.0/users
        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                var results = await _userRepository.GetUsers();
                if (results == null)
                {
                    return NotFound();
                }
                var mappedResults = _mapper.Map<IEnumerable<UserDto>>(results);
                for (int i = 0; i < results.Length; i++)
                {
                    results[i].UserLinks = CreateLinksGetAllUsers(results[i]);
                }

                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET:      api/v1.0/user/n
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                var result = await _userRepository.GetUser(id);
                if (result == null)
                {
                    return NotFound();
                }

                result.UserLinks = CreateLinksGetUser(result);
                var mappedResult = _mapper.Map<UserDto>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("hobby/{id}", Name = "GetUserByHobby")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByHobby(int id)
        {
            try
            {
                var results = await _userRepository.GetUsersByHobby(id);
                if (results == null)
                {
                    return NotFound();
                }
                
                var mappedResults = _mapper.Map<IEnumerable<UserDto>>(results);
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        // [HttpGet("teacher/hobby/{id}", Name = "GetUserTeacherByHobby")]
        // public async Task<ActionResult<IEnumerable<UserDto>>> GetUserTeacherByHobby(int id)
        // {
        //     try
        //     {
        //         var results = await _userRepository.GetUserTeacherByHobby(id);
        //         var mappedResults = _mapper.Map<IEnumerable<UserDto>>(results);
        //         return Ok(mappedResults);    
        //     }
        //     catch(Exception e)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
        //     }
        // }

        [HttpGet("hobby/{hobbyId}/city/{cityId}", Name = "GetUserByHobbyInCity")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByHobbyInCity(int hobbyId, int cityId)
        {
            try
            {
                var results = await _userRepository.GetUsersByHobbyInCity(hobbyId,cityId);
                if (results == null)
                {
                    return NotFound();
                }
                var mappedResults = _mapper.Map<IEnumerable<UserDto>>(results);
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //POST:     api/v1.0/users
        [HttpPost(Name = "PostUser")]
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<User>(userDto);
                _userRepository.Add(mappedEntity);
                if (await _userRepository.Save())
                    return Created($"api/v1.0/users/{mappedEntity.UserID}", _mapper.Map<UserDto>(mappedEntity));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }

        //PUT:      api/v1.0/users/n
        [HttpPut("{userID}", Name = "PutUser")]
        public async Task<ActionResult<UserDto>> PutUser(int userID, UserDto userDto)
        {
            try
            {
                var oldUser = await _userRepository.GetUser(userID);
                if (oldUser == null)
                    return NotFound($"Can't find any user with that id: {userID}");

                var newUser = _mapper.Map(userDto, oldUser);
                _userRepository.Update(newUser);
                if (await _userRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }

            return BadRequest();
        }

        //DELETE        api/v1.0/users/n
        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);
                if (user == null)
                    return NotFound($"We could not find a user with that id: {id}");

                _userRepository.Delete(user);
                if (await _userRepository.Save())
                    return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }

            return BadRequest();
        }
        private ICollection<Link> CreateLinksGetUser(User user)
        {
            var links = new[]
            {
            new Link
            {
            Method = "GET",
            Rel = "self",
            Href = Url.Link("GetUser", new {id = user.UserID})
            },
            new Link
            {
            Method = "DELETE",
            Rel = "self",
            Href = Url.Link("DeleteUser", new {id = user.UserID})
            },
            new Link
            {
            Method = "Put",
            Rel = "self",
            Href = Url.Link("PutUser", new {id = user.UserID})
            },
              new Link
            {
            Method = "GET",
            Rel ="CityUser",
            Href = Url.Link("GetCity", new {id = user.UserCityID})
            },
            new Link
            {
                Method = "GET",
                Rel ="UserHobbies",
                Href = Url.Link("GetHobbiesByUser", new {id = user.UserID}).ToLower()
            }
            };
            return links;
        }
        private ICollection<Link> CreateLinksGetAllUsers(User user)
        {
            var links = new[]
            {
            new Link
            {
            Method = "GET",
            Rel = "self",
            Href = Url.Link("GetUser",new {id = user.UserID} ).ToLower()
            },
            new Link
            {
                Method = "GET",
                Rel ="CityUser",
                Href = Url.Link("GetCity", new {id = user.UserCityID}).ToLower()
            },
            new Link
            {
                Method = "GET",
                Rel ="UserHobbies",
                Href = Url.Link("GetHobbiesByUser", new {id = user.UserID}).ToLower()
            }

            };
            return links;
        }
    }
}