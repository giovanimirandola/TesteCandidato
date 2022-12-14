using Microsoft.AspNetCore.Mvc;
using TesteCandidatoWebApplication.Services.CEPService;

namespace TesteCandidatoWebApplication.Controllers
{
    public class LogradouroController : Controller
    {
        private readonly ICEPService _cepService;

        public LogradouroController(ICEPService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string logradouro)
        {
            var ceps = await _cepService.GetByLogradouro(logradouro);

            return View(ceps);
        }
    }
}
