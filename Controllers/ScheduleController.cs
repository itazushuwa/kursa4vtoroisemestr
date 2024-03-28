using Microsoft.AspNetCore.Mvc;
using rep.Models;
using System.Reflection.Metadata.Ecma335;

namespace rep.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
