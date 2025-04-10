namespace WebAPITickets.Models
{
    public class Tiquete
    {
        internal object ti_ca_identificador;
        
        internal object ti_im_identificador;
        internal object ti_us_identificador;
        internal object ti_ur_identificador;

        public int ti_identificador { get; set; }
        public string Asunto { get; set; }
        public string DetalleCaso { get; set; }
        public int CategoriaId { get; set; }
        public int UrgenciaId { get; set; }
        public int ImportanciaId { get; set; }
        public int UsuarioId { get; set; }
        public string Solucion { get; set; }
        public string Estado { get; set; }

        public DateTime FechaAdicion { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string ModificadoPor { get; set; }

        public Categoria? Categoria { get; set; } // Relación con Categorias
        public Urgencia? Urgencia { get; set; } // Relación con Urgencias
        public Importancia? Importancia { get; set; } // Relación con Importancias
        public Usuario? Usuario { get; set; } // Relación con Usuarios
    }

}
