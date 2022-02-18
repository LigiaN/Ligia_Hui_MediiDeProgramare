using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ligia_Hui.Models;

namespace Ligia_Hui.Pages.Produse
{
    public class EditModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public EditModel(Ligia_Hui.Models.Ligia_HuiContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "dep");
           ViewData["MagazinID"] = new SelectList(_context.Set<Magazin>(), "ID", "mag");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(Produs.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProdusExists(int id)
        {
            return _context.Produs.Any(e => e.ID == id);
        }
    }
}
