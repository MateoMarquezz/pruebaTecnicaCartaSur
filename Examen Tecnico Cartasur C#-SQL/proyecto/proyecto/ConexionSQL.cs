using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace proyecto
{
    public class ConexionSQL
    {
        public SqlConnection conexion; 
        public SqlCommand comando;
        public SqlDataReader? lector;
        public SqlDataAdapter adaptador;
        #region Constructor
        public ConexionSQL()
        {
            var builder = new SqlConnectionStringBuilder(
                @"Data Source=ROOTS\SQLEXPRESS;
                Database=cartaSurPasantia;
                Trusted_Connection=True;"); ;
            builder.TrustServerCertificate = true; // Desactivar la validación del certificado
            this.conexion = new SqlConnection(builder.ToString());
            this.comando = new SqlCommand();
            this.adaptador = new SqlDataAdapter();
            this.comando.CommandType = CommandType.Text;
            this.comando.Connection = this.conexion;
        }
        #endregion

    }
}