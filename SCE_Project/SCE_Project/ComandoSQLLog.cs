using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace SCE_Project
{
    public class ComandoSQLLog
    {
        Conexion conexion;
        public void conectar()
        {
            conexion = new Conexion();
        }
        public bool ValidateUser(string id,string contra)
        {
            conexion.abrir();
            Boolean band = false;
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT * from usuario ";
            MySqlDataReader red = query.ExecuteReader();
            //lookupPassword = (string)query.ExecuteScalar();

            while (red.Read())
            {
                if (string.Compare(id, red["IDUsuario"].ToString()) == 0 && string.Compare(contra, red["pass"].ToString()) == 0)
                    band = true;
            }

            if (band)
            {
                conexion.cerrar();
                return true;
            }
            else
            {
                conexion.cerrar();
                return false;
            }
        }
    }
}