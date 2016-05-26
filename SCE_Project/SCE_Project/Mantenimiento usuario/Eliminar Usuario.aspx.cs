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
        ComandoSqlMU cmu;
        protected void Page_Load(object sender, EventArgs e)
        {
            cmu = new ComandoSqlMU();
        }

        protected void btEliminar_Click(object sender, EventArgs e)
        {
            cmu.conectar();
            cmu.executeQuery("DELETE FROM usuario WHERE IDUsuario=" + txIdUsu.Text + "");
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            try {
                cmu.conectar();
                Usuario us = cmu.ConsultaUsuario(txIdUsu.Text);
                txNom.Text = us.nombre;
                txTipoUsu.Text = us.tipo;
                txContra.Text = us.pass;
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
    }
}