using EventsAPI.Models.Enums;

namespace EventsAPI.Models.ORMs
{
    public class Purchase
    {
        public int Id { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public PaymentMethods PaymentMethods { get; set; }
        

    }
}
