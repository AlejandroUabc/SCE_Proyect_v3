using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SCE_Project.Mantenimiento_usuario
{
    public partial class Consultar_Usuarios : System.Web.UI.Page
    {
        //clase que contiane el manejo de la base de datos.
        ComandoSqlMU cmu;
        protected void Page_Load(object sender, EventArgs e)
        {
            //gdv es una abreviatura GridView
            gdv1.Visible = false;
            cmu = new ComandoSqlMU();
        }
        // recive una listas(vector) que contine objetos con los datos de todos los usuarios
        private List<Usuario> llenarDatos()
        {
            List<Usuario> lista = new List<Usuario>();
            //abre la conecion a la base de datos
            cmu.conectar();
            //ConsultaGeneral() obtien los datos de todos los usuarios
            lista = cmu.ConsultaGeneral("Busquedageneral");           
            return lista;
        }
        // recive una listas(vector) que contine un objeto con los datos de un usuarios especifico
        private List<Usuario> llenarDatosE()
        {
            List<Usuario> lista = new List<Usuario>();
            //abre la conecion a la base de datos
            cmu.conectar();
            // obtiene los datos de un usuario especifico
            lista = cmu.ConsultaEspecifica("ConsultaEspecifica",txIdUsu.Text);
            return lista;
        }

        //obtiene el usuario el cual se ingreso y despliega los datos en caso de encontrarlos
        protected void btBuscarId_Click(object sender, EventArgs e)
        {
            try {
                //gdv1.DataSource obtiene los datos de la lista y enalaz con los datos de control.
                this.gdv1.DataSource = llenarDatosE();
                //enlasa los datos externos con los datos de control
                gdv1.DataBind();
                gdv1.Visible = true;
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

        //despliega todos los datos de usuarios de l base de datos
        protected void btConsultaGeneral_Click(object sender, EventArgs e)
        {
            try {
                //gdv1.DataSource obtiene los datos de la lista y enalaz con los datos de control.
                this.gdv1.DataSource = llenarDatos();
                //enlasa los datos externos con los datos de control
                gdv1.DataBind();
                gdv1.Visible = true;
            }
            catch (MySqlException)
            {
                Response.Write("<script language=javascript>alert('Error en la conexcion con la base de datos')</script>");
            }
            catch (IndexOutOfRangeException)
            {
                Response.Write("<script language=javascript>alert('No se encontraron usuarios')</script>");
            }
        }

        
    }
}