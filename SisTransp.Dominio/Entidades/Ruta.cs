namespace SisTransp.Dominio.Entidades
{
    public class Ruta
    {
        public int IdRuta { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public decimal DistanciaKm { get; set; }

        public bool Estado { get; set; }
    }
}