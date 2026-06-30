using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Repositorios;
using System.Collections.Generic;

namespace SisTransp.Aplicacion.Servicios
{
    public class CajaServicio
    {
        private readonly ICajaRepositorio repositorio;

        public CajaServicio()
        {
            repositorio = new CajaRepositorio();
        }

        public List<CajaListado> Listar()
        {
            return repositorio.Listar();
        }

        public void Registrar(Caja caja)
        {
            repositorio.Registrar(caja);
        }
    }
}