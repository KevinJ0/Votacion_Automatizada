using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVotacionAutomatizada.Models;
using SistemaVotacionAutomatizada.DTO;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SistemaVotacionAutomatizada.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CandidatosController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Candidatos.Include(c => c.Partido).Include(c => c.PuestoElectivos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .Include(c => c.Partido)
                .Include(c => c.PuestoElectivos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            ViewData["PartidoId"] = new SelectList(_context.Partidos, "Id", "Nombre");
            ViewData["PuestoElectivosId"] = new SelectList(_context.PuestoElectivos, "Id", "Nombre");
            return View();
        }

        // POST: Candidatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,Photo,Estado,PartidoId,PuestoElectivosId")] CandidatosDTO candidatosDTO)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(candidatosDTO.IFormFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + candidatosDTO.IFormFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    candidatosDTO.IFormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Candidatos newCandidato = new Candidatos
                {
                    //Id = candidatosDTO.PartidoId,
                    Nombre = candidatosDTO.Nombre,
                    Apellido = candidatosDTO.Apellido,
                    Email = candidatosDTO.Email,
                    Photo = uniqueFileName,
                    Estado = candidatosDTO.Estado,
                    PartidoId = candidatosDTO.PartidoId,
                    PuestoElectivosId = candidatosDTO.PuestoElectivosId
                };

                _context.Add(candidatosDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = newCandidato.Id});
            }
            ViewData["PartidoId"] = new SelectList(_context.Partidos, "Id", "Nombre", candidatosDTO.PartidoId);
            ViewData["PuestoElectivosId"] = new SelectList(_context.PuestoElectivos, "Id", "Nombre", candidatosDTO.PuestoElectivosId);
            return View(candidatosDTO);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos.FindAsync(id);
            if (candidatos == null)
            {
                return NotFound();
            }
            ViewData["PartidoId"] = new SelectList(_context.Partidos, "Id", "Nombre", candidatos.PartidoId);
            ViewData["PuestoElectivosId"] = new SelectList(_context.PuestoElectivos, "Id", "Nombre", candidatos.PuestoElectivosId);
            return View(candidatos);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Photo,Estado,PartidoId,PuestoElectivosId")] Candidatos candidatos)
        {
            if (id != candidatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosExists(candidatos.Id))
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
            ViewData["PartidoId"] = new SelectList(_context.Partidos, "Id", "Nombre", candidatos.PartidoId);
            ViewData["PuestoElectivosId"] = new SelectList(_context.PuestoElectivos, "Id", "Nombre", candidatos.PuestoElectivosId);
            return View(candidatos);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.Candidatos
                .Include(c => c.Partido)
                .Include(c => c.PuestoElectivos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatos = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidatos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
