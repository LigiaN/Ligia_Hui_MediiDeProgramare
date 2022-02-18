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
    public class IndexModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public IndexModel(Ligia_Hui.Models.Ligia_HuiContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; }

        public async Task OnGetAsync()
        {
            Produs = await _context.Produs
                .Include(p => p.Departament)
                .Include(p => p.Magazin).ToListAsync();
        }
    }
}
