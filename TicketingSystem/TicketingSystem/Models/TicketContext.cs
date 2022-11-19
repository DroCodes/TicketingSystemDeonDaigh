using Microsoft.EntityFrameworkCore;

namespace TicketingSystem.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    StatusId = "checkin",
                    StatusName = "Checking In"
                },

                new Status
                {
                    StatusId = "waiting",
                    StatusName = "Wating to Start"
                },

                new Status
                {
                    StatusId = "IR",
                    StatusName = "In Race"
                },

                new Status
                {
                    StatusId = "done",
                    StatusName = "Done"
                });
        }
    }
}
