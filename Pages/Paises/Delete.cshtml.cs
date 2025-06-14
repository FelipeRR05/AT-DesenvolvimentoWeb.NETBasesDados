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
    public class DeleteModel : PageModel
    {
        private readonly AgenciaTurismo.Data.AgenciaTurismoContext _context;

        public DeleteModel(AgenciaTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaisDestino PaisDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisdestino = await _context.PaisesDestino.FirstOrDefaultAsync(m => m.Id == id);

            if (paisdestino == null)
            {
                return NotFound();
            }
            else
            {
                PaisDestino = paisdestino;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisdestino = await _context.PaisesDestino.FindAsync(id);
            if (paisdestino != null)
            {
                PaisDestino = paisdestino;
                _context.PaisesDestino.Remove(PaisDestino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
