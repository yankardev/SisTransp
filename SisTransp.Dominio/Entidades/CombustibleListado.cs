using System;

namespace SisTransp.Dominio.Entidades
{
    public class CombustibleListado
    {
        public int IdCombustible { get; set; }
        public int IdViaje { get; set; }
        public string Placa { get; set; }
        public string Chofer { get; set; }
        public string Ruta { get; set; }
        public decimal CantidadActual { get; set; }
        public decimal CantidadAbastecida { get; set; }
        public decimal PrecioGalon { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}