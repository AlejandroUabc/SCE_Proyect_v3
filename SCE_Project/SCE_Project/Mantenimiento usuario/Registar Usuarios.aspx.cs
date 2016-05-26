using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SCE_Project.Mantenimiento_usuario
{
    public partial class Registar_Usuarios : System.Web.UI.Page
    {
        ComandoSqlMU cmu;
        protected void Page_Load(object sender, EventArgs e)
        {
            cmu = new ComandoSqlMU();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "carga", "cargar()", true);
        }

        protected void btRegistrarS_Click(object sender, EventArgs e)
        {
            
            try
            {
                cmu.conectar();
                cmu.executeQuery("INSERT INTO usuario(IDUsuario, Nombre, pass, Tipo) VALUES(" + txIdUsuRegistrar.Text + ",'" + txNomUsu.Text + "','NA'," + ddlTipoUsu.SelectedIndex + ")");
                Response.Write("<script language=javascript>alert('Registro Exitoso')</script>");
                txIdUsuRegistrar.Text = "";
                txNomUsu.Text = "";
                txContra.Text = "";
                ddlTipoUsu.SelectedIndex = 0;
                ddlTipoUsu.Text = "tipo de usuario";
            }
            catch (MySqlException)
            {
                Response.Write("<script language=javascript>alert('Su registro NO pudo ser realizado, Error en la conexión')</script>");
                txIdUsuRegistrar.Text = "";
                txNomUsu.Text = "";
                txContra.Text = "";
                ddlTipoUsu.SelectedIndex = 0;
                ddlTipoUsu.Text = "tipo de usuario";
            }
        }

        protected void btRegistrarC_Click(object sender, EventArgs e)
        {
            try
            {
                cmu.conectar();
                cmu.executeQuery("INSERT INTO usuario(IDUsuario, Nombre, pass, Tipo) VALUES(" + txIdUsuRegistrar.Text + ",'" + txNomUsu.Text + "','"+txContra.Text+"'," + ddlTipoUsu.SelectedIndex + ")");
                Response.Write("<script language=javascript>alert('Registro Exitoso')</script>");
                txIdUsuRegistrar.Text = "";
                txNomUsu.Text = "";
                txContra.Text = "";
                ddlTipoUsu.SelectedIndex = 0;
                ddlTipoUsu.Text = "tipo de usuario";

            }
            catch (MySqlException)
            {
                //Label5.Text = "error";
                Response.Write("<script language=javascript>alert('Su registro NO pudo ser realizado, Error en la conexión')</script>");
                txIdUsuRegistrar.Text = "";
                txNomUsu.Text = "";
                txContra.Text = "";
                ddlTipoUsu.SelectedIndex = 0;
                ddlTipoUsu.Text = "tipo de usuario";
            }
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            txIdUsuRegistrar.Text = "";
            txNomUsu.Text = "";
            txContra.Text = "";
            ddlTipoUsu.SelectedIndex = 0;
            ddlTipoUsu.Text = "tipo de usuario";
        }
    }
}