using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace SCE_Project
{
    public class Conexion
    {
        MySqlConnection csb = null;
        public void abrir()
        {
            csb = new MySqlConnection();
            string str = "server=MYSQL5017.myASP.NET; Database=DB_9FDF4B_CLANDS; Uid=9fdf4b_clands; password=landsberg100;";
            csb.ConnectionString = str;
            csb.Open();
        }
        public void cerrar()
        {
            csb.Close();
        }
        public MySqlConnection getConexion()
        {
            return csb;
        }

    }
}