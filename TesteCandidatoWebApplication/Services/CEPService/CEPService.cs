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
            if (!cep.IsNullOrEmpty())
                return await _cepRepository.GetByCEP(cep);

            return null;
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
            var regFormato1 = new Regex(@"^\d{5}-\d{3}");
            var regFormato2 = new Regex(@"^\d{8}");

            if (regFormato1.IsMatch(cep) || regFormato2.IsMatch(cep))
            {
                return true;
            }

            return false;
        }

    }

}