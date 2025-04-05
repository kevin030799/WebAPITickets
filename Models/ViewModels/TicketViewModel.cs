using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAPITickets.Models.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Asunto { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public string Urgencia { get; set; }

        [Required]
        public string Importancia { get; set; }

        public string Estado { get; set; }
        public string Solucion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? AsignadoA { get; set; }
        public IEnumerable<SelectListItem> UsuariosSoporte { get; set; }
    }

}
