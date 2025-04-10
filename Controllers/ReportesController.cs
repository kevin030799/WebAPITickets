using Microsoft.AspNetCore.Mvc;
using WebAPITickets.Database;

namespace WebAPITickets.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult DailySupportReport()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var today = DateTime.Today;

            var tickets = _context.Tickets
                .Where(t => t.CreadorId == userId && t.FechaCreacion.Date == today)
                .ToList();

            return View(tickets);
        }

        public IActionResult DailyAnalystReport()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var today = DateTime.Today;

            var tickets = _context.Tickets
                .Where(t => t.AsignadoAId == userId && t.Estado == "Resuelto" && t.FechaCreacion.Date == today)
                .ToList();

            return View(tickets);
        }
    }

}
