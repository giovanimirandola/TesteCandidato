using Microsoft.EntityFrameworkCore;
using TesteCandidatoWebApplication.Models;

namespace TesteCandidatoWebApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<CEP> CEPs { get; set; }
    }
}
