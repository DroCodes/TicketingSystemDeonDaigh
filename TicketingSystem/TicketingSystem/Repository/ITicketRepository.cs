using TicketingSystem.Models;

namespace TicketingSystem.Repository
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllTickets();

        List<Ticket> GetOddTickets();

        Ticket Find(int id);

        void Save();
        void InsertTicket(Ticket ticket);

        void DeleteTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        List<Status> GetStatus();
    }
}