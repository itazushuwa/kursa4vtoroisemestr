using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using rep.App_Data;
using rep.Models.DbModels;
using System.Security.Claims;

namespace rep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        public void FindStudent()
        {
            var usersWithRole = _context.User.Where(u => u.UserRole == "user").ToList();
            var students = usersWithRole.Select(u => new SelectListItem { Value = u.UserID.ToString(), Text = u.UserName }).ToList();
            ViewBag.student = new SelectList(students, "Value", "Text");
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
        public async Task<IActionResult> Index()
        {
            CheckRole();
            var mat = await _context.Material.ToListAsync();
            return View(mat);
        }
        public async Task<IActionResult> Lessons()
        {
            CheckRole();
            if (User.Identity!.IsAuthenticated)
            {
                var less = await _context.Lesson.ToListAsync();
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userRole = await _context.User
                  .Where(a => a.UserID.ToString() == userId)
                  .Select(a => a.UserRole)
                  .FirstOrDefaultAsync();
                if (userRole != null && userRole == "user")
                {
                    return View(less);
                }
                else if (userRole != null && userRole == "teacher" || userRole == "admin")
                {
                    return View("AddLessons", less);
                }
            }
                return RedirectToAction("AunthError", "Error");
        }
        [HttpPost]
        public ActionResult AddLessons(IFormCollection form)
        {
            CheckRole();
            var model = new Lesson
            {
                LessonName = form["name"],
                LessonDayOfWeek = form["day"],
                LessonDuration = Convert.ToInt32(form["duration"]),
                LessonStartDate = Convert.ToDateTime(form["date"]),
                LessonEndDate = DateTime.UtcNow,
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Lesson.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Lessons", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при добавлении материала: " + ex.Message);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Materials()
        {
            CheckRole();
            if (User.Identity!.IsAuthenticated)
            {
                var mater = await _context.Material.ToListAsync();
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userRole = await _context.User
                  .Where(a => a.UserID.ToString() == userId)
                  .Select(a => a.UserRole)
                  .FirstOrDefaultAsync();
                if (userRole != null && userRole == "user")
                {       
                    return View(mater);
                }
                else if (userRole != null && userRole == "teacher" || userRole == "admin")
                {
                    return View("AddMaterials",mater);
                }
            }
                return RedirectToAction("AunthError", "Error");
        }
        [HttpPost]
        public ActionResult AddMaterials(IFormCollection form)
        {
            CheckRole();
            var model = new Material
            {
                MaterialTitle = form["Title"],
                MaterialDescription = form["description"],
                MaterialCourse = Convert.ToInt32(form["courseType"]),
                MaterialType = form["type"],
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Material.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Materials", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при добавлении материала: " + ex.Message);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Teachers()
        {
            CheckRole();
            var teach = await _context.Teacher.ToListAsync();
            return View(teach);
        }
        public IActionResult Marks()
        {
            FindStudent();
            CheckRole();
            return View();
        }
        [HttpPost]
        public ActionResult AddMark(IFormCollection form)
        {
            CheckRole();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var model = new MarksStudents
            {
                ID_Student = Convert.ToInt32(form["student"]),
                Mark = Convert.ToInt32(form["value"]),
                ID_Teacher = Convert.ToInt32(userId),
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.MarksStudents.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при добавлении оценки: " + ex.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Students()
        {
            CheckRole();
            var stud = await _context.Student.ToListAsync();
            return View(stud);
        }
        public async Task<IActionResult> MaterialDescription(int id)
        {
            CheckRole();
            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }
    }
}
