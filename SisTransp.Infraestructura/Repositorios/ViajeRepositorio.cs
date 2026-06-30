using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Conexion;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SisTransp.Infraestructura.Repositorios
{
    public class ViajeRepositorio : IViajeRepositorio
    {
        ConexionDB conexion = new ConexionDB();

        public List<ViajeListado> Listar()
        {
            List<ViajeListado> lista = new List<ViajeListado>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarViajes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new ViajeListado()
                    {
                        IdViaje = (int)dr["IdViaje"],
                        Placa = dr["Placa"].ToString(),
                        Chofer = dr["Chofer"].ToString(),
                        Ruta = dr["Ruta"].ToString(),
                        FechaSalida = (System.DateTime)dr["FechaSalida"],
                        FechaLlegada = (System.DateTime)dr["FechaLlegada"],
                        Estado = dr["Estado"].ToString(),
                        TieneCombustible = dr["TieneCombustible"].ToString(),
                        TieneGastos = dr["TieneGastos"].ToString()
                    });
                }
            }

            return lista;
        }

        public void Registrar(Viaje viaje)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarViaje", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdUnidad", viaje.IdUnidad);
                cmd.Parameters.AddWithValue("@IdChofer", viaje.IdChofer);
                cmd.Parameters.AddWithValue("@IdRuta", viaje.IdRuta);
                cmd.Parameters.AddWithValue("@FechaSalida", viaje.FechaSalida);
                cmd.Parameters.AddWithValue("@FechaLlegada", viaje.FechaLlegada);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void CambiarEstado(int idViaje, string estado)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_CambiarEstadoViaje", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdViaje", idViaje);
                cmd.Parameters.AddWithValue("@Estado", estado);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}