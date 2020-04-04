using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaVotacionAutomatizada.Helpers;
using SistemaVotacionAutomatizada.Models;

namespace SistemaVotacionAutomatizada.Controllers
{
    public class VotosEleccionesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public VotosEleccionesController(ApplicationDbContext context, IEmailSender emailSender)
        {
            this._context = context;
            this._emailSender = emailSender;
        }

        [Authorize]
        // GET: VotosElecciones
        public async Task<IActionResult> Index()
        {
            // var message = new Message(new String[] { "kevinjooo59@gmail.com" }, "Titulo", "Estoy probando");
            //  await _emailSender.SendEmailAsync(message); esto no sirve!


            var applicationDbContext = _context.VotosElecciones.Include(v => v.Candidato).Include(v => v.Ciudadano).Include(v => v.Eleccion);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
            catch (SqlException e)
            {

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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            var votosElecciones = await _context.VotosElecciones.FindAsync(id);
            _context.VotosElecciones.Remove(votosElecciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> selectPuestoElectivo(int? id)
        {
            //En caso de que no exista ninguna eleccion activa; no se puede ingresar por URL
            var eleccionActiva = _context.Elecciones.Where(x => x.Estado == true).FirstOrDefault();
            if (eleccionActiva == null)
            {
                ViewBag.ErrorValidarEleccionActiva = "No existe ninguna elección activa.";
                return View();
            }
            IEnumerable<PuestoElectivos> puestoElect;
            List<int> PuestoElectivoIdJson = new List<int>();
            var str = HttpContext.Session.GetString(VotoKeys.KeyPuestoElectivos);
            // esto indica si existe alguna lista de votos creada

            if (str != null)
            {
                PuestoElectivoIdJson = JsonConvert.DeserializeObject<List<int>>(str);
                if (PuestoElectivoIdJson.Count > 0)
                {
                    puestoElect = _context.PuestoElectivos
                   .Where(x => x.Estado == true)
                   .Where(a => _context.Candidatos
                   .Any(a1 => a1.PuestoElectivosId == a.Id && a1.Estado == true))
                   .Where(x=> x.Candidatos.Any(c=> c.Partido.Estado == true))
                   .Where(a => !PuestoElectivoIdJson.Contains(a.Id))
                   .ToList();

                    if (puestoElect.Count() <= 0)
                    {
                        ViewBag.VotacionFin = true;
                    }
                    return View(puestoElect);
                }

            }

            puestoElect = await _context.PuestoElectivos
                .Where(x => x.Estado == true)
                .Where(a => _context.Candidatos
                .Any(a1 => a1.PuestoElectivosId == a.Id && a1.Estado == true))
                .Where(x => x.Candidatos.Any(c => c.Partido.Estado == true))
               .ToListAsync();


            return View(puestoElect);
        }

        public async Task<IActionResult> selectPartido(int? puestoId)
        {
            //En caso de que no exista ninguna eleccion activa; no se puede ingresar por URL
            var eleccionActiva = _context.Elecciones.Where(x => x.Estado == true).FirstOrDefault();
            if (eleccionActiva == null)
            {
                ViewBag.ErrorValidarEleccionActiva = "El proceso de votación ha sido finalizado.";
                return View();
            }

            //En caso de que no exista ningun puesto electivo activo; no se puede ingresar por URL
            bool PuestoElecActivo = _context.PuestoElectivos.Any(x => x.Id == puestoId && x.Estado == true);
            if (!PuestoElecActivo) return RedirectToAction(nameof(selectPuestoElectivo));


            var partidos = await _context.Candidatos
            .Where(x => x.PuestoElectivosId == puestoId && x.Estado == true)
            .Select(x => x.Partido).Where(p => p.Estado == true)

            .ToListAsync();

            int CantCandidatosActivos = _context.Candidatos
            .Where(x => x.PuestoElectivosId == puestoId)
            .Where(x => partidos.Any(c => c.Id == x.PartidoId))
            .Count();

            //En caso de que no exista candidatos en ese partido
            if (CantCandidatosActivos == 0) return RedirectToAction(nameof(selectPuestoElectivo));

            //Se pasa este ID de elecciones para saber a que puesto pertenece el candidato del partido escogido mas adelante.
            ViewBag.PuestoElectivoId = puestoId;

            return View(partidos);
        }

        [HttpGet]
        //Pablo: Menu Candidatos
        public async Task<IActionResult> selectCandidato(int? puestoId, int? partidoId)
        {
            //En caso de que no exista ninguna eleccion activa; no se puede ingresar por URL
            var eleccionActiva = _context.Elecciones.Where(x => x.Estado == true).FirstOrDefault();

            if (eleccionActiva == null)
            {
                ViewBag.ErrorValidarEleccionActiva = "El proceso de votación ha sido finalizado.";
                return View();
            }
            // si voto por ninguno lo mando directo a guardar
            if (partidoId == 0) return RedirectToAction("guardaCandidatoSession", new { candidatoId = -1 });

            //valida que el estado sea true del puesto electivo
            bool PuestoElecActivo = _context.PuestoElectivos.Any(x => x.Id == puestoId && x.Estado == true);
            if (!PuestoElecActivo) return RedirectToAction(nameof(selectPuestoElectivo));

            var candidatos = await _context.Candidatos
                .Where(x => x.PartidoId == partidoId && x.PuestoElectivosId == puestoId && x.Estado == true)
                .ToListAsync();
            ViewBag.Partido = _context.Partidos.Find(partidoId).Nombre;
            ViewBag.PuestoElectivo = _context.PuestoElectivos.Find(puestoId).Nombre;

            return View(candidatos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> guardaCandidatoSession(int? candidatoId, int? puestoElectivoId = null)
        {

            string ciudadanoId = HttpContext.Session.GetString(VotoKeys.KeyCiudadanoId);
            int? eleccionId = HttpContext.Session.GetInt32(VotoKeys.KeyEleccionId);
            if (eleccionId == null || ciudadanoId == null)
            {
                return RedirectToAction("ValidadorCedula", "Home");
            }

            Candidatos candidato = _context.Candidatos.Find(candidatoId);
            //Elecciones eleccion = _context.Elecciones.Find(eleccionId);
            //Ciudadanos ciudadano = _context.Ciudadanos.Find(ciudadanoId);

            VotosElecciones voto = new VotosElecciones
            {
                // esto pertenece a ninguno 
                CandidatoId = candidatoId == -1 ? null : candidatoId,
                CiudadanoId = ciudadanoId,
                EleccionId = eleccionId,
            };

            if (candidatoId != -1)
            {
                puestoElectivoId = _context.Candidatos.Find(candidatoId).PuestoElectivosId;
            }
            List<int> PuestoElectivoIdJson = new List<int>();
            List<VotosElecciones> VotosJson = new List<VotosElecciones>();

            var str = HttpContext.Session.GetString(VotoKeys.KeyVotos);
            // esto indica si existe alguna lista de votos creada
            if (str != null) VotosJson = JsonConvert.DeserializeObject<List<VotosElecciones>>(str);
            VotosJson.Add(voto);
            HttpContext.Session.SetString(VotoKeys.KeyVotos, JsonConvert.SerializeObject(VotosJson));

            if (puestoElectivoId != null)
            {
                var ListPuestoElect = HttpContext.Session.GetString(VotoKeys.KeyPuestoElectivos);
                if (ListPuestoElect != null) PuestoElectivoIdJson = JsonConvert.DeserializeObject<List<int>>(ListPuestoElect);
                PuestoElectivoIdJson.Add((int)puestoElectivoId);
                HttpContext.Session.SetString(VotoKeys.KeyPuestoElectivos, JsonConvert.SerializeObject(PuestoElectivoIdJson));
            }
            return RedirectToAction(nameof(selectPuestoElectivo));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> finalizarVotacion()
        {
            string ciudadanoId = HttpContext.Session.GetString(VotoKeys.KeyCiudadanoId);
            int? eleccionId = HttpContext.Session.GetInt32(VotoKeys.KeyEleccionId);

            Elecciones eleccion = _context.Elecciones.Find(eleccionId);
            Ciudadanos ciudadano = _context.Ciudadanos.Find(ciudadanoId);

            List<VotosElecciones> VotosJson = VotosJson = new List<VotosElecciones>();
            var str = HttpContext.Session.GetString(VotoKeys.KeyVotos);
            // esto indica si existe alguna lista de votos creada
            if (str != null) VotosJson = JsonConvert.DeserializeObject<List<VotosElecciones>>(str);
            List<VotosElecciones> Votos = VotosJson.Where(x => x.CandidatoId != null).Distinct().ToList();
            if (Votos.Count() <= 0)
            {
                Votos.Add(new VotosElecciones { CandidatoId = null, CiudadanoId = ciudadanoId, EleccionId = eleccionId });
                await _context.AddRangeAsync(Votos);
            }
            else
            {

                await _context.AddRangeAsync(Votos);

            }


            await _context.SaveChangesAsync();

            string content = "<h5>Aqui estan la lista de candidatos por la cual votaste: </h5><br><br>";
            foreach (var item in Votos)
            {
                Candidatos candidato = null;
                String puestoElectivo = "Ninguno";
                String partido = "Ninguno";
                if (item.CandidatoId != null)
                {
                    candidato = _context.Candidatos.Find(item.CandidatoId);
                    puestoElectivo = _context.PuestoElectivos.Find(candidato.PuestoElectivosId).Nombre;
                    partido = _context.Partidos.Find(candidato.PartidoId).Nombre;
                }
                content = content + "<br/>" + "Puesto electivo: " + puestoElectivo + "<br/>Candidato: " + (candidato == null ? "Ninguno" : candidato.Nombre + " " + candidato.Apellido)
                    + "<br/>Partido: " + partido + "<hr>";
            }
            string titulo = "Elecciones " + eleccion.Nombre.Trim() + " " + eleccion.Fecha.GetDateTimeFormats('d')[0];

            // enviamos el correo
            string EmailOrigen = "itlaprueba4@gmail.com";
            string EmailDetino = ciudadano.Email.Trim();
            string contrasena = "Itlaprueba1!";
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDetino, titulo, content);
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, contrasena);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();

            HttpContext.Session.Clear();
            return RedirectToAction("ValidadorCedula", "Home");

        }
        public async Task<IActionResult> ResultadosVoto(int votoId)
        {
            VotosElecciones votosElecciones = await _context.VotosElecciones.FindAsync(votoId);
            return View(votosElecciones);
        }

        private bool VotosEleccionesExists(int id)
        {
            return _context.VotosElecciones.Any(e => e.Id == id);
        }


    }
}
