using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Asunto { get; set; }

        [Required]
        public string Categoria { get; set; } // Hardware, Software, Red

        public string Estado { get; set; } = "Creado"; // Pendiente, Resuelto

        public string Urgencia { get; set; } // Baja, Media, Alta
        public string Importancia { get; set; } // Baja, Media, Alta

        public string Solucion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public int CreadorId { get; set; }
        public User Creador { get; set; }

        public int? AsignadoAId { get; set; }
        public User AsignadoA { get; set; }
    }

}
