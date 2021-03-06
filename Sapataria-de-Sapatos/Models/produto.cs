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
}
