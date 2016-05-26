using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

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
            Boolean band = false;
            conexion.abrir();
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand("Login", con);
            comando.CommandType = CommandType.StoredProcedure;
            MySqlDataReader red = comando.ExecuteReader();

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