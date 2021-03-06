﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVotacionAutomatizada.Helpers;
using SistemaVotacionAutomatizada.Models;

namespace SistemaVotacionAutomatizada.Controllers
{
    [Authorize]
    public class PuestoElectivosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailsender;

        public PuestoElectivosController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailsender = emailSender;
        }

        //Pablo: menu de Ciudadanos; igual a index...
        [HttpGet]
        public async Task<IActionResult> MenuVotante()
        {
            return View(await _context.PuestoElectivos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> MenuVotante(string candidatos)
        {
            var message = new Message(new string[] { "insertar correo votante" }, "Selección Candidatos", "Insertar contenido correo");

            await _emailsender.SendEmailAsync(message);

            return View("Index");
        }

        // GET: PuestoElectivos
        public async Task<IActionResult> Index()
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);

            if (context == true)
            {
                ViewBag.InfoEleccionActiva = "En estos momentos existe una elección activa";
            }
            return View(await _context.PuestoElectivos.ToListAsync());
        }

        // GET: PuestoElectivos/Details/5
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
   
        public async Task<IActionResult> Create()
        {
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: PuestoElectivos/Create
       
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
            var context = await _context.Elecciones.AnyAsync(x => x.Estado == true);
            if (context == true)
            {
                return RedirectToAction(nameof(Index));
            }
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

            var puestoElectivos = await _context.PuestoElectivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoElectivos == null)
            {
                return NotFound();
            }

            return View(puestoElectivos);
        }

        // POST: PuestoElectivos/Delete/5
       
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
