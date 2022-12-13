using TesteCandidatoWebApplication.Models;

namespace TesteCandidatoWebApplication.Repositories.CEPRepository
{
    public interface ICEPRepository
    {
        #region GET

        Task<List<CEP>> GetAll();
        Task<CEP> GetById(int id);
        Task<CEP> GetByCEP(string cep);
        Task<List<CEP>> GetByLogradouro(string logradouro);

        #endregion

        #region POST

        Task<List<CEP>> AddCEP(CEP cep);
        
        #endregion
    }
}
