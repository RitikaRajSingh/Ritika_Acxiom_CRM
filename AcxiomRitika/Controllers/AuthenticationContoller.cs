

using AcxiomRitika.Data;
using AcxiomRitika.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcxiomRitika.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AppDbContext _context;

        public AuthenticationController(AppDbContext context)
        {
            _context = context;
        }

        // -------------------- REGISTER (GET) --------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // -------------------- REGISTER (POST) --------------------
        [HttpPost]
        public IActionResult Register(UserRegister user)
        {
            if (ModelState.IsValid)
            {
                _context.UserRegisters.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");   // After register => Login page
            }
            return View(user);
        }

        // -------------------- LOGIN (GET) -----------------------
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // -------------------- LOGIN (POST) -----------------------
        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            var user = _context.UserRegisters
                        .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                // Login successful → Go to Dashboard
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("", "Invalid Email or Password");
            return View(model);
        }
    }
}
