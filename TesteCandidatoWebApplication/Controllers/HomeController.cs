using Microsoft.AspNetCore.Mvc;

namespace TesteCandidatoWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
