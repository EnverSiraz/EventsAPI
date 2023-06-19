namespace EventsAPI.Models.ORMs
{
    public class Place
    {
        public int Id { get; set; }

        public string PlaceName { get; set; }
        public string PlaceDescription { get; set; }
        public string PlaceCity { get; set; }
        public string PlaceAdress { get; set; }
        public string PlaceMapUrl { get; set; }

        public ICollection<Event> Events { get; set; }

    }
}
