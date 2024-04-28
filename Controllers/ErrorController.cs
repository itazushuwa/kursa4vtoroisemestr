using Microsoft.AspNetCore.Mvc;

namespace rep.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AunthError()
        {
            return View();
        }
        public IActionResult NotEnoughRights()
        {
            return View();
        }
    }
}
