using EventsAPI.Models.Enums;
using EventsAPI.Models.ORMs;

namespace EventsAPI.Models.DTOs.TicketDtos.RequestDtos
{
    public class CreateTicketReqestDto
    {
        public TicketTypes TicketType { get; set; }
        public int EventId { get; set; }
        public int PurchaseId { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal TicketQuantity { get; set; }
    }
}
