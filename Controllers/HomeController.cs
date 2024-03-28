using Microsoft.AspNetCore.Mvc;
using rep.ViewModels;

namespace rep.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                WelcomeMessage = "Welcome to Shkolkovo"

            };
            return View(viewModel);
        }
    }
}
