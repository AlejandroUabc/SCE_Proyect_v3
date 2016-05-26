using SCE_Project.Mantenimienro_Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace SCE_Project.Consulta_reportes
{
    public class ComandoSQLCon
    {
        Conexion conexion;
        static MySqlDataReader re;
        Consultar_reportes cr = new Consultar_reportes();

        string fecha;

        public void conectar()
        {
            //se crea un objeto para realizar la conexion a la base de datos
            conexion = new Conexion();
        }
        public void queryExecute(string query)
        {
            //el metodo queryExecute es para extraer el query para la conexion con la base de datos
            conexion.abrir();
            MySqlConnection connection = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, connection);
            comando.ExecuteNonQuery();
            conexion.cerrar();
        }

       
        public List<TiempoRuta> consultaTiempoenRuta(string fechaInic, string fechaFin)
        {
            //el metodo consultaTiempoenRuta hace una consulta a la base de datos y regresa una lista de valores
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand("ConsultaTiempoRuta", conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@fechaInic", fechaInic);
            comando.Parameters.AddWithValue("@fechaFin", fechaFin);
            MySqlDataReader red = comando.ExecuteReader();
            TiempoRuta bit;
            List<TiempoRuta> lista1 = new List<TiempoRuta>();

            while (red.Read())
            {
                bit = new TiempoRuta();

                bit.Nombre = (red["nomUsu"].ToString());
                bit.Fecha = (red["fecha"].ToString());
                string hSal = (red["hs"].ToString());
                string hRef = (red["hr"].ToString());
                String[] sHSal = hSal.Split(':');
                String[] sHRef = hRef.Split(':');
                int aux1 = (Convert.ToInt16(sHRef[0]) - Convert.ToInt16(sHSal[0])) * 60;
                int aux2 = (Convert.ToInt16(sHRef[1]) - Convert.ToInt16(sHSal[1]));
                bit.TiempoEnRuta = aux1 + aux2 + "";
                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }

        public List<KilometrosRecorridos> consultaKmRecorrido(string fechaInic, string fechaFin)
        {
            //el metodo consultaTiempoenRuta hace una consulta a la base de datos y regresa una lista de valores
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand("ConsultaKmRecorrido", conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@fechaInic", fechaInic);
            comando.Parameters.AddWithValue("@fechaFin", fechaFin);
            MySqlDataReader red = comando.ExecuteReader();
            KilometrosRecorridos bit;
            List<KilometrosRecorridos> lista1 = new List<KilometrosRecorridos>();
            while (red.Read())
            {
                bit = new KilometrosRecorridos();
                bit.Nombre = (red["nomUsu"].ToString());
                bit.Fecha = (red["fecha"].ToString());
                int kmi = Convert.ToInt32(red["kmInic"].ToString());
                int kmf = Convert.ToInt32(red["kmFin"].ToString());
                bit.KmRecorridos = kmf - kmi + "";
                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }

        public List<NumeroRutas> consultaNumOrdenes(string fechaInic, string fechaFin)
        {
            //el metodo consultaTiempoenRuta hace una consulta a la base de datos y regresa una lista de valores
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand("consultaNumOrdenes", conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@fechaInic", fechaInic);
            comando.Parameters.AddWithValue("@fechaFin", fechaFin);
            MySqlDataReader red = comando.ExecuteReader();
            NumeroRutas bit;
            List<NumeroRutas> lista1 = new List<NumeroRutas>();
            while (red.Read())
            {
                bit = new NumeroRutas();
                bit.NoOrden = (red["noRuta"].ToString());
                bit.Nombre = (red["nomUsu"].ToString());
                bit.Fecha = (red["fecha"].ToString());
                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }

        public List<EstadisticasGenerales> consultaEstGen(string fechaInic, string fechaFin)
        {
            //el metodo hace una consulta a la base de datos y regresa una lista de valores
            //el metodo consultaTiempoenRuta hace una consulta a la base de datos y regresa una lista de valores
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand("consultaEstGen", conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@fechaInic", fechaInic);
            comando.Parameters.AddWithValue("@fechaFin", fechaFin);
            MySqlDataReader red = comando.ExecuteReader();
            EstadisticasGenerales bit;
            List<EstadisticasGenerales> lista1 = new List<EstadisticasGenerales>();
            while (red.Read())
            {
                bit = new EstadisticasGenerales();
                bit.Nombre = (red["nomUsu"].ToString());
                bit.Fecha = (red["fecha"].ToString());
                string hSal = (red["hs"].ToString());
                string hRef = (red["hr"].ToString());
                String[] sHSal = hSal.Split(':');
                String[] sHRef = hRef.Split(':');
                int aux1 = (Convert.ToInt16(sHRef[0]) - Convert.ToInt16(sHSal[0])) * 60;
                int aux2 = (Convert.ToInt16(sHRef[1]) - Convert.ToInt16(sHSal[1]));
                bit.TiempoEnRuta = aux1 + aux2 + "";
                int kmi = Convert.ToInt32(red["kmInic"].ToString());
                int kmf = Convert.ToInt32(red["kmFin"].ToString());
                bit.KmRecorridos = kmf - kmi + "";
                bit.NoOrden = (red["noRuta"].ToString());

                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }




        public void cerrar()
        {
            //el metodo cierra la conexion a la base de datos
            conexion.cerrar();
        }

    }
}