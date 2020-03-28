﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVotacionAutomatizada.Models;

namespace SistemaVotacionAutomatizada.Controllers
{
    public class PuestoElectivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PuestoElectivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Pablo: menu de Ciudadanos; igual a index...
        [HttpGet]
        public async Task<IActionResult> MenuVotante()
        {
            return View(await _context.PuestoElectivos.ToListAsync());
        }

        // GET: PuestoElectivos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.PuestoElectivos.ToListAsync());
        }

        // GET: PuestoElectivos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivos = await _context.PuestoElectivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoElectivos == null)
            {
                return NotFound();
            }

            return View(puestoElectivos);
        }

        // GET: PuestoElectivos/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuestoElectivos/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Estado")] PuestoElectivos puestoElectivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestoElectivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestoElectivos);
        }

        // GET: PuestoElectivos/Edit/5
        //[Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivos = await _context.PuestoElectivos.FindAsync(id);
            if (puestoElectivos == null)
            {
                return NotFound();
            }
            return View(puestoElectivos);
        }

        // POST: PuestoElectivos/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Estado")] PuestoElectivos puestoElectivos)
        {
            if (id != puestoElectivos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestoElectivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoElectivosExists(puestoElectivos.Id))
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
            return View(puestoElectivos);
        }

        // GET: PuestoElectivos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestoElectivos = await _context.PuestoElectivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoElectivos == null)
            {
                return NotFound();
            }

            return View(puestoElectivos);
        }

        // POST: PuestoElectivos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestoElectivos = await _context.PuestoElectivos.FindAsync(id);
            _context.PuestoElectivos.Remove(puestoElectivos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoElectivosExists(int id)
        {
            return _context.PuestoElectivos.Any(e => e.Id == id);
        }
    }
}
