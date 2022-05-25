using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapataria_de_Sapatos.Models
{
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
}
