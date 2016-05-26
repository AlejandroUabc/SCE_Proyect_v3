using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace SCE_Project.Mantenimiento_usuario
{
    public partial class Modificar_Usuario : System.Web.UI.Page
    {
        //clase que contiane el manejo de la base de datos.
        ComandoSqlMU cmu;

        //carga el los elementos de inicio de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            
            cmu = new ComandoSqlMU();
            //carga un script en la pagina  la pagina que muestra o oculata los campo de contraseña y su etiqueta dependiendo 
            //del index donde se encuantre el DropDownList ddlTipoUsu.
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarPass", "ocultarPass()", true);
            //inavilita los campos inecesarios al incio de la ejecucion.
            btModificarC.Enabled = false;
            btModificarS.Enabled = false;
            ddlTipoUsu.Enabled = false;
            txContra.Enabled = false;
            txNom.Enabled = false;

        }

        //busca al usuario y los despliega su informacion en caso de encontrarlo.
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            try {
                //abre la conecion a la base de datos
                cmu.conectar();
                //ConsultaUsuario recive la id del usuario  y regresa un objeto Usuario si es
                //encontrado  regresa un objeto tipo usuario
                Usuario us = cmu.ConsultaUsuario("ConsultaEspecifica", txIdUsu.Text);
                txNom.Text = us.nombre;
                txContra.Text = us.pass;
                //coloca el DropDowList en la pocicion don concuerde lo obtenido en la busqueda con los elementos del DropDownList.
                if (string.Compare(us.tipo, "supervisor") == 0)
                {
                    ddlTipoUsu.SelectedIndex = 1;
                }
                else
                {
                    ddlTipoUsu.SelectedIndex = 2;
                }
                //desabilita el boton buscar y el campo de la id del suario
                txIdUsu.Enabled = false;
                btBuscar.Enabled = false;
                // abilita los campos que se pueden modofocar y el boton de modificar.
                btModificarC.Enabled = true;
                btModificarS.Enabled = true;
                ddlTipoUsu.Enabled = true;
                txContra.Enabled = true;
                txNom.Enabled = true;

                //carga un script en la pagina  la pagina que muestra o oculata los campo de contraseña y su etiqueta dependiendo 
                //del index donde se encuantre el DropDownList ddlTipoUsu.
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultarPass", "ocultarPass()", true);
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

        //modifica la informacion si el tipo de usuario es supervisor 
        protected void btModificarS_Click(object sender, EventArgs e)
        {
            
            Usuario usu = new Usuario();
            usu.id = txIdUsu.Text;
            usu.nombre = txNom.Text;
            usu.pass = txContra.Text;
            usu.tipo = ddlTipoUsu.SelectedIndex.ToString();
            //abre la conecion a la base de datos
            cmu.conectar();
            // el proceso almacenado  modifica los datos donde el id usuario es se igual al que se busco
            cmu.executeQuery("ModificarUsuario", usu);
            reiniciar();

        }

        //cancela la modificacion
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            reiniciar();
           
        }

        //regresa el estado de la pagina al estado de inicio
        protected void reiniciar()
        {
            btModificarC.Enabled = false;
            btModificarS.Enabled = false;
            ddlTipoUsu.Enabled = false;
            txContra.Enabled = false;
            txNom.Enabled = false;
            btBuscar.Enabled = true;
            txIdUsu.Enabled = true;
            txIdUsu.Text = "";
            txNom.Text = "";
            txContra.Text = "";
            ddlTipoUsu.SelectedIndex = 0;
            ddlTipoUsu.Text = "Tipo de usuario";
        }

        //modifica la informacion si el tipo de usuario es chofer
        protected void btModificarC_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.id = txIdUsu.Text;
            usu.nombre = txNom.Text;
            usu.pass = "NA";
            usu.tipo = ddlTipoUsu.SelectedIndex.ToString();
            cmu.conectar();
            // el proceso almacenado  modifica los datos donde el id usuario es se igual al que se busco
            cmu.executeQuery("ModificarUsuario", usu);
            reiniciar();
        }
    }
}