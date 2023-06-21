namespace EventsAPI.Models.DTOs.CustomerDtos.ResponseDtos
{
    public class GetAllCustomersResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}
