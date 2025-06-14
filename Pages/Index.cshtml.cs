using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacotesEmDestaque { get; set; }

        public async Task OnGetAsync()
        {
            PacotesEmDestaque = await _context.PacotesTuristicos
                .Where(p => p.DataInicio > DateTime.Now)
                .OrderBy(p => p.DataInicio)
                .Take(3)
                .ToListAsync();
        }
    }
}