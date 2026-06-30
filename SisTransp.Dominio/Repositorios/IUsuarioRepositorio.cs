using SisTransp.Dominio.Entidades;
using System.Collections.Generic;

namespace SisTransp.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario Login(string correo, string clave);

        List<Usuario> Listar();

        Usuario Obtener(int id);

        void Registrar(Usuario usuario);

        void Editar(Usuario usuario);

        List<Rol> ListarRoles();
    }
}