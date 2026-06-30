using SisTransp.Dominio.Entidades;
using System.Collections.Generic;

namespace SisTransp.Dominio.Repositorios
{
    public interface IViajeRepositorio
    {
        List<ViajeListado> Listar();

        void Registrar(Viaje viaje);

        void CambiarEstado(int idViaje, string estado);
    }
}