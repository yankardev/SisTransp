using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Conexion;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SisTransp.Infraestructura.Repositorios
{
    public class CajaRepositorio : ICajaRepositorio
    {
        ConexionDB conexion = new ConexionDB();

        public List<CajaListado> Listar()
        {
            List<CajaListado> lista = new List<CajaListado>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarCaja", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new CajaListado()
                    {
                        IdCaja = (int)dr["IdCaja"],
                        IdViaje = (int)dr["IdViaje"],
                        Placa = dr["Placa"].ToString(),
                        Chofer = dr["Chofer"].ToString(),
                        Ruta = dr["Ruta"].ToString(),
                        Peajes = (decimal)dr["Peajes"],
                        Viaticos = (decimal)dr["Viaticos"],
                        Hospedaje = (decimal)dr["Hospedaje"],
                        OtrosGastos = (decimal)dr["OtrosGastos"],
                        TotalGastos = (decimal)dr["TotalGastos"],
                        FechaRegistro = (System.DateTime)dr["FechaRegistro"]
                    });
                }
            }

            return lista;
        }

        public void Registrar(Caja caja)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarCaja", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdViaje", caja.IdViaje);
                cmd.Parameters.AddWithValue("@Peajes", caja.Peajes);
                cmd.Parameters.AddWithValue("@Viaticos", caja.Viaticos);
                cmd.Parameters.AddWithValue("@Hospedaje", caja.Hospedaje);
                cmd.Parameters.AddWithValue("@OtrosGastos", caja.OtrosGastos);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}