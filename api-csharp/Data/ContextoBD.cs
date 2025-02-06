using Microsoft.EntityFrameworkCore;
using projeto_dbm.Models;

namespace projeto_dbm.Data
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) 
        {
            // Garante que o banco de dados seja criado ao iniciar a aplicação
            Database.Migrate(); 
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
