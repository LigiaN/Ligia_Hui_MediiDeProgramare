using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ligia_Hui.Models;

namespace Ligia_Hui.Models
{
    public class Ligia_HuiContext : DbContext
    {
        public Ligia_HuiContext (DbContextOptions<Ligia_HuiContext> options)
            : base(options)
        {
        }

        public DbSet<Ligia_Hui.Models.Produs> Produs { get; set; }

        public DbSet<Ligia_Hui.Models.Magazin> Magazin { get; set; }

        public DbSet<Ligia_Hui.Models.Departament> Departament { get; set; }
    }
}
