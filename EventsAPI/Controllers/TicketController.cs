using EventsAPI.Models.DTOs.PlaceDtos.RequestDtos;
using EventsAPI.Models.DTOs.PlaceDtos.ResponseDtos;
using EventsAPI.Models.DTOs.TicketDtos.RequestDtos;
using EventsAPI.Models.DTOs.TicketDtos.ResponseDtos;
using EventsAPI.Models.ORMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        EventsDb context = new EventsDb();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllTicketsResponseDto> result = context.Tickets.Include(a => a.Event).Select(x => new GetAllTicketsResponseDto()
            {
                Id = x.Id,
                TicketType = x.TicketType,
                PurchaseDate = x.PurchaseDate,
                Contact = x.Contact,
                EventName = x.Event.EventName

            }).ToList();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No Ticket in the database!");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                return BadRequest("There is no Ticket in database with id:" + id);
            }
            else
            {
                return Ok(new GetTicketByIdResonseDto()
                {
                    Id = ticket.Id,
                    TicketType = ticket.TicketType,
                    PurchaseDate = ticket.PurchaseDate,
                    Contact = ticket.Contact,
                    EventName = ticket.Event.EventName

                });
            }
        }

        [HttpPost("create")]
        public IActionResult Create(CreateTicketReqestDto request)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(t => t.Event.Id == request.EventId);

            if (ticket != null)
            {
                Ticket ticket1 = new Ticket()
                {
                    TicketType = request.TicketType,
                    PurchaseDate = DateTime.Now,
                    Contact = request.Contact,
                    EventId = request.EventId

                };
                context.Tickets.Add(ticket1);
                context.SaveChanges();
                return Ok(request);

            }

            else
            {
                return BadRequest("There is no event with id= " + request.EventId);
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                return BadRequest("There is no ticket with id =" + id);
            }

            else
            {
                context.Remove(ticket);
                context.SaveChanges();
                return Ok("Ticket with id= " + id + " is deleted!");
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateTicketRequestDto request)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(x => x.Id == id);
            if (ticket == null)
            {
                return BadRequest("There is no ticket with id =" + id);
            }
            else
            {
                ticket.TicketType = request.TicketType;
                ticket.PurchaseDate = DateTime.Now;
                ticket.Contact = request.Contact;
                ticket.EventId = request.EventId;

                context.SaveChanges();
                return Ok(new UpdateTicketResponseDto
                {
                    TicketType = request.TicketType,
                    Contact = request.Contact,
                    EventId = request.EventId

                });

            }
        }



    }
}
