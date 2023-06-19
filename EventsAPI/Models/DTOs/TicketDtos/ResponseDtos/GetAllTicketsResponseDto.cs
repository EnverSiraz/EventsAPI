using EventsAPI.Models.Enums;
using EventsAPI.Models.ORMs;

namespace EventsAPI.Models.DTOs.TicketDtos.ResponseDtos
{
    public class GetAllTicketsResponseDto
    {
        public int Id { get; set; }

        public TicketTypes TicketType { get; set; }

        public DateTime PurchaseDate { get; set; }


        public string Contact { get; set; }

        
        public string EventName { get; set; }
    }
}
