using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Pages.PacotesTuristicos
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacotesTuristicos { get; set; }

        public async Task OnGetAsync()
        {
            PacotesTuristicos = await _context.PacotesTuristicos.ToListAsync();
        }
    }
}