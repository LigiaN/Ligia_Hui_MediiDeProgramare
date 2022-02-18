using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ligia_Hui.Models
{
    public class Produs
    {
        public int ID { get; set; }

        [Display(Name = "Nume Produs")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]

        public string numeangajat { get; set; }


        [Display(Name = "Descriere Produs")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(2, ErrorMessage = "Necesar minim 2 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string post { get; set; }

        [Display(Name = "Departament")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        public int DepartamentID { get; set; }
        public Departament Departament { get; set; }

        [Display(Name = "Magazin")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        public int MagazinID { get; set; }
        public Magazin Magazin { get; set; }

    }
}
