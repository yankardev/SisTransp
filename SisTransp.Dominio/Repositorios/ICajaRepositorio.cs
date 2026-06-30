using SisTransp.Dominio.Entidades;
using System.Collections.Generic;

namespace SisTransp.Dominio.Repositorios
{
    public interface ICajaRepositorio
    {
        List<CajaListado> Listar();

        void Registrar(Caja caja);
    }
}