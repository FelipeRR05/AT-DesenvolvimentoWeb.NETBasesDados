using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaTurismo.Models
{
    public class PacoteTuristico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public int DuracaoDias { get; set; }

        [Required]
        [Range(1, 100)]
        public int CapacidadeMaxima { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        public virtual ICollection<CidadeDestino> Destinos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }

        public PacoteTuristico()
        {
            Destinos = new HashSet<CidadeDestino>();
            Reservas = new HashSet<Reserva>();
        }
    }
}