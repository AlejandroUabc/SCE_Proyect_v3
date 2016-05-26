using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace SCE_Project.Mantenimiento_usuario
{
    public class ComandoSqlMU
    {
        //clase que contienelos datos para la conexion asi como los metodos para 
        //abrir y cerrar la coneccion a la base de datos
        Conexion conexion;
        
        //esta clase intacia a la clase Conexion
        public void conectar()
        {
            conexion = new Conexion();
        }

        //metodo usado para ejecutar los procesos almacenados que no regresan una tabla usado en las clases
        // de Registrar Usuaro.aspx.cs y Modificar Usuarios.aspx.cs.
        public void executeQuery(string query, Usuario us)
        {
        
            //conexion.abrir() abre la conexion a la base de datos
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, con);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@id", us.id);
            comando.Parameters.AddWithValue("@nombreUsuario", us.nombre);
            comando.Parameters.AddWithValue("@tipoUsuario", us.tipo);
            comando.Parameters.AddWithValue("@contraseña", us.pass);

            //ejecuta el poceso almacenado
            comando.ExecuteNonQuery();
            //cierra la conexion a la base de datos.
            conexion.cerrar();
        
    }
        //metodo usado para eliinar usuarios
        public void executeQueryEli(string query, Usuario us)
        {

            //conexion.abrir() abre la conexion a la base de datos
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, con);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;

            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@id", us.id);

            //ejecuta el poceso almacenado
            comando.ExecuteNonQuery();
            //cierra la conexion a la base de datos.
            conexion.cerrar();

        }

        //Regresa una lista con todos los usarios  registrados
        public List<Usuario> ConsultaGeneral(string query)
        {
            //conexion.abrir() abre la conexion a la base de datos
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, con);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            //obtiene la tabla resultante de la consulta
            MySqlDataReader red = comando.ExecuteReader();
            Usuario us;
            //verifica que la tabla no este bacia
            if (red.HasRows)
            {
                List<Usuario> lista = new List<Usuario>();
                //lee los datos almacenados en la tabla tupla por tupla.
                while (red.Read())
                {
                    us = new Usuario();
                    us.id = (red["IDUsuario"].ToString());
                    us.nombre = (red["Nombre"].ToString());
                    us.pass = (red["pass"].ToString());
                    us.tipo = (red["Tipo"].ToString());
                    lista.Add(us);
                }

                //cierra la conexion a la base de datos.
                conexion.cerrar();
                return lista;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //regresa la informacion de un udario especifico
        public List<Usuario> ConsultaEspecifica(string query,string id)
        {
            // conexion.abrir() abre la conexion a la base de datos
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, con);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@id", id);
            MySqlDataReader red = comando.ExecuteReader();
            Usuario us;
            //verifica que la tabla no este bacia
            if (red.HasRows)
            {
                List<Usuario> lista = new List<Usuario>();
                //lee los datos almacenados en la tabla tupla por tupla.
                while (red.Read())
                {
                    us = new Usuario();
                    us.id = (red["IDUsuario"].ToString());
                    us.nombre = (red["Nombre"].ToString());
                    us.pass = (red["pass"].ToString());
                    us.tipo = (red["Tipo"].ToString());
                    lista.Add(us);
                }
                //cierra la conexion a la base de datos.
                conexion.cerrar();
                return lista;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public Usuario ConsultaUsuario(string query,string id)
        {
            // conexion.abrir() abre la conexion a la base de datos
            conexion.abrir();
            //getConexion regresa una variable de Tipo MySqlConnection
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, con);
            //establece que el comando ejecutara un proceso almacenado
            comando.CommandType = CommandType.StoredProcedure;
            //establece los parametro que se enviaran al proceso almacenado
            comando.Parameters.AddWithValue("@id", id);
            MySqlDataReader red = comando.ExecuteReader();
            Usuario us = null;
            //verifica que la tabla no este bacia
            if (red.HasRows)
            {
                //lee los datos almacenados en la tabla tupla por tupla.
                while (red.Read())
                {
                    us = new Usuario();
                    us.id = (red["IDUsuario"].ToString());
                    us.nombre = (red["Nombre"].ToString());
                    us.pass = (red["pass"].ToString());
                    us.tipo = (red["Tipo"].ToString());
                }
                //cierra la conexion a la base de datos.
                conexion.cerrar();
                return us;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}