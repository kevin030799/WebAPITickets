using System.Data;

namespace WebAPITickets.Models
{
    public class Usuario
    {
        internal object us_ro_identificador;
        internal object? us_identificador;

        public int Id { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string NombreCompleto { get; set; }
        public int RolId { get; set; }
        public string Estado { get; set; }

        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string ModificadoPor { get; set; }

        public Roles Rol { get; set; }
    }

}
