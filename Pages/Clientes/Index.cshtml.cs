using AgenciaTurismo.Data;
using AgenciaTurismo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
    }
}