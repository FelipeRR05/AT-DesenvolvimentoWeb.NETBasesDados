using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

        public bool IsDeleted { get; set; } = false;
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }
    }
}