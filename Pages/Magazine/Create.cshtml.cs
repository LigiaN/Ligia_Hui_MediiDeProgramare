using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ligia_Hui.Models;

namespace Ligia_Hui.Pages.Magazine
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
            return Page();
        }

        [BindProperty]
        public Magazin Magazin { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Magazin.Add(Magazin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}