using EventsAPI.Models.Enums;

namespace EventsAPI.Models.DTOs.TicketDtos.RequestDtos
{
    public class UpdateTicketRequestDto
    {
        public TicketTypes TicketType { get; set; }


        public string Contact { get; set; }

        public int EventId { get; set; }
    }
}
