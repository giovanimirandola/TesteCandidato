using TesteCandidatoWebApplication.Models;

namespace TesteCandidatoWebApplication.Repositories.CEPRepository
{
    public interface ICEPRepository
    {
        Task<List<CEP>> GetCEPs();
        Task<CEP> GetCEPById(int id);
        Task<List<CEP>> AddCEP(CEP cep);
        Task<CEP> GetByCEP(string cep);
        Task<List<CEP>> GetByLogradouro(string logradouro);
    }
}
