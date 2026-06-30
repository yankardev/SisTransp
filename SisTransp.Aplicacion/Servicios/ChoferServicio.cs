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
    public class ChoferServicio
    {
        private readonly IChoferRepositorio _choferRepositorio;
        public ChoferServicio()
        {
            _choferRepositorio = new ChoferRepositorio();
        }
        public List<Chofer> Listar()
        {
            return _choferRepositorio.Listar();
        }
        public Chofer Obtener(int id)
            {
                return _choferRepositorio.Obtener(id);
        }
        public void Registrar(Chofer chofer)
        {
            _choferRepositorio.Registrar(chofer);
        }
        public void Editar(Chofer chofer)
        {
            _choferRepositorio.Editar(chofer);
        }
        public void Eliminar(int id)
        {
            _choferRepositorio.Eliminar(id);
        }
    }
}
