using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SCE_Project.Mantenimiento_usuario
{
    public partial class Eliminar_Usuario : System.Web.UI.Page
    {
        //clase manegadora de la base de datos
        ComandoSqlMU cmu;
        //inicia la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            cmu = new ComandoSqlMU();
            //desabilita el boston eliminar
            btEliminar.Enabled = false;
        }

        //elimina el usuario desplegado en la pantaña
        protected void btEliminar_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.id = txIdUsu.Text;
            usu.nombre = txNom.Text;
            usu.pass = txContra.Text;
            usu.tipo = txTipoUsu.Text;
            //crea la conexion con la base de datos
            cmu.conectar();
            // executeQuery es un comando que ejecuta un query que no regresa informacion
            // el parametros de este metodo es un string que indica el proceso alamcenado mas el Id 
            // del usuario a eliminar 
            cmu.executeQueryEli("EliminarUsuarios", usu);
            reiniciar();
        }

        //regresa la pagina al estado inicial
        private void reiniciar()
        {
            btEliminar.Enabled = false;
            btBuscar.Enabled = true;
            txIdUsu.Enabled = true;
            txNom.Text = "";
            txTipoUsu.Text = "";
            txContra.Text = "";
            txIdUsu.Text="";

        }

        //busca al usuarios que se quiere eliminar
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            try {
                
                cmu.conectar();
                 // clase usuario contie los 4 datos de la table usuario
                 //ConsultaUsuario recive el id del usuario y devuelve on objeto tipo usuari0
                 Usuario us = cmu.ConsultaUsuario("ConsultaEspecifica",txIdUsu.Text);
                txNom.Text = us.nombre;
                txTipoUsu.Text = us.tipo;
                txContra.Text = us.pass;
                btEliminar.Enabled = true;
                btBuscar.Enabled = false;
            }
            catch (MySqlException)
            {
                Response.Write("<script language=javascript>alert('Error en la conexcion con la base de datos')</script>");
            }
            catch (IndexOutOfRangeException)
            {
                Response.Write("<script language=javascript>alert('El usuario no existe')</script>");
            }
        }

        //cancela la eliminacion
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            reiniciar();
        }
    }
}