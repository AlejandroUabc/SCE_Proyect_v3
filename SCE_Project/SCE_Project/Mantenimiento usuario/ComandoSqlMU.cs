using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

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

        //metodo usado para ejecutar los query que no regresan una tabla usado en las clases
        // de Registrar Usuaro.aspx.cs, Eliminar Usuario.aspx.cs y Modificar Usuarios.aspx.cs.
        public void executeQuery(string query)
        {
            //conexion.abrir() abre la conexion a la base de datos
            conexion.abrir();
            //getConexion regresa una variable de yipo MySqlConnection
            MySqlConnection con = conexion.getConexion();
            MySqlCommand comando = new MySqlCommand(query, con);
            comando.ExecuteNonQuery();
            //cierra la conexion a la base de datos.
            conexion.cerrar();
        }


        public List<Usuario> ConsultaGeneral()
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT * FROM usuario";
            MySqlDataReader red = query.ExecuteReader();
            Usuario us;
            if (red.HasRows)
            {
                List<Usuario> lista = new List<Usuario>();
                while (red.Read())
                {
                    us = new Usuario();
                    us.id = (red["IDUsuario"].ToString());
                    us.nombre = (red["Nombre"].ToString());
                    us.pass = (red["pass"].ToString());
                    us.tipo = (red["Tipo"].ToString());
                    lista.Add(us);
                }
                conexion.cerrar();
                return lista;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public List<Usuario> ConsultaEspecifica(string id)
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT * FROM usuario where IDUsuario=" + id + "";
            MySqlDataReader red = query.ExecuteReader();
            Usuario us;
            if (red.HasRows)
            {
                List<Usuario> lista = new List<Usuario>();
                while (red.Read())
                {
                    us = new Usuario();
                    us.id = (red["IDUsuario"].ToString());
                    us.nombre = (red["Nombre"].ToString());
                    us.pass = (red["pass"].ToString());
                    us.tipo = (red["Tipo"].ToString());
                    lista.Add(us);
                }
                conexion.cerrar();
                return lista;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public Usuario ConsultaUsuario(string id)
        {
            conexion.abrir();
            MySqlCommand query = conexion.getConexion().CreateCommand();
            query.CommandText = "SELECT * FROM usuario where IDUsuario=" + id + "";
            MySqlDataReader red = query.ExecuteReader();
            Usuario us = null;
            if (red.HasRows)
            {
                while (red.Read())
                {
                    us = new Usuario();
                    us.id = (red["IDUsuario"].ToString());
                    us.nombre = (red["Nombre"].ToString());
                    us.pass = (red["pass"].ToString());
                    us.tipo = (red["Tipo"].ToString());
                }
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