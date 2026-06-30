using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SisTransp.Infraestructura.Conexion
{
    public class ConexionDB
    {
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["cadena"].ConnectionString
            );
        }
    }
}
