using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVotacionAutomatizada.Models;

namespace SistemaVotacionAutomatizada.Controllers
{
    public class VotosEleccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotosEleccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VotosElecciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VotosElecciones.Include(v => v.Candidato).Include(v => v.Ciudadano).Include(v => v.Eleccion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VotosElecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votosElecciones = await _context.VotosElecciones
                .Include(v => v.Candidato)
                .Include(v => v.Ciudadano)
                .Include(v => v.Eleccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votosElecciones == null)
            {
                return NotFound();
            }

            return View(votosElecciones);
        }

        // GET: VotosElecciones/Create
        public IActionResult Create()
        {
            ViewData["CandidatoId"] = new SelectList(_context.Candidatos, "Id", "Apellido");
            ViewData["CiudadanoId"] = new SelectList(_context.Ciudadanos, "Id", "Id");
            ViewData["EleccionId"] = new SelectList(_context.Elecciones, "Id", "Nombre");
            return View();
        }

        // POST: VotosElecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EleccionId,CandidatoId,CiudadanoId")] VotosElecciones votosElecciones)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(votosElecciones);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (SqlException e) {

                ViewBag.ViewError = "Ha ocurrido un error al intentar ingresa los datos";

            }
            catch (DbUpdateException e)
            {

                ViewBag.ViewError = "Este candidatos ya tiene un voto por este ciudadano";

            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidatos, "Id", "Apellido", votosElecciones.CandidatoId);
            ViewData["CiudadanoId"] = new SelectList(_context.Ciudadanos, "Id", "Id", votosElecciones.CiudadanoId);
            ViewData["EleccionId"] = new SelectList(_context.Elecciones, "Id", "Nombre", votosElecciones.EleccionId);
            return View(votosElecciones);
        }

        // GET: VotosElecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votosElecciones = await _context.VotosElecciones.FindAsync(id);
            if (votosElecciones == null)
            {
                return NotFound();
            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidatos, "Id", "Apellido", votosElecciones.CandidatoId);
            ViewData["CiudadanoId"] = new SelectList(_context.Ciudadanos, "Id", "Id", votosElecciones.CiudadanoId);
            ViewData["EleccionId"] = new SelectList(_context.Elecciones, "Id", "Nombre", votosElecciones.EleccionId);
            return View(votosElecciones);
        }

        // POST: VotosElecciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EleccionId,CandidatoId,CiudadanoId")] VotosElecciones votosElecciones)
        {
            if (id != votosElecciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(votosElecciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotosEleccionesExists(votosElecciones.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidatos, "Id", "Apellido", votosElecciones.CandidatoId);
            ViewData["CiudadanoId"] = new SelectList(_context.Ciudadanos, "Id", "Id", votosElecciones.CiudadanoId);
            ViewData["EleccionId"] = new SelectList(_context.Elecciones, "Id", "Nombre", votosElecciones.EleccionId);
            return View(votosElecciones);
        }

        // GET: VotosElecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var votosElecciones = await _context.VotosElecciones
                .Include(v => v.Candidato)
                .Include(v => v.Ciudadano)
                .Include(v => v.Eleccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (votosElecciones == null)
            {
                return NotFound();
            }

            return View(votosElecciones);
        }

        // POST: VotosElecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var votosElecciones = await _context.VotosElecciones.FindAsync(id);
            _context.VotosElecciones.Remove(votosElecciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VotosEleccionesExists(int id)
        {
            return _context.VotosElecciones.Any(e => e.Id == id);
        }
    }
}
