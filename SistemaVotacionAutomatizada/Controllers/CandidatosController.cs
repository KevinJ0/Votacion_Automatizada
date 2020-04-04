using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVotacionAutomatizada.DTO;
using SistemaVotacionAutomatizada.Models;

namespace SistemaVotacionAutomatizada.Controllers
{
    //[Authorize]

    public class CandidatosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper _mapper;

        public CandidatosController(ApplicationDbContext context, IMapper mapper, IHostingEnvironment hostingEnvironment)

        {
            this.hostingEnvironment = hostingEnvironment;
            this._mapper = mapper;
            _context = context;
         }


        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);

            if (context == true)
            {
                ViewBag.InfoEleccionActiva = "En estos momentos existe una elección activa";
            }

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

            var candidatos = await _context.Candidatos.FirstOrDefaultAsync(m => m.Id == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // GET: Candidatos/Create
        public async Task<IActionResult> Create()
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartidoId"] = new SelectList(_context.Partidos, "Id", "Nombre");
            ViewData["PuestoElectivosId"] = new SelectList(_context.PuestoElectivos, "Id", "Nombre");
            return View();
        }

        // POST: Candidatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidatosDTO model)
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
            var canditado = new Candidatos();
            if (ModelState.IsValid)
            {
                string uniqueName = null;
                if (model.PhotoProfile != null)
                {
                    var folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + model.PhotoProfile.FileName;
                    var filePath = Path.Combine(folderPath, uniqueName);
                    if (filePath != null) model.PhotoProfile.CopyTo(new FileStream(filePath, mode: FileMode.Create));
                }

                canditado = _mapper.Map<Candidatos>(model);
                canditado.Photo = uniqueName;

                _context.Add(canditado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartidoId"] = new SelectList(_context.Partidos, "Id", "Nombre");
            ViewData["PuestoElectivosId"] = new SelectList(_context.PuestoElectivos, "Id", "Nombre");

            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            var candidatoDto = _mapper.Map<CandidatosDTO>(candidato);
            return View(candidatoDto);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CandidatosDTO dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var candidato = await _context.Candidatos.FirstOrDefaultAsync(d => d.Id == dto.Id);

                    string uniqueName = null;
                    if (dto.PhotoProfile != null)
                    {
                        var folderPath = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueName = Guid.NewGuid().ToString() + "_" + dto.PhotoProfile.FileName;
                        var filePath = Path.Combine(folderPath, uniqueName);


                        if (!string.IsNullOrEmpty(candidato.Photo))
                        {
                            var filePathDelete = Path.Combine(folderPath, candidato.Photo);

                            if (System.IO.File.Exists(filePathDelete) && filePathDelete != filePath)
                            {
                                var fileInfo = new System.IO.FileInfo(filePathDelete);
                                fileInfo.Delete();
                            }
                        }

                        if (filePath != null) dto.PhotoProfile.CopyTo(new FileStream(filePath, mode: FileMode.Create));
                        candidato.Photo = uniqueName;
                    }

                    candidato.PartidoId = dto.PartidoId;
                    candidato.PuestoElectivosId = dto.PuestoElectivosId;
                    candidato.Nombre = dto.Nombre;
                    candidato.Apellido = dto.Apellido;
                    candidato.Email = dto.Email;
                    candidato.Estado = dto.Estado;

                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosExists(dto.Id))
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
            return View(dto);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
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
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
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
