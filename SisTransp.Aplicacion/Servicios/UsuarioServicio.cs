using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Repositorios;
using System.Collections.Generic;

namespace SisTransp.Aplicacion.Servicios
{
    public class UsuarioServicio
    {
        private readonly IUsuarioRepositorio repositorio;

        public UsuarioServicio()
        {
            repositorio = new UsuarioRepositorio();
        }

        public Usuario Login(string correo, string clave)
        {
            return repositorio.Login(correo, clave);
        }

        public List<Usuario> Listar()
        {
            return repositorio.Listar();
        }

        public Usuario Obtener(int id)
        {
            return repositorio.Obtener(id);
        }

        public void Registrar(Usuario usuario)
        {
            repositorio.Registrar(usuario);
        }

        public void Editar(Usuario usuario)
        {
            repositorio.Editar(usuario);
        }

        public List<Rol> ListarRoles()
        {
            return repositorio.ListarRoles();
        }
    }
}