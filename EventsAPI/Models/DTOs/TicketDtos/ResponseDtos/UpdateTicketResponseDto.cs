using EventsAPI.Models.Enums;

namespace EventsAPI.Models.DTOs.TicketDtos.ResponseDtos
{
    public class UpdateTicketResponseDto
    {
        public TicketTypes TicketType { get; set; }


        public string Contact { get; set; }

        public int EventId { get; set; }
    }
}
