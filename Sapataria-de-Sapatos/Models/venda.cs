using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapataria_de_Sapatos.Models
{
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
