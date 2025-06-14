using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class PaisDestino
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public virtual ICollection<CidadeDestino> Cidades { get; set; }

        public PaisDestino()
        {
            Cidades = new HashSet<CidadeDestino>();
        }
    }
}