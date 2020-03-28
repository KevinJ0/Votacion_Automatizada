using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVotacionAutomatizada.Models;
using SistemaVotacionAutomatizada.DTO;
using Microsoft.AspNetCore.Identity;


namespace SistemaVotacionAutomatizada.Controllers
{

    public class HomeController : Controller
    {

<<<<<<< HEAD
=======

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
>>>>>>> master
        public IActionResult Index()
        {
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
            if (signInManager.IsSignedIn(User)) return RedirectToAction("MenuAdmin", "Home");

            return View();
        }

        /*[HttpPost]
        public IActionResult ValidadorCedula(CiudadanosViewModel ciudadanosViewModel)
        {
            if (ciudadanosViewModel.Id)
            {
                return ("Usted ya ha votado en las elecciones vigentes!");
            }
            else if (ciudadanosViewModel.Id)
            {
                return ("No existen procesos electorales activos en este momento.");
            }
            else if (ciudadanosViewModel.Id)
            {
                return ("Este número de cédula se encuentra en estado inactivo!");
            }
            else
            {
                return View("MenuCiudadano");
            }
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
