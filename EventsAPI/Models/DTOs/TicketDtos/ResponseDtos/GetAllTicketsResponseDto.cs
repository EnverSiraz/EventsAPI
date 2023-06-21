using EventsAPI.Models.Enums;
using EventsAPI.Models.ORMs;

namespace EventsAPI.Models.DTOs.TicketDtos.ResponseDtos
{
    public class GetAllTicketsResponseDto
    {
        public int Id { get; set; }
        public TicketTypes TicketType { get; set; }    
        public string EventName { get; set; }
        public int PurchaseId { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal TicketQuantity { get; set; }
    }
}
