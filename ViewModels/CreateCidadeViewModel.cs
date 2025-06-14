using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.ViewModels
{
    public class CreateCidadeViewModel
    {
        [Display(Name = "Nome da Cidade")]
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "É obrigatório selecionar um país.")]
        [Range(1, int.MaxValue, ErrorMessage = "É obrigatório selecionar um país.")]
        public int PaisId { get; set; }
    }
}