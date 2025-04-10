namespace WebAPITickets.Models
{
    public class Urgencia
    {
        public int ur_identificador { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string ModificadoPor { get; set; }
    }

}
