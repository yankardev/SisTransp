using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Repositorios;
using System.Collections.Generic;

namespace SisTransp.Aplicacion.Servicios
{
    public class RutaServicio
    {
        private readonly IRutaRepositorio repositorio;

        public RutaServicio()
        {
            repositorio = new RutaRepositorio();
        }

        public List<Ruta> Listar()
        {
            return repositorio.Listar();
        }

        public Ruta Obtener(int id)
        {
            return repositorio.Obtener(id);
        }

        public void Registrar(Ruta ruta)
        {
            repositorio.Registrar(ruta);
        }

        public void Editar(Ruta ruta)
        {
            repositorio.Editar(ruta);
        }

        public void Eliminar(int id)
        {
            repositorio.Eliminar(id);
        }
    }
}