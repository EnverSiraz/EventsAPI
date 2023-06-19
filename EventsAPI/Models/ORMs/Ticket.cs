using EventsAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsAPI.Models.ORMs
{
    public class Ticket
    {
        public int Id { get; set; }

        public TicketTypes TicketType { get; set; }

        public DateTime PurchaseDate { get; set; }


        public string Contact { get; set; }

        public int? EventId { get; set; }
        public Event Event { get; set; }

    }
}
