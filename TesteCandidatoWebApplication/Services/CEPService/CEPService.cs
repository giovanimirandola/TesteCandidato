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
        private readonly ICEPRepository _repository;
        public CEPService(ICEPRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CEP>> GetCEPs()
        {
            return await _repository.GetCEPs();
        }

        public async Task<CEP> GetCEPById(int id)
        {
            var cep = await _repository.GetCEPById(id);

            return cep;
        }

        public async Task<List<CEP>> AddCEP(CEP cep)
        {
            return await _repository.AddCEP(cep);
        }

        public async Task<CEP> GetByCep(string cep)
        {
            if (!cep.IsNullOrEmpty())
                return await _repository.GetByCEP(cep);

            return null;
        }

        public async Task<List<CEP>> GetByLogradouro(string logradouro)
        {
            if (!logradouro.IsNullOrEmpty())
                return await _repository.GetByLogradouro(logradouro);

            return new List<CEP>();
        }

        public bool ValidaCEP(string cep)
        {
            var regFormato1 = new Regex(@"^\d{5}-\d{3}");
            var regFormato2 = new Regex(@"^\d{8}");

            if (regFormato1.IsMatch(cep) || regFormato2.IsMatch(cep))
            {
                return true;
            }

            return false;
        }

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


    }

}