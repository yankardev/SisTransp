using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisTransp.Infraestructura.Repositorios
{
    public class ChoferRepositorio : IChoferRepositorio
    {
        ConexionDB conexion = new ConexionDB();
        public void Editar(Chofer chofer)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarChofer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdChofer", chofer.IdChofer);
                cmd.Parameters.AddWithValue("@NombreCompleto", chofer.NombreCompleto);
                cmd.Parameters.AddWithValue("@Licencia", chofer.Licencia);
                cmd.Parameters.AddWithValue("@Telefono", chofer.Telefono);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarChofer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Chofer> Listar()
        {
            List<Chofer> lista = new List<Chofer>();
            using(SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarChoferes", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Chofer()
                    {
                        IdChofer = Convert.ToInt32(dr["IdChofer"]),
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Licencia = dr["Licencia"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])

                    }
                   );
                }
            }
            return lista;
        }

        public Chofer Obtener(int id)
        {
            Chofer chofer = null;
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerChofer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    chofer = new Chofer()
                    {
                        IdChofer = (int)dr["IdChofer"],
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Licencia = dr["Licencia"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Estado = (bool)dr["Estado"]
                    };
                }
            }
            return chofer;
        }

        public void Registrar(Chofer chofer)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarChofer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreCompleto",chofer.NombreCompleto);
                cmd.Parameters.AddWithValue("@Licencia", chofer.Licencia);
                cmd.Parameters.AddWithValue("@Telefono", chofer.Telefono);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
