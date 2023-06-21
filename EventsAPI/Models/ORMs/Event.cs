using EventsAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace EventsAPI.Models.ORMs
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string? EventCoverUrl { get; set; }
        public EventTypes EventTypes { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public bool IsFree { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
