using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapataria_de_Sapatos.Models
{
    public class produto
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
    }
    public class genero
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Required]
        public int Id { get; set; }
        [Required]
        public string? Genero { get; set; }
    }
    public class admin
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Required]
        public int Id { get; set; }
        [Required]
        public string? Gerente { get; set; }
        [Required]
        public string? token { get; set; }
    }
    public class loja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Cidade { get; set; }
        [Required]
        public string? Estado { get; set; }
    }
    public class vendedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public List<genero>? GeneroId { get; set; }
        [Required]
        public int MesInicio { get; set; }
        [Required]
        public int AnoInicio { get; set; }
    }
    public class cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public List<genero>? GeneroId { get; set; }
    }
    public class venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public List<produto>? produtoId { get; set; }
        [Required]
        public List<vendedor>? vendedorId { get; set; }
        [Required]
        public List<cliente>? clienteId { get; set; }
    }
}
