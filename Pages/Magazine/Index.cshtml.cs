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
    public class IndexModel : PageModel
    {
        private readonly Ligia_Hui.Models.Ligia_HuiContext _context;

        public IndexModel(Ligia_Hui.Models.Ligia_HuiContext context)
        {
            _context = context;
        }

        public IList<Magazin> Magazin { get;set; }

        public async Task OnGetAsync()
        {
            Magazin = await _context.Magazin.ToListAsync();
        }
    }
}
