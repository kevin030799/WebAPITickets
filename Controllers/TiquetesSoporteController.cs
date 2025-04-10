using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITickets.Data;
using WebAPITickets.Models;
using System;

namespace WebAPITickets.Controllers
{
    [Route("api/tiquetes/soporte")]
    [ApiController]
    public class TiquetesSoporteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiquetesSoporteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tiquetes/soporte/verTiquetesSoporte?idUsuario=1
        [HttpGet("verTiquetesSoporte")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesSoporte(int idUsuario)
        {
            return await _context.Tiquetes
                .Where(t => t.ti_us_identificador == idUsuario)
                .ToListAsync();
        }

        // GET: api/tiquetes/soporte/verTiquetesCreados
        [HttpGet("verTiquetesCreados")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesCreados()
        {
            return await _context.Tiquetes
                .Where(t => t.ti_estado == "A")
                .ToListAsync();
        }

        // GET: api/tiquetes/soporte/verTiquetesPendientes
        [HttpGet("verTiquetesPendientes")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesPendientes()
        {
            return await _context.Tiquetes
                .Where(t => t.ti_solucion == null && t.ti_estado == "A")
                .ToListAsync();
        }

        // GET: api/tiquetes/soporte/verTiquetesCreadosDiarios
        [HttpGet("verTiquetesCreadosDiarios")]
        public async Task<ActionResult<IEnumerable<Tiquete>>> VerTiquetesCreadosDiarios()
        {
            var hoy = DateTime.Today;
            return await _context.Tiquetes
                .Where(t => t.ti_fecha_adicion.Date == hoy && t.ti_estado == "A")
                .ToListAsync();
        }
    }
}

