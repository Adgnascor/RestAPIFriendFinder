using System.Collections.Generic;
using FriendFinderAPI.Context;
using FriendFinderAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendFinderAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly FriendFinderContext _context;

        public EventsController(FriendFinderContext context) => _context = context;

        //GET:      api/v1.0/events
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents() => _context.Events;



        //GET:      api/v1.0/events/n
         [HttpGet("{id}")]
          public ActionResult<Event> GetEventsByID(int id)
        {
              var eventByID = _context.Events.Find(id);
              if(eventByID == null)
                 return NotFound();
            
              return eventByID;
              
          }
         //POST:      api/v1.0/events
         [HttpPost]
         public ActionResult<Event> PostEvents(Event eventPost)
         {
             _context.Events.Add(eventPost);
             //Important to dont forget that save the changes in context when using POST
             _context.SaveChanges();

             return CreatedAtAction("GetEvent", new Event{EventID = eventPost.EventID}, eventPost);
            
         }

         //PUT:      api/v1.0/events/n
         [HttpPut("{id}")]
         public ActionResult PutEvent(int id, Event eventPut)
        {
            if(id != eventPut.EventID)
                return BadRequest();
            
             _context.Entry(eventPut).State = EntityState.Modified;
             // Above code line make the changes to we want, in our context,
             // Which means that when we Save context it will save those changes and get rid of previous value

             _context.SaveChanges();

             // Because of that the changes already been done, we do not need to return any content.
             // That´s why we return method NoContent. So we kinda returns a NoContent object. => Returns a "204 NoContent" Status

            return NoContent();
         }

         //DELETE:       api/v1.0/events/n
         [HttpDelete("{id}")]
         public ActionResult<Event> DeleteEvent(int id)
        {
             var eventDel = _context.Events.Find(id);
             if(eventDel == null)
                return NotFound();
            
             _context.Events.Remove(eventDel);
             _context.SaveChanges();

            return eventDel;
         }

    }
}