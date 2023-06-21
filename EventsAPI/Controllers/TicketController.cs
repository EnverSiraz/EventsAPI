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
                EventName = x.Event.EventName,
                PurchaseId = x.PurchaseId,
                TicketPrice = x.TicketPrice,
                TicketQuantity  = x.TicketQuantity

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
                    EventName = ticket.Event.EventName,
                    PurchaseId = ticket.PurchaseId,
                    TicketPrice = ticket.TicketPrice,
                    TicketQuantity = ticket.TicketQuantity

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
                    EventId = request.EventId,
                    PurchaseId= request.PurchaseId,
                    TicketPrice = request.TicketPrice,
                    TicketQuantity = request.TicketQuantity

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
                ticket.EventId = request.EventId;
                ticket.TicketPrice = request.TicketPrice;
                ticket.TicketQuantity = request.TicketQuantity;
                ticket.PurchaseId= request.PurchaseId;

                context.SaveChanges();
                return Ok(new UpdateTicketResponseDto
                {
                    TicketType = request.TicketType,
                    EventId = request.EventId,
                    TicketPrice = request.TicketPrice,
                    TicketQuantity = request.TicketQuantity,
                    PurchaseId = request.PurchaseId

                });

            }
        }



    }
}
