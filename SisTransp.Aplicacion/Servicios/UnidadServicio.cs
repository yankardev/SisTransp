using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTransp.Aplicacion.Servicios
{
    public class UnidadServicio
    {
        private readonly IUnidadRepositorio _unidadRepositorio;
        public UnidadServicio()
        {
            _unidadRepositorio = new UnidadRepositorio();
        }

        public List<Unidad> Listar()
        {
            return _unidadRepositorio.Listar();
        }

        public Unidad Obtener(int id)
        {
            return _unidadRepositorio.Obtener(id);
        }

        public void Registrar(Unidad unidad)
        {
            _unidadRepositorio.Registrar(unidad);
        }

        public void Editar(Unidad unidad)
        {
            _unidadRepositorio.Editar(unidad);
        }

        public void Eliminar(int id)
        {
            _unidadRepositorio.Eliminar(id);
        }

        public void CambiarEstado(int id, string estado)
        {
            _unidadRepositorio.CambiarEstado(id,estado);
        }
    }
}
