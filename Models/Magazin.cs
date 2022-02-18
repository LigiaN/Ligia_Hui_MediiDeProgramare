using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ligia_Hui.Models
{
    public class Magazin
    {
        public int ID { get; set; }

        [Display(Name = "Nume Magazin")]
        [Required(ErrorMessage = "Va rog sa completati campul.."), MinLength(3, ErrorMessage = "Necesar minim trei caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string mag { get; set; }
        public ICollection<DepMag> DepMag { get; set; }
    }
}
