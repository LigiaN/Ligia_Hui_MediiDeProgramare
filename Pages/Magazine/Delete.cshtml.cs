using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ligia_Hui.Models;

namespace Ligia_Hui.Pages.Magazine
{
    public class DeleteModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public DeleteModel(Ligia_Hui.Models.Ligia_HuiContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Magazin = await _context.Magazin.FindAsync(id);

            if (Magazin != null)
            {
                _context.Magazin.Remove(Magazin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
