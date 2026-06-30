using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Repositorios;
using System.Collections.Generic;

namespace SisTransp.Aplicacion.Servicios
{
    public class ViajeServicio
    {
        private readonly IViajeRepositorio repositorio;

        public ViajeServicio()
        {
            repositorio = new ViajeRepositorio();
        }

        public List<ViajeListado> Listar()
        {
            return repositorio.Listar();
        }

        public void Registrar(Viaje viaje)
        {
            repositorio.Registrar(viaje);
        }

        public void CambiarEstado(int idViaje, string estado)
        {
            repositorio.CambiarEstado(idViaje, estado);
        }
    }
}