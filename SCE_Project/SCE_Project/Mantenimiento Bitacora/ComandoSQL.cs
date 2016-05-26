using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace SCE_Project.Mantenimienro_Bitacora
{
    public class ComandoSQL
    {
        conexion con;
        public void Conectar()
        {
            con = new conexion();
        }
        public void queryExecute(string query,encabezadoBit bit)
        {
            //conexion.abrir() abre la conexion a la base de datos
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@cNom", bit.nomUsu);
            comando.Parameters.AddWithValue("@cHS", bit.hs);
            comando.Parameters.AddWithValue("@cHR", bit.hr);
            comando.Parameters.AddWithValue("@cKmInic", bit.kmInic);
            comando.Parameters.AddWithValue("@cKmFin", bit.kmFin);
            comando.Parameters.AddWithValue("@cComRuta", bit.comRuta);
            comando.Parameters.AddWithValue("@cNumCam", bit.noCam);
            comando.Parameters.AddWithValue("@cNumCaja", bit.noCaja);
            comando.Parameters.AddWithValue("@cFecha", bit.fecha);
            comando.Parameters.AddWithValue("@cNumRuta", bit.noRuta);
            comando.Parameters.AddWithValue("@cRev", bit.revPap);
            comando.Parameters.AddWithValue("@cCap", bit.capCam);
            comando.Parameters.AddWithValue("@cNumRem", bit.noRem);
            comando.Parameters.AddWithValue("@cNomCli", bit.nomCliente);
            comando.Parameters.AddWithValue("@cHoraLlegada", bit.hLlegadaCli);
            comando.Parameters.AddWithValue("@cHoraSal", bit.hSalCli);
            comando.Parameters.AddWithValue("@cTD", bit.tiempoDesc);
            comando.Parameters.AddWithValue("@cComCli", bit.comClie);
            //ejecuta el poceso almacenado
            comando.ExecuteNonQuery();
            //cierra la conexion a la base de datos.
            con.cerrar();

        }

        public void queryExecuteMod(string query, encabezadoBit bit)
        {
            //conexion.abrir() abre la conexion a la base de datos
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@id", bit.idBitacoraid);
            comando.Parameters.AddWithValue("@cNom", bit.nomUsu);
            comando.Parameters.AddWithValue("@cHS", bit.hs);
            comando.Parameters.AddWithValue("@cHR", bit.hr);
            comando.Parameters.AddWithValue("@cKmInic", bit.kmInic);
            comando.Parameters.AddWithValue("@cKmFin", bit.kmFin);
            comando.Parameters.AddWithValue("@cComRuta", bit.comRuta);
            comando.Parameters.AddWithValue("@cNumCam", bit.noCam);
            comando.Parameters.AddWithValue("@cNumCaja", bit.noCaja);
            comando.Parameters.AddWithValue("@cNumRuta", bit.noRuta);
            comando.Parameters.AddWithValue("@cRev", bit.revPap);
            comando.Parameters.AddWithValue("@cCap", bit.capCam);
            comando.Parameters.AddWithValue("@cNumRem", bit.noRem);
            comando.Parameters.AddWithValue("@cNomCli", bit.nomCliente);
            comando.Parameters.AddWithValue("@cHoraLlegada", bit.hLlegadaCli);
            comando.Parameters.AddWithValue("@cHoraSal", bit.hSalCli);
            comando.Parameters.AddWithValue("@cTD", bit.tiempoDesc);
            comando.Parameters.AddWithValue("@cComCli", bit.comClie);
            //ejecuta el poceso almacenado
            comando.ExecuteNonQuery();
            //cierra la conexion a la base de datos.
            con.cerrar();

        }

        public void queryExecuteEliminar(string query,string id)
        {
            //conexion.abrir() abre la conexion a la base de datos
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@id",id);
            //ejecuta el poceso almacenado
            comando.ExecuteNonQuery();
            //cierra la conexion a la base de datos.
            con.cerrar();

        }
        public List<string> CargarNombre(string query)
        {
            List<string> lista = new List<string>();
            //conexion.abrir() abre la conexion a la base de datos
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            MySqlDataReader red = comando.ExecuteReader();
            while (red.Read())
            {
                lista.Add(red["Nombre"].ToString());
            }
            con.cerrar();
            return lista;
        }
        public List<mostrarBit3> CargarConsulta(string query,string fechaInic, string fechaFin)
        {
            //conexion.abrir() abre la conexion a la base de datos
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cfechaInic", fechaInic);
            comando.Parameters.AddWithValue("@cfechaFin", fechaFin);
            MySqlDataReader red = comando.ExecuteReader();
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
        public List<mostrarBit3> CargarConsultaEspecifica(string query,string fechaInic, string fechaFin, string nombre)
        {
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cfechaInic", fechaInic);
            comando.Parameters.AddWithValue("@cfechaFin", fechaFin);
            comando.Parameters.AddWithValue("@nombre", nombre);
            MySqlDataReader red = comando.ExecuteReader();
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
        public encabezadoBit obtenerBitacora(string query,string id)
        {
            con.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection conn = con.getConexion();
            MySqlCommand comando = new MySqlCommand(query, conn);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            MySqlDataReader red = comando.ExecuteReader();
            encabezadoBit bit = bit = new encabezadoBit();
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