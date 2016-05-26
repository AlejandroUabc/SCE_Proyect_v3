using SCE_Project.Mantenimienro_Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

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
            conexion = new Conexion();
        }
        public void queryExecute(string query)
        {
            conexion.abrir();
            MySqlConnection connection = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, connection);
            comando.ExecuteNonQuery();
            conexion.cerrar();
        }

        public string consulta()
        {



            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT * FROM bitacoraencabezado";
            re = query.ExecuteReader();
            //string fecha;
            while (re.Read())
            {
                fecha = re["fecha"].ToString();
            }
            return fecha;
        }
        public List<TiempoRuta> consultaTiempoenRuta(string fechaInic, string fechaFin)
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT idBitacoraid,nomUsu,fecha,noRuta,noCam,hs,hr FROM bitacoraencabezado WHERE fecha BETWEEN '" + fechaInic + "' and '" + fechaFin + "'";
            MySqlDataReader red = query.ExecuteReader();
            TiempoRuta bit;
            List<TiempoRuta> lista1 = new List<TiempoRuta>();
            while (red.Read())
            {
                bit = new TiempoRuta();
                bit.idruta = (red["idBitacoraid"].ToString());
                bit.nombreUsuarios = (red["nomUsu"].ToString());
                bit.fecha = (red["fecha"].ToString());
                bit.noRuta = (red["noRuta"].ToString());
                bit.numCam = (red["noCam"].ToString());
                string hSal = (red["hs"].ToString());
                string hRef = (red["hr"].ToString());
                String[] sHSal = hSal.Split(':');
                String[] sHRef = hRef.Split(':');
                int aux1 = (Convert.ToInt16(sHRef[0]) - Convert.ToInt16(sHSal[0])) * 60;
                int aux2 = (Convert.ToInt16(sHRef[1]) - Convert.ToInt16(sHSal[1]));
                bit.tiemRuta = aux1 + aux2 + "";
                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }

        public List<KilometrosRecorridos> consultaKmRecorrido(string fechaInic, string fechaFin)
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT kmInic,kmFin,idBitacoraid,noRuta  FROM bitacoraencabezado WHERE fecha BETWEEN '" + fechaInic + "' and '" + fechaFin + "'";
            MySqlDataReader red = query.ExecuteReader();
            KilometrosRecorridos bit;
            List<KilometrosRecorridos> lista1 = new List<KilometrosRecorridos>();
            while (red.Read())
            {
                bit = new KilometrosRecorridos();
                int kmi = Convert.ToInt32(red["kmInic"].ToString());
                int kmf = Convert.ToInt32(red["kmFin"].ToString());
                bit.kmRecorridos = kmf - kmi + "";
                bit.idBitacora = red["idBitacoraid"].ToString();
                bit.noRuta = red["noRuta"].ToString();
                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }

        public List<NumeroRutas> consultaNumOrdenes(string fechaInic, string fechaFin)
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT COUNT(DISTINCT noRuta) FROM bitacoraencabezado WHERE fecha BETWEEN '" + fechaInic + "' and '" + fechaFin + "'";

            NumeroRutas bit;
            List<NumeroRutas> lista1 = new List<NumeroRutas>();

            bit = new NumeroRutas();
            bit.noRuta = query.ExecuteScalar().ToString();
            lista1.Add(bit);
            conexion.cerrar();
            return lista1;
        }

        public List<mostrarBit3> consultaEstGen(string fechaInic, string fechaFin)
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT idBitacoraid,nomUsu,fecha,noRuta,noCam FROM bitacoraencabezado WHERE fecha BETWEEN '" + fechaInic + "' and '" + fechaFin + "'";
            MySqlDataReader red = query.ExecuteReader();
            mostrarBit3 bit;
            List<mostrarBit3> lista1 = new List<mostrarBit3>();
            while (red.Read())
            {
                bit = new mostrarBit3();
                bit.idBitacoraid = (red["idBitacoraid"].ToString());
                bit.nomUsu = (red["nomUsu"].ToString());
                bit.fecha = (red["fecha"].ToString());
                bit.noRuta = (red["noRuta"].ToString());
                bit.noCam = (red["noCam"].ToString());
                lista1.Add(bit);
            }
            conexion.cerrar();
            return lista1;
        }


        public void cerrar()
        {
            conexion.cerrar();
        }

    }
}