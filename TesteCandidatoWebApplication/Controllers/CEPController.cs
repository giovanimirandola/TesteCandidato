using Microsoft.AspNetCore.Mvc;
using TesteCandidatoWebApplication.Services.CEPService;

namespace TesteCandidatoWebApplication.Controllers
{
    public class CEPController : Controller
    {
        private readonly ICEPService _cepService;

        public CEPController(ICEPService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string cep)
        {
            var retorno = await _cepService.GetByCep(cep);

            if (retorno == null)
                return View();

            return View(retorno);
        }
    }
}