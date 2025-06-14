using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using AgenciaTurismo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Pages
{
    public class CreateCidadeDestinoModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateCidadeDestinoModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreateCidadeViewModel CidadeVM { get; set; }

        public SelectList PaisesSelectList { get; set; }
        public string Message { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadPaisesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadPaisesAsync();
                return Page();
            }

            var novaCidade = new CidadeDestino
            {
                Nome = CidadeVM.Nome,
                PaisId = CidadeVM.PaisId
            };

            _context.CidadesDestino.Add(novaCidade);
            await _context.SaveChangesAsync();

            Message = $"A cidade '{novaCidade.Nome}' foi cadastrada com sucesso!";

            await LoadPaisesAsync();
            CidadeVM = new CreateCidadeViewModel();
            ModelState.Clear();

            return Page();
        }

        private async Task LoadPaisesAsync()
        {
            PaisesSelectList = new SelectList(
                await _context.PaisesDestino.OrderBy(p => p.Nome).ToListAsync(),
                "Id",
                "Nome"
            );
        }
    }
}