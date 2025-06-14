using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaTurismo.Models
{
    public class CidadeDestino
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int PaisId { get; set; }

        [ForeignKey("PaisId")]
        public virtual PaisDestino Pais { get; set; }

        public virtual ICollection<PacoteTuristico> Pacotes { get; set; }

        public CidadeDestino()
        {
            Pacotes = new HashSet<PacoteTuristico>();
        }
    }
}