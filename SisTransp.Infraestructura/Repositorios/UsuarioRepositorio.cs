using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Conexion;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SisTransp.Infraestructura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        ConexionDB conexion = new ConexionDB();

        public Usuario Login(string correo, string clave)
        {
            Usuario usuario = null;

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = (int)dr["IdUsuario"],
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Rol = dr["Rol"].ToString()
                    };
                }
            }

            return usuario;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Usuario()
                    {
                        IdUsuario = (int)dr["IdUsuario"],
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Clave = dr["Clave"].ToString(),
                        IdRol = (int)dr["IdRol"],
                        Rol = dr["Rol"].ToString(),
                        Estado = (bool)dr["Estado"]
                    });
                }
            }

            return lista;
        }

        public Usuario Obtener(int id)
        {
            Usuario usuario = null;

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = (int)dr["IdUsuario"],
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Clave = dr["Clave"].ToString(),
                        IdRol = (int)dr["IdRol"],
                        Estado = (bool)dr["Estado"]
                    };
                }
            }

            return usuario;
        }

        public void Registrar(Usuario usuario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Editar(Usuario usuario)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@NombreCompleto", usuario.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Rol> ListarRoles()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Rol()
                    {
                        IdRol = (int)dr["IdRol"],
                        Nombre = dr["Nombre"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}