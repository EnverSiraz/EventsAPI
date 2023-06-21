namespace EventsAPI.Models.DTOs.CustomerDtos.RequestDtos
{
    public class CreateCustomerRequestDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
    }
}
