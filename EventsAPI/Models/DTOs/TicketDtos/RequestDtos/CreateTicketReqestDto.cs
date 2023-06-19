using EventsAPI.Models.Enums;
using EventsAPI.Models.ORMs;

namespace EventsAPI.Models.DTOs.TicketDtos.RequestDtos
{
    public class CreateTicketReqestDto
    {
       

        public TicketTypes TicketType { get; set; }


        public string Contact { get; set; }

        public int EventId { get; set; }
    }
}
