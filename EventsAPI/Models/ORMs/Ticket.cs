using EventsAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsAPI.Models.ORMs
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketTypes TicketType { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal TicketQuantity { get; set; }

    }
}
