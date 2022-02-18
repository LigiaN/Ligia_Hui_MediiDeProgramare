using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ligia_Hui.Models;

namespace Ligia_Hui.Pages.Produse
{
    public class DetailsModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public DetailsModel(Ligia_Hui.Models.Ligia_HuiContext context)
        {
            _context = context;
        }

        public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produs = await _context.Produs
                .Include(p => p.Departament)
                .Include(p => p.Magazin).FirstOrDefaultAsync(m => m.ID == id);

            if (Produs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
