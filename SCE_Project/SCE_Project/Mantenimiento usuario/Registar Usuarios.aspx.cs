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
        //clase que contiane el manejo de la base de datos.
        ComandoSqlMU cmu;

        // carga los elementos de inicio de  la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            cmu = new ComandoSqlMU();
            //carga un script en la pagina el cual inicializa el esatdo de el campo de contraseña y su etiqueta como ocultos.
            ScriptManager.RegisterStartupScript(this, typeof(Page), "carga", "cargar()", true);
        }

        //evento que registra a los usuarios tipo chofer.
        protected void btRegistrarS_Click(object sender, EventArgs e)
        {
            
            try
            {
                //se utiliza en objeto usuario para guardar la informacion para mejor manejo de los parametros
                Usuario usu = new Usuario();
                usu.id = txIdUsuRegistrar.Text;
                usu.nombre = txNomUsu.Text;
                usu.pass = "NA";
                usu.tipo = ddlTipoUsu.SelectedIndex.ToString();

                //abre la conecion a la base de datos
                cmu.conectar();
                // executeQuery es un metodo que ejecuta un proceso almacenado que no regresa informacion
                // el parametros de este metodo es un objeto tipo usuarios que indica al proceseso alamacenado  los
                // datos del usuario usado en el proceso almacenado para la incerción de los datos en la BD.
                cmu.executeQuery("RegistroChofer", usu);
                // despliega un mensague de registro exitosos
                Response.Write("<script language=javascript>alert('Registro Exitoso')</script>");
                reiniciar();
            }
            catch (MySqlException)
            {
                Response.Write("<script language=javascript>alert('Su registro NO pudo ser realizado, Error en la conexión')</script>");
                reiniciar();
            }
        }
        //metodo que registra los usuarios tipo supervisor
        protected void btRegistrarC_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = new Usuario();
                usu.id = txIdUsuRegistrar.Text;
                usu.nombre = txNomUsu.Text;
                usu.pass = txContra.Text;
                usu.tipo = ddlTipoUsu.SelectedIndex.ToString();
                // abre la conecion a la base de datos
                cmu.conectar();
                // executeQuery es un metodo que ejecuta un proceso almacenado que no regresa informacion
                // el parametros de este metodo es un objeto tipo usuarios que indica al proceseso alamacenado  los
                // datos del usuario usado en el proceso almacenado para la incerción de los datos en la BD.
                cmu.executeQuery("RegistroSupervisor", usu);
                Response.Write("<script language=javascript>alert('Registro Exitoso')</script>");
                reiniciar();

            }
            catch (MySqlException)
            {
                Response.Write("<script language=javascript>alert('Su registro NO pudo ser realizado, Error en la conexión')</script>");
                reiniciar();
            }
        }

        //cancela el registro y regresa la pagina al estado de inicial.
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            reiniciar();
        }
        // este metodo se utiliza para restaurar los campos a su estado inicial
        protected void reiniciar()
        {
            txIdUsuRegistrar.Text = "";
            txNomUsu.Text = "";
            txContra.Text = "";
            ddlTipoUsu.SelectedIndex = 0;
            ddlTipoUsu.Text = "tipo de usuario";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarPass", "ocultarPass()", true);
        }
    }
}