using Microsoft.AspNetCore.Mvc;
using TesteCandidatoWebApplication.Services.CEPService;

namespace TesteCandidatoWebApplication.Controllers
{
    public class CEPController : Controller
    {
        private readonly ILogger<CEPController> _logger;
        private readonly ICEPService _cepService;

        public CEPController(ILogger<CEPController> logger, ICEPService cepService)
        {
            _logger = logger;
            _cepService = cepService;
        }

        public async Task<IActionResult> Index()
        {
            //Console.WriteLine("\nDeseja buscar o logradouro no banco de dados? S/N");
            //string resposta = Console.ReadLine();

            //if (resposta.Equals("S") || resposta.Equals("s"))
            //{
            //    Console.WriteLine("\nInforme o logradouro:");
            //    string logradouro = Console.ReadLine();

            //}

            //Console.WriteLine("\nInforme o CEP: ");
            //string cep = Console.ReadLine();

            //if (TesteValidaCep(cep))
            //{
            //    cep = cep.Replace("-", ""); // usando o padrão do banco, assim, independente do formato digitado pode encontrar no banco

            //    var cepBanco = await TesteCEPBanco(cep);
            //    if (cepBanco == null)
            //    {
            //        var cepAPI = await TesteRestSharp(cep);
            //        if (cepAPI != null)
            //        {
            //            await _cepService.AddCEP(cepAPI);
            //        }
            //    }
            //}

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CEP(string cep)
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

        [HttpPost]
        public async Task<IActionResult> Logradouro(string logradouro)
        {
            var ceps = await _cepService.GetByLogradouro(logradouro);

            return View(ceps);
        }
    }
}