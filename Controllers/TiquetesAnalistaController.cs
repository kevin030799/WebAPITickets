using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoporteApp.Data;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    [Route("api/tiquetes/analista")]
    [ApiController]
    public class TiquetesAnalistaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiquetesAnalistaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("verTiquetesAnalista")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesAnalista(int idUsuario)
        {
            return await _context.Tiquetes
                .Where(t => t.ti_us_identificador == idUsuario)
                .ToListAsync();
        }

        [HttpGet("verTiquetesResueltos")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesResueltos()
        {
            return await _context.Tiquetes
                .Where(t => t.ti_solucion != null && t.ti_estado == "A")
                .ToListAsync();
        }

        [HttpGet("verTiquetesPendientes")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesPendientes()
        {
            return await _context.Tiquetes
                .Where(t => t.ti_solucion == null && t.ti_estado == "A")
                .ToListAsync();
        }

        [HttpPatch("resolverTiquete")]
        public async Task<IActionResult> ResolverTiquete(int idTiquete, string solucion, string modificadoPor)
        {
            var tiquete = await _context.Tiquetes.FindAsync(idTiquete);
            if (tiquete == null)
            {
                return NotFound();
            }

            tiquete.ti_solucion = solucion;
            tiquete.ti_fecha_modificacion = DateTime.Now;
            tiquete.ti_modificado_por = modificadoPor;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("verTiquetesResueltosDiarios")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesResueltosDiarios()
        {
            var hoy = DateTime.Today;
            return await _context.Tiquetes
                .Where(t => t.ti_solucion != null && t.ti_fecha_modificacion != null && t.ti_fecha_modificacion.Value.Date == hoy)
                .ToListAsync();
        }
    }
}

