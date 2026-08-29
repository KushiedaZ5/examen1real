using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasPortal.Data;
using TecnoGasPortal.Models;

namespace TecnoGasPortal.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Solicitudes
        public async Task<IActionResult> Index()
        {
            var solicitudes = await _context.SolicitudesServicio
                .OrderByDescending(s => s.FechaRegistro)
                .ToListAsync();
            return View(solicitudes);
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitudes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cliente,Telefono,Distrito,TipoServicio,Descripcion")] SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                solicitud.FechaRegistro = DateTime.Now;
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Solicitud registrada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }
    }
}
