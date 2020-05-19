using FriendFinderAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendFinderAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using FriendFinderAPI.Services;
using System.Collections.Generic;

namespace FriendFinderAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FriendFinderContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(FriendFinderContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //GET:      api/v1.0/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var results = await _userRepository.GetUsers();
                return Ok(results);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //GET:      api/v1.0/users/n
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _userRepository.GetUser(id);
                
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByHobby(int id)
        {
            try
            {
                var results = await _userRepository.GetUsersByHobby(id);
                return Ok(results);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserTeacherByHobby(int id)
        {
            try
            {
                var results = await _userRepository.GetUserTeacherByHobby(id);
                return Ok(results);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        //POST:     api/v1.0/users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _context.Users.Add(user);
            //Important to not forget to save the changes in context when using POST
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new User{UserID = user.UserID}, user);
        }

        //PUT:      api/v1.0/users/n
        [HttpPut("{id}")]
        public ActionResult PutUser(int id, User user)
        {
            if(id != user.UserID)
                return BadRequest();
            
            _context.Entry(user).State = EntityState.Modified;
            /* Above code line makes the changes that we want in our context,
            which means that when we save context it will save those changes and get rid of previous value */

            _context.SaveChanges();

            // Because of the changes has already been done, we do not need to return any content.
            // That´s why we return method NoContent. So we kinda return a NoContent object. => Returns a "204 NoContent" Status

            return NoContent();
        }

        //DELETE        api/v1.0/users/n
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
                return NotFound();
            
            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }
        
    }
}