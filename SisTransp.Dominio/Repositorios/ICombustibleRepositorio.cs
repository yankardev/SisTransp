using SisTransp.Dominio.Entidades;
using System.Collections.Generic;

namespace SisTransp.Dominio.Repositorios
{
    public interface ICombustibleRepositorio
    {
        List<CombustibleListado> Listar();

        void Registrar(Combustible combustible);
    }
}