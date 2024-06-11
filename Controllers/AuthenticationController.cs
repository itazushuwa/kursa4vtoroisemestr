using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using rep.App_Data;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using rep.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace rep.Controllers
{
    //asdasd
    public class AuthenticationController : Controller
    {
        private readonly ApplicationContext _context;

        public AuthenticationController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.FirstOrDefault(u => u.UserName == model.UserName);

                if (user != null)
                {
                    var encpass = EncryptPassword(model.UserPassword!);
                    if (encpass == user.UserPassword)
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName!),
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())
                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewBag.ErrorMessage = "Неверный логин или пароль";
            }

            return View(model);
        }


        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        private string EncryptPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha512.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes);

                return hash;
            }
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User model)
        {

            if (ModelState.IsValid)
            {
                var existingAccount = _context.User.FirstOrDefault(a => a.UserName == model.UserName);
                if (existingAccount != null)
                {
                    ViewBag.ErrorMessage = "Пользователь с таким логином уже существует.";
                    return View(model);
                }
                var account = new User
                {
                    UserEmail = model.UserEmail,
                    UserRole = "user",
                    UserRegDate = DateTime.UtcNow,
                    UserName = model.UserName,
                    UserPassword = EncryptPassword(model.UserPassword!)
                };

                _context.User.Add(account);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View("Registration", model);
        }
    }
}
