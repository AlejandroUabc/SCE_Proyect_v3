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
        ComandoSqlMU cmu;
        protected void Page_Load(object sender, EventArgs e)
        {
            gdv1.Visible = false;
            cmu = new ComandoSqlMU();
        }

        private List<Usuario> llenarDatos()
        {
            List<Usuario> lista = new List<Usuario>();
            cmu.conectar();
            lista = cmu.ConsultaGeneral();           
            return lista;
        }
        private List<Usuario> llenarDatosE()
        {
            List<Usuario> lista = new List<Usuario>();
            cmu.conectar();
            lista = cmu.ConsultaEspecifica(txIdUsu.Text);
            return lista;
        }

        protected void btBuscarId_Click(object sender, EventArgs e)
        {
            try {
                this.gdv1.DataSource = llenarDatosE();
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

        protected void btConsultaGeneral_Click(object sender, EventArgs e)
        {
            try {
                this.gdv1.DataSource = llenarDatos();
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