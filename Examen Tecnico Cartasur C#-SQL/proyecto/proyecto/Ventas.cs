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
            ConexionSQL coneccion = new ConexionSQL();
           // string retorno = "error";

            try
            {
                string cadena = "SELECT TOP 1 Fecha_venta, COUNT(*) as Cantidad_Ventas " +
                                            "FROM ventas " +
                                            "GROUP BY Fecha_venta " +
                                            "ORDER BY Cantidad_Ventas DESC;";
                coneccion.comando = new SqlCommand();
                coneccion.comando.CommandType = CommandType.Text;
                coneccion.comando.CommandText = cadena;
                coneccion.comando.Connection = coneccion.conexion;
                coneccion.conexion.Open();
                coneccion.lector = coneccion.comando.ExecuteReader();

                while (coneccion.lector.Read())
                {
                    //  retorno = coneccion.lector["Fecha_venta"].ToString() + coneccion.lector["Cantidad_Ventas"].ToString();
                    Console.WriteLine("Fecha con mayor cantidad de ventas: " + coneccion.lector.GetDateTime(0) + "\nCantidad de ventas maximas de ese dia: " + coneccion.lector.GetInt32(1));
                }
                coneccion.lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (coneccion.conexion.State == ConnectionState.Open)
                {
                    coneccion.conexion.Close();
                }
            }

            //return retorno;

        }
    }
}
