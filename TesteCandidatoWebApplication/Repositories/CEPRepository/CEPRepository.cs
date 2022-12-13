using Microsoft.EntityFrameworkCore;
using TesteCandidatoWebApplication.Data;
using TesteCandidatoWebApplication.Models;

namespace TesteCandidatoWebApplication.Repositories.CEPRepository
{
    public class CEPRepository : ICEPRepository
    {
        private readonly DataContext _dbContext;

        public CEPRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public async Task<List<CEP>> GetCEPs()
        {
            return await _dbContext.CEPs.ToListAsync();
        }

        public async Task<CEP> GetCEPById(int id)
        {
            var cep = await _dbContext.CEPs.FindAsync(id);

            if (cep == null)
                return null;

            return cep;
        }

        public async Task<List<CEP>> AddCEP(CEP cep)
        {
            await _dbContext.CEPs.AddAsync(cep);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.CEPs.ToListAsync();
        }

        public async Task<CEP> GetByCEP(string cep)
        {
            var cepBD = await _dbContext.CEPs
                .Where(c => c.Cep.Equals(cep))
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return cepBD;
        }

        public async Task<List<CEP>> GetByLogradouro(string logradouro)
        {
            var cepBD = await _dbContext.CEPs
                .Where(c => c.Logradouro.Contains(logradouro))
                .ToListAsync();
            return cepBD;
        }
    }
}
