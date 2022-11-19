using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketingSystem.Models;
using TicketingSystem.Repository;

namespace Ticketing_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private ITicketRepository ticketrepository;

        public HomeController(ILogger<HomeController> logger, ITicketRepository repository)
        {
            _logger = logger;
            ticketrepository = repository;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Name = ticketrepository.GetAllTickets();
            ViewBag.status = ticketrepository.GetStatus();
            ViewBag.SprintNum = ticketrepository.GetAllTickets();
            ViewBag.Point = ticketrepository.GetAllTickets();
            List<Ticket> tickets = ticketrepository.GetAllTickets();

            return View(tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.status = ticketrepository.GetStatus();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketrepository.InsertTicket(ticket);
                ticketrepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.status = ticketrepository.GetStatus();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            ViewBag.status = ticketrepository.GetStatus();
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            var key = nameof(Ticket.Name);
            var val = ModelState.GetFieldValidationState(id);

            if (selected.StatusId == null)
            {
                ticketrepository.DeleteTicket(selected);
                ViewBag.status = ticketrepository.GetStatus();
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = ticketrepository.Find(selected.Id);
                selected.StatusId = newStatusId;
                ticketrepository.UpdateTicket(selected);
            }
            ticketrepository.Save();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}