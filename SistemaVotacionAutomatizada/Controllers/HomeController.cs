using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVotacionAutomatizada.Models;
using SistemaVotacionAutomatizada.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using SistemaVotacionAutomatizada.Helpers;
using Newtonsoft.Json;
using Mantenimiento.DTO;

namespace SistemaVotacionAutomatizada.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext _context;
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
        }
      
      
        public async Task<IActionResult> Index()
        {

            //crear user por defecto
            if (!_context.Users.Any())
            {
                RegisterDTO dto = new RegisterDTO
                {
                    UserName = "Jose",
                    Email = "Jose@hotmail.com",
                    Password = "Itlaprueba1!"
                };

                var user = new IdentityUser
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                };

                var result = await userManager.CreateAsync(user, dto.Password);

            }
            if (signInManager.IsSignedIn(User)) return RedirectToAction("MenuAdmin", "Home");

            return View();
        }

        public IActionResult MenuAdmin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ValidadorCedula()
        {
            //los administradores logueados no pueden entrar a esta area
            if (signInManager.IsSignedIn(User)) return RedirectToAction("MenuAdmin", "Home");

            var eleccionActiva = _context.Elecciones.Where(x => x.Estado == true).FirstOrDefault();
            if (eleccionActiva == null)
            {
                ViewBag.ErrorValidarId = "No existe ninguna elección activa.";
                
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidadorCedula(string id)
        {

            var ciudadano = await _context.Ciudadanos.FindAsync(id);

            if (ciudadano == null)
            {

                ViewBag.ErrorValidarId = "Esta Cédula es invalida o no se encuentra activa.";
                return View(ciudadano);

            }
            var eleccionActiva = _context.Elecciones.Where(x=> x.Estado == true).FirstOrDefault();
            if (eleccionActiva == null)
            {
                ViewBag.ErrorValidarId = "No existe ninguna elección activa.";
                return View(ciudadano);
            }
            bool votos =  _context.VotosElecciones.Any(x=> x.CiudadanoId == ciudadano.Id && x.EleccionId == eleccionActiva.Id);
            if (votos)
            {
                ViewBag.ErrorValidarId = "Usted ya ha votado en las elecciones vigentes.";
                return View(ciudadano);
            }

            HttpContext.Session.SetString(VotoKeys.KeyCiudadanoId,ciudadano.Id);
            HttpContext.Session.SetInt32(VotoKeys.KeyEleccionId, eleccionActiva.Id);
            HttpContext.Session.SetString(VotoKeys.KeyVotos, JsonConvert.SerializeObject(new List<VotosElecciones>()));
            
            return RedirectToAction("SelectPuestoElectivo","VotosElecciones");
           

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
