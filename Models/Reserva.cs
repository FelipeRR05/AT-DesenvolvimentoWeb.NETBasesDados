using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaTurismo.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataReserva { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int PacoteTuristicoId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("PacoteTuristicoId")]
        public virtual PacoteTuristico PacoteTuristico { get; set; }
    }
}