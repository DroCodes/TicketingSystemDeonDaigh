using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TicketingSystem.Models;
using TicketingSystem.Repository;

namespace Ticketing_Test
{
    [TestClass]
    public class TicketRepositoryInMemoryTest
    {
        DbContextOptions<TicketContext> inmemory;

        public TicketRepositoryInMemoryTest()
        {
            inmemory = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("Filename=test.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        [TestMethod]
        public void GetAllTickets_HappyPath()
        {

            TicketContext cntx = new TicketContext(inmemory);
            cntx.Tickets.Add(new Ticket() { Id = 1, Name = "First", Description = "Test Desc 1", Point = "1", SprintNum = "564", StatusId = "done" });
            cntx.Tickets.Add(new Ticket() { Id = 2, Name = "Second", Description = "Test Desc 2", Point = "3", SprintNum = "58", StatusId = "checkin" });
            cntx.SaveChanges();


            TicketRepository repository = new TicketRepository(cntx);
            var tickets = repository.GetAllTickets();

            Assert.AreEqual(2, tickets.Count());
        }

        [TestMethod]
        public void GetOddTickets_HappyPath()
        {
            var inmemory = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("Filename=test2.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            TicketContext cntx = new TicketContext(inmemory);
            cntx.Tickets.Add(new Ticket() { Id = 1, Name = "First", Description = "Test Desc 1", Point = "1", SprintNum = "79", StatusId = "waiting" });
            cntx.Tickets.Add(new Ticket() { Id = 2, Name = "Second", Description = "Test Desc 1", Point = "4", SprintNum = "654", StatusId = "checkin" });
            cntx.Tickets.Add(new Ticket() { Id = 3, Name = "Third", Description = "Test Desc 1", Point = "1", SprintNum = "15", StatusId = "done" });
            cntx.Tickets.Add(new Ticket() { Id = 4, Name = "Fourth", Description = "Test Desc 1", Point = "2", SprintNum = "135", StatusId = "done" });
            cntx.SaveChanges();


            TicketRepository repository = new TicketRepository(cntx);
            var tickets = repository.GetOddTickets();

            Assert.AreEqual(2, tickets.Count());
            Assert.AreEqual(1, tickets[0].Id);
            Assert.AreEqual(3, tickets[1].Id);
        }

    }
}
