using System;

namespace SisTransp.Dominio.Entidades
{
    public class Viaje
    {
        public int IdViaje { get; set; }
        public int IdUnidad { get; set; }
        public int IdChofer { get; set; }
        public int IdRuta { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string Estado { get; set; }
    }
}