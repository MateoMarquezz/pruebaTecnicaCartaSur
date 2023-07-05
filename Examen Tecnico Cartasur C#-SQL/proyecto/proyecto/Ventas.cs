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
    public class Ventas 
    {
        public void Obtener_Lista()
        {
            ConexionSQL conexion1 = new ConexionSQL();

            try
            {
                string cadena = "SELECT TOP 1 Fecha_venta, COUNT(*) as Cantidad_Ventas " +
                                            "FROM ventas " +
                                            "GROUP BY Fecha_venta " +
                                            "ORDER BY Cantidad_Ventas DESC;";
                conexion1.comando = new SqlCommand();
                conexion1.comando.CommandType = CommandType.Text;
                conexion1.comando.CommandText = cadena;
                conexion1.comando.Connection = conexion1.conexion;
                conexion1.conexion.Open();
                conexion1.lector = conexion1.comando.ExecuteReader();

                while (conexion1.lector.Read())
                {
                    Console.WriteLine("Fecha con mayor cantidad de ventas: " + conexion1.lector.GetDateTime(0) + "\nCantidad de ventas maximas de ese dia: " + conexion1.lector.GetInt32(1));
                }
                conexion1.lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conexion1.conexion.State == ConnectionState.Open)
                {
                    conexion1.conexion.Close();
                }
            }

           

        }
    }
}
