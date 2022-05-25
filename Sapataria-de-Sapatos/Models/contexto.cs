using Microsoft.EntityFrameworkCore;

namespace Sapataria_de_Sapatos.Models
{
    public class contexto: DbContext
    {
        public contexto(DbContextOptions<contexto> options): base(options) { }
        public DbSet<produto>? Produtos { get; set; }
    }
}
