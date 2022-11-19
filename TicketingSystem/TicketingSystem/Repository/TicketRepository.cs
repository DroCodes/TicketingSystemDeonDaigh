using TicketingSystem.Models;

namespace TicketingSystem.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private TicketContext context;

        public TicketRepository(TicketContext cntx)
        {
            context = cntx;
        }

        public List<Ticket> GetAllTickets()
        {
            return context.Tickets.ToList();
        }

        public List<Ticket> GetOddTickets()
        {
            return context.Tickets
                .Where(t => t.Id % 2 == 1)
                .ToList();
        }

        public Ticket Find(int id)
        {
            return context.Tickets.Find(id);
        }

        public void DeleteTicket(Ticket ticket)
        {
            context.Tickets.Remove(ticket);
            context.SaveChanges();
        }

        public void InsertTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            context.Tickets.Update(ticket);
        }

        public List<Status> GetStatus()
        {
            return context.Status.ToList();
        }
    }
}
