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

        [HttpPost]
        public async Task<IActionResult> Index(string cep)
        {
            if (!_cepService.ValidaCEP(cep))
            {
                return RedirectToAction("Index");
            }

            cep = cep.Replace("-", ""); // usando o padrão do banco, assim, independente do formato digitado pode encontrar no banco

            var cepBanco = await _cepService.GetByCep(cep);
            if (cepBanco == null)
            {
                var cepAPI = await _cepService.ConsultaAPI(cep);
                if (cepAPI != null)
                {
                    await _cepService.AddCEP(cepAPI);
                    return View(cepAPI);
                }
            }

            return View(cepBanco);
        }
    }
}