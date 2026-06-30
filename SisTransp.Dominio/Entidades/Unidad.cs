using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTransp.Dominio.Entidades
{
    public class Unidad
    {
        public int IdUnidad { get; set; }
        [Required(ErrorMessage = "Ingrese placa")]
        [RegularExpression( @"^[A-Z]{3}[0-9]{3}$",ErrorMessage ="Formato VOL001")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Ingrese marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Ingrese modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Ingrese capacidad tanque")]
        [Range(100,240,ErrorMessage ="Debe ser entre 100 y 240")]
        public decimal CapacidadTanque { get; set; }
        public string Estado { get; set; }
    }
}