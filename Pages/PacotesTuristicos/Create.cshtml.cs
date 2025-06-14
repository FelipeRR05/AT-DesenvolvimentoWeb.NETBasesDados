using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using AgenciaTurismo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Pages.PacotesTuristicos
{
    public class CreateModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatePacoteViewModel PacoteVM { get; set; }

        public List<AssignedDestinoData> DestinosData { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateAssignedDestinoData();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateAssignedDestinoData();
                return Page();
            }

            var novoPacote = new PacoteTuristico
            {
                Titulo = PacoteVM.Titulo,
                Descricao = PacoteVM.Descricao,
                DataInicio = PacoteVM.DataInicio,
                DuracaoDias = PacoteVM.DuracaoDias,
                CapacidadeMaxima = PacoteVM.CapacidadeMaxima,
                Preco = PacoteVM.Preco
            };

            if (PacoteVM.SelectedDestinos != null)
            {
                foreach (var destinoId in PacoteVM.SelectedDestinos)
                {
                    var destinoToAdd = await _context.CidadesDestino.FindAsync(destinoId);
                    if (destinoToAdd != null) novoPacote.Destinos.Add(destinoToAdd);
                }
            }

            _context.PacotesTuristicos.Add(novoPacote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task PopulateAssignedDestinoData()
        {
            var allDestinos = await _context.CidadesDestino.ToListAsync();
            DestinosData = new List<AssignedDestinoData>();
            foreach (var destino in allDestinos)
            {
                DestinosData.Add(new AssignedDestinoData
                {
                    DestinoId = destino.Id,
                    Nome = destino.Nome,
                    Assigned = false
                });
            }
        }
    }
}