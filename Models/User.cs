using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace WebAPITickets.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Rol { get; set; } // "Soporte" o "Analista"

        public ICollection<Ticket> TicketsCreados { get; set; }
        public ICollection<Ticket> TicketsAsignados { get; set; }
    }

}
