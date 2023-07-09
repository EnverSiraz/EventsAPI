using EventsAPI.Models.DTOs.EventDtos.RequestDtos;
using EventsAPI.Models.DTOs.EventDtos.ResponseDtos;
using EventsAPI.Models.DTOs.PlaceDtos.RequestDtos;
using EventsAPI.Models.DTOs.PlaceDtos.ResponseDtos;
using EventsAPI.Models.ORMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        EventsDb context = new EventsDb();


        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllEventsResponseDto> result = context.Events.Include(x => x.Place).Select(x => new GetAllEventsResponseDto()
            {
                Id = x.Id,
                EventName = x.EventName,
                EventDescription = x.EventDescription,
                EventCoverUrl = x.EventCoverUrl,
                EventTypes = x.EventTypes,
                EventStartTime = x.EventStartTime,
                EventEndTime = x.EventEndTime,
                PlaceId = x.PlaceId,
                IsFree = x.IsFree,
                PlaceName=x.Place.PlaceName
                

            }).ToList();

            if (result.Count > 0)   
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No Event in the database!");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Event newevent = context.Events.Include(x => x.Place).FirstOrDefault(x => x.Id == id);
            if (newevent == null)
            {
                return BadRequest("There is no Event in database with id:" + id);
            }
            else
            {
                return Ok(new GetEventsByIdResponseDto()
                {
                    Id = newevent.Id,
                    EventName=newevent.EventName,
                    EventDescription = newevent.EventDescription,
                    EventCoverUrl = newevent.EventCoverUrl,
                    EventTypes = newevent.EventTypes,
                    EventStartTime = newevent.EventStartTime,
                    EventEndTime = newevent.EventEndTime,
                    PlaceId = newevent.PlaceId,
                    IsFree=newevent.IsFree,
                    PlaceName= newevent.Place.PlaceName 
                });
            }
        }
        [HttpPost("create")]
        public IActionResult Create(CreateEventRequestDto request)
        {
            Event event1 = context.Events.FirstOrDefault(p => p.EventName.ToLower() == request.EventName.ToLower().Trim());

            if (event1 == null)
            {
                Event event2 = new Event()
                {
                    EventName = request.EventName,
                    EventDescription=request.EventDescription,
                    EventCoverUrl = request.EventCoverUrl,
                    EventTypes = request.EventTypes,
                    EventStartTime=request.EventStartTime,
                    EventEndTime=request.EventEndTime,
                    PlaceId = request.PlaceId,
                    IsFree=request.IsFree
                };
                context.Events.Add(event2);
                context.SaveChanges();
                return Ok(request);

            }

            else
            {
                return BadRequest(request.EventName + " already exists!");
            }

        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            Event event1 = context.Events.FirstOrDefault(x => x.Id == id);
            if (event1 == null)
            {
                return BadRequest("There is no event with id = " + id);
            }

            else
            {
                context.Remove(event1);
                context.SaveChanges();
                return Ok("Event with id= " + id + " is deleted!");
            }


        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateEventRequestDto request)
        {
            Event event1 = context.Events.FirstOrDefault(x => x.Id == id);
            if (event1 == null)
            {
                return BadRequest("There is no event with id = " + id);
            }
            else
            {
                if (context.Events.FirstOrDefault(x => x.EventName.ToLower() == request.EventName.ToLower()) != null)
                {
                    return BadRequest(request.EventName + " already exists!");
                }

                else
                {
                    event1.EventName= request.EventName;
                    event1.EventDescription= request.EventDescription;
                    event1.EventTypes= request.EventTypes;
                    event1.EventCoverUrl= request.EventCoverUrl;
                    event1.EventStartTime = request.EventStartTime;
                    event1.EventEndTime = request.EventEndTime;
                    event1.PlaceId=request.PlaceId;
                    event1.IsFree=request.IsFree;

                    context.SaveChanges();
                    return Ok(new UpdateEventsResponseDto
                    {
                        EventName= request.EventName,
                        EventDescription= request.EventDescription,
                        EventTypes= request.EventTypes,
                        EventCoverUrl= request.EventCoverUrl,
                        EventStartTime = request.EventStartTime,
                        EventEndTime=request.EventEndTime,
                        PlaceId=request.PlaceId,
                        IsFree=request.IsFree
                    });
                }
            }
        }



    }
}
