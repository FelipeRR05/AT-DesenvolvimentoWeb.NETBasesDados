using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Data;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Pages.Paises
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismo.Data.AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<PaisDestino> PaisDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PaisDestino = await _context.PaisesDestino.ToListAsync();
        }
    }
}
