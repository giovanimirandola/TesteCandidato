using Microsoft.AspNetCore.Mvc;
using TesteCandidatoWebApplication.Models;

namespace TesteCandidatoWebApplication.Services.CEPService
{
    public interface ICEPService
    {
        #region GET

        Task<List<CEP>> GetAll();
        Task<CEP> GetById(int id);
        Task<CEP> GetByCep(string cep);
        Task<List<CEP>> GetByLogradouro(string logradouro);

        #endregion

        #region POST
        Task<List<CEP>> AddCEP(CEP cep);

        #endregion

        Task<CEP> ConsultaAPI(string cep);

        bool ValidaCEP(string cep);

    }
}
