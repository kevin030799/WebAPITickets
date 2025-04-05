using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAPITickets.Database;
using WebAPITickets.Models.ViewModels;
using WebAPITickets.Models;

namespace WebAPITickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserRol", user.Rol);
                return RedirectToAction("Index", "Tickets");
            }
            ModelState.AddModelError("", "Credenciales inválidas");
            return View(model);
        }

        public IActionResult Register()
        {
            var roles = new List<SelectListItem>
        {
            new SelectListItem { Text = "Soporte", Value = "Soporte" },
            new SelectListItem { Text = "Analista", Value = "Analista" }
        };

            return View(new RegisterViewModel { Roles = roles });
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = model.Email, Password = model.Password, Rol = model.Rol };
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            model.Roles = new List<SelectListItem>
        {
            new SelectListItem { Text = "Soporte", Value = "Soporte" },
            new SelectListItem { Text = "Analista", Value = "Analista" }
        };

            return View(model);
        }
    }

}
