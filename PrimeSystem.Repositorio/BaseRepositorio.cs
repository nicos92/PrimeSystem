using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace PrimeSystem.Repositorio
{
    public abstract class BaseRepositorio
    {
        private readonly string cadenaConexion;

        protected BaseRepositorio()
        {
            cadenaConexion = cadenaConexion = ConfigurationManager.ConnectionStrings["msaccess"].ConnectionString;
        }
        [SupportedOSPlatform("windows")]
        protected OleDbConnection Conexion()
        {
            return new OleDbConnection(cadenaConexion);
        }
        
    }
}