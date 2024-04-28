using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rep.App_Data;
using rep.Models.DbModels;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace rep.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationContext _context;
        public MainController(ApplicationContext context)
        {
            _context = context;
        }
        public void CheckRole()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.User.FirstOrDefault(u => u.UserID == Convert.ToInt32(userId));

            string userRole = "";
            if (user != null)
            {
                userRole = user.UserRole;
            }

            ViewBag.UserRole = userRole;
        }
        public IActionResult Index()
        {
            CheckRole();
            return View();
        }
        public async Task<IActionResult> Reviews()
        {
            CheckRole();
            var rew = await _context.Review.ToListAsync();
            return View(rew);
        }
        public async Task<IActionResult> Users() 
        {
            CheckRole();
            if (User.Identity!.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userRole = await _context.User
                  .Where(a => a.UserID.ToString() == userId)
                  .Select(a => a.UserRole)
                  .FirstOrDefaultAsync();


                if (userRole != null && userRole == "admin")
                {
                    var users = await _context.User.ToListAsync();

                    return View(users);

                }
            }
            return RedirectToAction("NotEnoughRights", "Error");
        }
        private string EncryptPassword(string? password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password!);
                byte[] hashBytes = sha512.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes);

                return hash;
            }
        }
        [HttpPost]
        public ActionResult Users(IFormCollection form)
        {
            var model = new User
            {
                UserName = form["login"],
                UserPassword = EncryptPassword(form["password"]),
                UserRole = form["role"],
                UserRegDate = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.User.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Users", "Main");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при добавлении пользователя: " + ex.Message);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Marks()
        {
            CheckRole();
            if (User.Identity!.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userRole = await _context.User
                    .Where(a => a.UserID.ToString() == userId)
                    .Select(a => a.UserRole)
                    .FirstOrDefaultAsync();
                if (userRole != null && userRole == "user")
                {
                    var userMarks = await _context.MarksStudents
                        .Where(a => a.ID_Student.ToString() == userId)
                        .ToListAsync();

                    var teacherIds = userMarks.Select(m => m.ID_Teacher).Distinct().ToList();

                    var teachers = new Dictionary<int, string>();

                    foreach (var teacherId in teacherIds)
                    {
                        var teacher = await _context.User.FindAsync(teacherId);
                        if (teacher != null)
                        {
                            teachers.Add(teacherId, teacher.UserName);
                        }
                        else
                        {
                            teachers.Add(teacherId, "Неизвестный");
                        }
                    }

                    ViewBag.Teachers = teachers;

                    return View(userMarks);
                }
            }
            return RedirectToAction("NotEnoughRights", "Error");
        }

    }
}
