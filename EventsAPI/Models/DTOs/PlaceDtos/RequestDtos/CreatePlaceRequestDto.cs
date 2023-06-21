namespace EventsAPI.Models.DTOs.PlaceDtos.RequestDtos
{
    public class CreatePlaceRequestDto
    {
        public string PlaceName { get; set; }
        public string PlacePhotoUrl { get; set; }
        public string PlaceDescription { get; set; }
        public string PlaceCity { get; set; }
        public string PlaceAdress { get; set; }
        public string PlaceMapUrl { get; set; }
    }
}
