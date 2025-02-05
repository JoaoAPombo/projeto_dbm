using projeto_dbm.Models;
using Microsoft.EntityFrameworkCore;

namespace projeto_dbm.Data
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
