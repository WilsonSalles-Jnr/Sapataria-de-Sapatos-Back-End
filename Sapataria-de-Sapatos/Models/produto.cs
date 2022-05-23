using System.ComponentModel.DataAnnotations;

namespace Sapataria_de_Sapatos.Models
{
    public class produto
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
