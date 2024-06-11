using Microsoft.AspNetCore.Mvc;

namespace rep.Controllers
{
    //asdasd
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
