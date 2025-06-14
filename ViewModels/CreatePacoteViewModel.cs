using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.ViewModels
{
    public class CreatePacoteViewModel
    {
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
        public decimal Preco { get; set; }

        public List<int> SelectedDestinos { get; set; } = new List<int>();
    }

    public class AssignedDestinoData
    {
        public int DestinoId { get; set; }
        public string Nome { get; set; }
        public bool Assigned { get; set; }
    }
}