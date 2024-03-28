using Microsoft.AspNetCore.Mvc;
using rep.Models;

namespace rep.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            var courses = new List<Course>
          {
              new Course {Code = 1, Name = "Русский язык", Description = "Курс по русскому языку", Price = 1000},
              new Course {Code = 2, Name = "Литература", Description = "Курс по литературе", Price = 1200},
          };
            return View(courses);
        }
    }
}
