using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System.Text.RegularExpressions;
using TesteCandidatoWebApplication.Models;
using TesteCandidatoWebApplication.Repositories.CEPRepository;

namespace TesteCandidatoWebApplication.Services.CEPService
{
    public class CEPService : ICEPService
    {
        private readonly ICEPRepository _cepRepository;
        public CEPService(ICEPRepository repository)
        {
            _cepRepository = repository;
        }

        #region GET

        public async Task<List<CEP>> GetAll()
        {
            return await _cepRepository.GetAll();
        }

        public async Task<CEP> GetById(int id)
        {
            var cep = await _cepRepository.GetById(id);

            return cep;
        }

        public async Task<CEP> GetByCep(string cep)
        {
            if (!ValidaCEP(cep))
            {
                return null;
                //return RedirectToAction("Index");
            }

            cep = cep.Replace("-", ""); // usando o padrão do banco, assim, independente do formato digitado pode encontrar no bancoZ

            var cepBanco = await _cepRepository.GetByCEP(cep);
            if (cepBanco == null)
            {
                var cepAPI = await ConsultaAPI(cep);
                if (cepAPI != null)
                {
                    await _cepRepository.AddCEP(cepAPI);
                    return cepAPI;
                }
            }

            return cepBanco;
        }

        public async Task<List<CEP>> GetByLogradouro(string logradouro)
        {
            if (!logradouro.IsNullOrEmpty())
                return await _cepRepository.GetByLogradouro(logradouro);

            return new List<CEP>();
        }


        #endregion

        #region POST

        public async Task<List<CEP>> AddCEP(CEP cep)
        {
            return await _cepRepository.AddCEP(cep);
        }

        #endregion
        
        public async Task<CEP> ConsultaAPI(string cep)
        {
            var client = new RestClient("https://viacep.com.br/ws/");
            var request = new RestRequest($"{cep}/json/", Method.Get);
            var response = await client.ExecuteGetAsync(request);

            if (response.Content is null)
            {
                return null;
            }

            var obj = JsonConvert.DeserializeObject<CEP>(response.Content);
            obj.Cep = obj.Cep.Replace("-", ""); //para padronizar no banco

            return obj;
        }

        public bool ValidaCEP(string cep)
        {
            var formatoValido = new Regex(@"^\d{5}-\d{3}|\d{8}");

            if (cep != null && formatoValido.IsMatch(cep))
            {
                return true;
            }

            return false;
        }

    }

}