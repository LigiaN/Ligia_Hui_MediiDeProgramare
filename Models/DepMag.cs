using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligia_Hui.Models
{
    public class DepMag
    {
        public int DepMagID { get; set; }
        public int ProdusID { get; set; }
        public int DepartamentID { get; set; }
        public Departament Departament { get; set; }

        public int MagazinID { get; set; }
        public Magazin Magazin { get; set; }
    }
}
