using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ligia_Hui.Models;

namespace Ligia_Hui.Pages.Produse
{
    public class CreateModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public CreateModel(Ligia_Hui.Models.Ligia_HuiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "dep");
        ViewData["MagazinID"] = new SelectList(_context.Set<Magazin>(), "ID", "mag");
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}