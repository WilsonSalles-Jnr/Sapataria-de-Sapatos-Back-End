using Microsoft.EntityFrameworkCore;

namespace Sapataria_de_Sapatos.Models
{
    public class contexto: DbContext
    {
        public contexto(DbContextOptions<contexto> options): base(options) { }
        public DbSet<produto>? Produtos { get; set; }
        public DbSet<loja>? Lojas { get; set; }
        public DbSet<genero>? Generos { get; set; }
        public DbSet<admin>? Admins { get; set; }
        public DbSet<vendedor>? Vendedores { get; set; }
        public DbSet<cliente>? Clientes { get; set; }
        public DbSet<venda>? Vendas { get; set; }
    }
}
