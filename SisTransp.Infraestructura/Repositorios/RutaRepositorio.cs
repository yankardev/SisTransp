using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Conexion;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SisTransp.Infraestructura.Repositorios
{
    public class RutaRepositorio : IRutaRepositorio
    {
        ConexionDB conexion = new ConexionDB();

        public List<Ruta> Listar()
        {
            List<Ruta> lista = new List<Ruta>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarRutas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Ruta()
                    {
                        IdRuta = (int)dr["IdRuta"],
                        Origen = dr["Origen"].ToString(),
                        Destino = dr["Destino"].ToString(),
                        DistanciaKm = (decimal)dr["DistanciaKm"],
                        Estado = (bool)dr["Estado"]
                    });
                }
            }

            return lista;
        }

        public Ruta Obtener(int id)
        {
            Ruta ruta = null;

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRuta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ruta = new Ruta()
                    {
                        IdRuta = (int)dr["IdRuta"],
                        Origen = dr["Origen"].ToString(),
                        Destino = dr["Destino"].ToString(),
                        DistanciaKm = (decimal)dr["DistanciaKm"],
                        Estado = (bool)dr["Estado"]
                    };
                }
            }

            return ruta;
        }

        public void Registrar(Ruta ruta)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarRuta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Origen", ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino", ruta.Destino);
                cmd.Parameters.AddWithValue("@DistanciaKm", ruta.DistanciaKm);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Editar(Ruta ruta)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarRuta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdRuta", ruta.IdRuta);
                cmd.Parameters.AddWithValue("@Origen", ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino", ruta.Destino);
                cmd.Parameters.AddWithValue("@DistanciaKm", ruta.DistanciaKm);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarRuta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}