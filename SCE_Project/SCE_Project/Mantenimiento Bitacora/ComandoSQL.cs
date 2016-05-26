using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace SCE_Project.Mantenimienro_Bitacora
{
    public class ComandoSQL
    {
        conexion con;
        public void Conectar()
        {
            con = new conexion();
        }
        public void queryExecute(string query)
        {
            con.abrir();
            MySqlConnection connection = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, connection);
            comando.ExecuteNonQuery();
            con.cerrar();

        }
        public List<string> CargarNombre()
        {
            con.abrir();
            List<string> lista = new List<string>();
            MySqlCommand query = con.getConexion().CreateCommand();
            query.CommandText = "SELECT Nombre FROM usuario WHERE Tipo='chofer'";
            MySqlDataReader red = query.ExecuteReader();
            while (red.Read())
            {
                lista.Add(red["Nombre"].ToString());
            }
            con.cerrar();
            return lista;
        }
        public List<mostrarBit3> CargarConsulta(string fechaInic,string fechaFin)
        {
            con.abrir();
            MySqlCommand query = con.getConexion().CreateCommand();
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
            con.cerrar();
            return lista1;
        }
        public List<mostrarBit3> CargarConsultaEspecifica(string fechaInic, string fechaFin,string nombre)
        {
            con.abrir();
            MySqlCommand query = con.getConexion().CreateCommand();
            query.CommandText = "SELECT idBitacoraid,nomUsu,fecha,noRuta,noCam FROM bitacoraencabezado WHERE nomUsu='" + nombre + "' and fecha BETWEEN '" + fechaInic + "' and '" + fechaFin + "'";
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
            con.cerrar();
            return lista1;
        }
        public encabezadoBit obtenerBitacora(string id)
        {
            con.abrir();
            MySqlCommand query = con.getConexion().CreateCommand();
            query.CommandText = "SELECT * FROM bitacoraencabezado where idBitacoraid='" + id + "'";
            MySqlDataReader red = query.ExecuteReader();
            encabezadoBit bit= bit = new encabezadoBit();
            while (red.Read())
            {   
              
                bit.fecha = (red["fecha"].ToString());
                bit.capCam = (red["capCam"].ToString());
                bit.revPap = (red["revPap"].ToString());
                bit.kmInic = (red["kmInic"].ToString());
                bit.kmFin = (red["kmFin"].ToString());
                bit.noCaja = (red["noCaja"].ToString());
                bit.hr = (red["hr"].ToString());
                bit.hs = (red["hs"].ToString());
                bit.comRuta = (red["comRuta"].ToString());
                bit.noRem = (red["noRem"].ToString());
                bit.nomCliente = (red["nomCliente"].ToString());
                bit.hLlegadaCli = (red["hLlegadaCli"].ToString());
                bit.hSalCli = (red["hSalCli"].ToString());
                bit.comClie = (red["comCli"].ToString());
                bit.tiempoDesc = (red["tiempoDesc"].ToString());
                bit.noRuta = (red["noRuta"].ToString());
                bit.noCam = (red["noCam"].ToString());


            }
            con.cerrar();
            return bit;

        }

    }
}