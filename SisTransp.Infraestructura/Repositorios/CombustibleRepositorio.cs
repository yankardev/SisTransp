using SisTransp.Dominio.Entidades;
using SisTransp.Dominio.Repositorios;
using SisTransp.Infraestructura.Conexion;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SisTransp.Infraestructura.Repositorios
{
    public class CombustibleRepositorio : ICombustibleRepositorio
    {
        ConexionDB conexion = new ConexionDB();

        public List<CombustibleListado> Listar()
        {
            List<CombustibleListado> lista = new List<CombustibleListado>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarCombustible", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new CombustibleListado()
                    {
                        IdCombustible = (int)dr["IdCombustible"],
                        IdViaje = (int)dr["IdViaje"],
                        Placa = dr["Placa"].ToString(),
                        Chofer = dr["Chofer"].ToString(),
                        Ruta = dr["Ruta"].ToString(),
                        CantidadActual = (decimal)dr["CantidadActual"],
                        CantidadAbastecida = (decimal)dr["CantidadAbastecida"],
                        PrecioGalon = (decimal)dr["PrecioGalon"],
                        Total = (decimal)dr["Total"],
                        FechaRegistro = (System.DateTime)dr["FechaRegistro"]
                    });
                }
            }

            return lista;
        }

        public void Registrar(Combustible combustible)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarCombustible", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdViaje", combustible.IdViaje);
                cmd.Parameters.AddWithValue("@CantidadActual", combustible.CantidadActual);
                cmd.Parameters.AddWithValue("@CantidadAbastecida", combustible.CantidadAbastecida);
                cmd.Parameters.AddWithValue("@PrecioGalon", combustible.PrecioGalon);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}