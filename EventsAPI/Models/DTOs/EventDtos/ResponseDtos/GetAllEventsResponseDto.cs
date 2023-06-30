using EventsAPI.Models.Enums;
using EventsAPI.Models.ORMs;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsAPI.Models.DTOs.EventDtos.ResponseDtos
{
    public class GetAllEventsResponseDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventCoverUrl { get; set; }
        public EventTypes EventTypes { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public bool IsFree { get; set; }
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
    }
}
