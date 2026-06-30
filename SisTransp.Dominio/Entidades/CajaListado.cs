using System;

namespace SisTransp.Dominio.Entidades
{
    public class CajaListado
    {
        public int IdCaja { get; set; }
        public int IdViaje { get; set; }
        public string Placa { get; set; }
        public string Chofer { get; set; }
        public string Ruta { get; set; }
        public decimal Peajes { get; set; }
        public decimal Viaticos { get; set; }
        public decimal Hospedaje { get; set; }
        public decimal OtrosGastos { get; set; }
        public decimal TotalGastos { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}