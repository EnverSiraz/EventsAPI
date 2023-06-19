using EventsAPI.Models.ORMs;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI
{
    public class EventsDb :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UPLPK9E; Database=EventsAndTicketsDb; trusted_connection=true");
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
