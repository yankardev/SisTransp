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
    public class UnidadRepositorio : IUnidadRepositorio
    {
        ConexionDB conexion = new ConexionDB();
        public void Editar(Unidad unidad)
        {
            using (SqlConnection cn =conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EditarUnidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUnidad",unidad.IdUnidad);
                cmd.Parameters.AddWithValue("@Placa",unidad.Placa);
                cmd.Parameters.AddWithValue("@Marca",unidad.Marca);
                cmd.Parameters.AddWithValue("@Modelo",unidad.Modelo);
                cmd.Parameters.AddWithValue("@CapacidadTanque",unidad.CapacidadTanque);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd =new SqlCommand("sp_EliminarUnidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Unidad> Listar()
        {
            List<Unidad> lista = new List<Unidad>();

            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUnidades", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Unidad
                    {
                        IdUnidad = (int)dr["IdUnidad"],
                        Placa = dr["Placa"].ToString(),
                        Marca = dr["Marca"].ToString(),
                        Modelo = dr["Modelo"].ToString(),
                        CapacidadTanque = (decimal)dr["CapacidadTanque"],
                        Estado = dr["Estado"].ToString()
                    });
                }
            }

            return lista;
        }

        public Unidad Obtener(int id)
        {
            Unidad unidad = null;
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUnidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    unidad = new Unidad
                    {
                        IdUnidad = (int)dr["IdUnidad"],
                        Placa = dr["Placa"].ToString(),
                        Marca = dr["Marca"].ToString(),
                        Modelo = dr["Modelo"].ToString(),
                        CapacidadTanque = (decimal)dr["CapacidadTanque"],
                        Estado = dr["Estado"].ToString()
                    };
                }
            }
            return unidad;
        }

        public void Registrar(Unidad unidad)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUnidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Placa",unidad.Placa);
                cmd.Parameters.AddWithValue("@Marca",unidad.Marca);
                cmd.Parameters.AddWithValue("@Modelo",unidad.Modelo);
                cmd.Parameters.AddWithValue("@CapacidadTanque",unidad.CapacidadTanque);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CambiarEstado(int id,string estado)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                SqlCommand cmd =new SqlCommand("sp_CambiarEstadoUnidad",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUnidad",id);
                cmd.Parameters.AddWithValue("@Estado",estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
