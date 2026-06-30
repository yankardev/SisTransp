using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SisTransp.Dominio.Entidades
{
    public class Chofer
    {
        public int IdChofer { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; } 
        [Required(ErrorMessage = "Ingrese licencia")]
        [RegularExpression(@"^[A-Z]{1}[0-9]{8}$", ErrorMessage = "Formato A12345678")]
        public string Licencia { get; set; }
        [Required(ErrorMessage = "Ingrese teléfono")]
        [RegularExpression(@"^9\d{8}$",ErrorMessage ="Debe iniciar con 9 y tener 9 dígitos")]
        public string Telefono { get; set; }
        public bool Estado { get; set; }

    }
}
