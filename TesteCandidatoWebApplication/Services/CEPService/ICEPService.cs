using Microsoft.AspNetCore.Mvc;
using TesteCandidatoWebApplication.Models;

namespace TesteCandidatoWebApplication.Services.CEPService
{
    public interface ICEPService
    {
        Task<List<CEP>> GetCEPs();
        Task<CEP> GetCEPById(int id);
        Task<List<CEP>> AddCEP(CEP cep);
        bool ValidaCEP(string cep);
        Task<CEP> GetByCep(string cep);
        Task<List<CEP>> GetByLogradouro(string logradouro);
        Task<CEP> ConsultaAPI(string cep);
    }
}
