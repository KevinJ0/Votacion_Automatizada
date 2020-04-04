using System.Threading.Tasks;
using Mantenimiento.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace SistemaVotacionAutomatizada.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {

            if (signInManager.IsSignedIn(User))
            {
                HttpContext.Session.Clear();
                return RedirectToAction("MenuAdmin", "Home");
            }
            return View(); 
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("MenuAdmin", "Home");
                }

                 ModelState.AddModelError("ErrorInicioSeccion","Usuario o contraseña incorrectos");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("ValidadorCedula", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = dto.UserName, Email = dto.Email };
                var result = await userManager.CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }


            }

            return View(dto);

        }
    }
}