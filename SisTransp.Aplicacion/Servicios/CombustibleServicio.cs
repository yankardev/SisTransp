using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Repositorios;
using System.Collections.Generic;

namespace SisTransp.Aplicacion.Servicios
{
    public class CombustibleServicio
    {
        private readonly ICombustibleRepositorio repositorio;

        public CombustibleServicio()
        {
            repositorio = new CombustibleRepositorio();
        }

        public List<CombustibleListado> Listar()
        {
            return repositorio.Listar();
        }

        public void Registrar(Combustible combustible)
        {
            repositorio.Registrar(combustible);
        }
    }
}