using EventsAPI.Models.ORMs;

namespace EventsAPI.Models.DTOs.CustomerDtos.ResponseDtos
{
    public class UpdateCustomerResponseDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

    }
}
