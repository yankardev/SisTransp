using System;

namespace SisTransp.Dominio.Entidades
{
    public class ViajeListado
    {
        public int IdViaje { get; set; }
        public string Placa { get; set; }
        public string Chofer { get; set; }
        public string Ruta { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string Estado { get; set; }
        public string TieneCombustible { get; set; }
        public string TieneGastos { get; set; }
        public string Descripcion
        {
            get
            {
                return Placa + " - " + Chofer + " - " + Ruta + " - " + Estado;
            }
        }
    }
}