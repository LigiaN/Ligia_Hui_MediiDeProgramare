using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ligia_Hui.Models;

namespace Ligia_Hui.Pages.Magazine
{
    public class EditModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public EditModel(Ligia_Hui.Models.Ligia_HuiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Magazin Magazin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Magazin = await _context.Magazin.FirstOrDefaultAsync(m => m.ID == id);

            if (Magazin == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Magazin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazinExists(Magazin.ID))
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

        private bool MagazinExists(int id)
        {
            return _context.Magazin.Any(e => e.ID == id);
        }
    }
}
