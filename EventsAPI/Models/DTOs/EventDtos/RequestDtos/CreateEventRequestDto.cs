using EventsAPI.Models.Enums;
using EventsAPI.Models.ORMs;

namespace EventsAPI.Models.DTOs.EventDtos.RequestDtos
{
    public class CreateEventRequestDto
    {

        public string EventName { get; set; }


        public string EventDescription { get; set; }
        public string EventCoverUrl { get; set; }


        public EventTypes EventTypes { get; set; }

        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }


        public int PlaceId { get; set; }



    }
}
