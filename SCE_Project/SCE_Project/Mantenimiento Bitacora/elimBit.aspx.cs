using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using SCE_Project.Mantenimienro_Bitacora;


namespace SCE_Project.Mantenimiento_Bitacora
{
    public partial class elimBit : System.Web.UI.Page
    {
        ComandoSQL comm;

        //Método para cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se intancia la clase ComandoSQL que contiene el manejo de
            //la base de datos para hacer un uso mas practico de la conexión
            comm = new ComandoSQL();
            cargar();
            btEliminar.Visible = false;
            etNom2.Visible = false;
        }

        //Se hace uso del método Cargar() creado con anterioridad, para que cargue 
        //los choferes que estén registrados.
        private void cargar()
        {
            
            comm.Conectar();
            List<string> clist = comm.CargarNombre("CargarUsuarios");
            foreach (string li in clist)
            {
                ddlLista.Items.Add(li);
            }
          
        }

        private List<mostrarBit3> cargarBit()
        {
            comm.Conectar();
            List<mostrarBit3> list = comm.CargarConsulta("CargarConsulta", txFechaInic.Text, txFechaFin.Text);
            return list;
        }
        private List<mostrarBit3> cargarBitEsp()
        {
            comm.Conectar();
            List<mostrarBit3> lista = comm.CargarConsultaEspecifica("CargarConsultaEspecifica", txFechaInic.Text, txFechaFin.Text, ddlLista.Text);
            return lista;
        }

        //El metodo btBuscar_Click se activa al dar click al botón "Búscar bitácora"
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            //Se hizo una conversión a tipo "DateTime" para hacer la validación siguiente.
            DateTime fechaFin = Convert.ToDateTime(txFechaInic.Text);
            DateTime fechaInic = Convert.ToDateTime(txFechaFin.Text);

            if (fechaFin > fechaInic)
            {
                Response.Write("<script language=javascript>alert('La fecha inicial no puede ser mayor que la fecha final!')</script>");

            }
            else
                //ddlLista es un dropdownlist el cuál despliega una lista con los nombres de los choferes 
                // y aquí la lista en el value = 0 tiene la opcion de buscar todas las bitácoras con todos los nombres de choferes
                // y muestra la bitácora en el gridView con los campos especificados.
                if (ddlLista.SelectedIndex == 0)
            {
                this.gdvBit.DataSource = cargarBit();
                gdvBit.DataBind();
                gdvBit.Visible = true;
                cargar();
                //Lista.Items.Clear();
                //cargar();
            }
            else
                //si seleccionó algun nombre específico solo muestra las bitácoras con esos nombres.
                this.gdvBit.DataSource = cargarBitEsp();
            gdvBit.DataBind();
            gdvBit.Visible = true;
            cargar();
        }

        GridViewRow row;
        //Muestra la tabla con los datos de la bitácora encontrada
        protected void gdv1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            row = gdvBit.SelectedRow;
            //Toma los datos de la bitácora del renglon seleccionado y los iguala a un label para despúes ser utilizado
            etNom2.Text = row.Cells[0].Text;
            btEliminar.Visible = true;


        }

        //El metodo btEliminar_Click se activa al dar click al botón "eliminar bitácora" 
        protected void btEliminar_Click(object sender, EventArgs e)
        {
            // se hace la conexión 
            //se ejecuta la acción para eliminar la bitácora seleccionada con el queryExecute
            comm.Conectar();
            comm.queryExecuteEliminar("EliminatBitacora", etNom2.Text );
            Response.Write("<script language=javascript>alert('La bitácora ha sido eliminada correctamente!')</script>");
        }

    }
}