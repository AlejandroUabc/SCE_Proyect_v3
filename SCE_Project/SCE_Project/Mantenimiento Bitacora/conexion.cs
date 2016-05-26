using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace SCE_Project.Mantenimienro_Bitacora
{
    public class conexion
    {


        MySqlConnection conector = null;

        public void abrir()
        {
            conector = new MySqlConnection();
            string str = "server=MYSQL5017.myASP.NET; Database=DB_9FDF4B_CLANDS; Uid=9fdf4b_clands; password=landsberg100;";
            conector.ConnectionString = str;
            conector.Open();
        }
        public void cerrar()
        {
            conector.Close();
        }
        public MySqlConnection getConexion()
        {
            return conector;
        }



    }


}