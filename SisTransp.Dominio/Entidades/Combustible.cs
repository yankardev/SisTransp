using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTransp.Dominio.Entidades
{
    public class Combustible
    {
        public int IdCombustible { get; set; }
        public int IdViaje { get; set; }
        public decimal CantidadActual { get; set; }
        public decimal CantidadAbastecida { get; set; }
        public decimal PrecioGalon { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
