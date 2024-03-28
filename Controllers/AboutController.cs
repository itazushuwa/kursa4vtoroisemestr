using Microsoft.AspNetCore.Mvc;
using rep.Models;

namespace rep.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var teachers = new List<Teacher>
          {
              new Teacher {Id = 1, Name = "ЕвГЕНИЙ", Description = "Учитель по русскому языку"},
              new Teacher {Id = 2, Name = "Аска", Description = "Учитель по литературе"},
          };
            return View(teachers);
        }
    }
}
