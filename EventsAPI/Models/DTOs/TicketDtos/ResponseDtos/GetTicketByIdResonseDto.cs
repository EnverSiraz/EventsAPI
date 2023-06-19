using EventsAPI.Models.Enums;

namespace EventsAPI.Models.DTOs.TicketDtos.ResponseDtos
{
    public class GetTicketByIdResonseDto
    {
        public int Id { get; set; }

        public TicketTypes TicketType { get; set; }

        public DateTime PurchaseDate { get; set; }


        public string Contact { get; set; }


        public string EventName { get; set; }
    }
}
