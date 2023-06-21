namespace EventsAPI.Models.ORMs
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public ICollection<Purchase> Purchases { get; set; }


    }
}
