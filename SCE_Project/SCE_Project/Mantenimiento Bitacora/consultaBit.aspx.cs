using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SCE_Project.Mantenimienro_Bitacora
{
    public partial class consultaBit : System.Web.UI.Page
    {
        ComandoSQL comm;

        //método Page_Load carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se intancia la clase ComandoSQL que contiene el manejo de
            //la base de datos para hacer un uso mas practico de la conexión
            comm = new ComandoSQL();

            //Se hace uso del método Cargar() creado con anterioridad, para que cargue 
            //los choferes que estén registrados.
            cargar();
            txFechaCon.Visible = false;
            ddlCapCon.Visible = false;
            ddlRevPapCon.Enabled = false;
            txNumRuta.Visible = false;
            txNumCam.Visible = false;
            txHS.Visible = false;
            txNumCaja.Visible = false;
            txHR.Visible = false;
            txKmInic.Visible = false;
            txKmFin.Visible = false;
            txComRuta.Visible = false;
            txNumRem.Visible = false;
            txNomCli.Visible = false;
            txHoraLlegada.Visible = false;
            txHoraSal.Visible = false;
            txTD.Visible = false;
            txComCli.Visible = false;
            etNom2.Visible = false;

            etFechaCon.Visible = false;
            etCapCon.Visible = false;
            etRevPapCon.Visible = false;
            etNumRuta.Visible = false;
            etNumCam.Visible = false;
            etHS.Visible = false;
            etNumCaja.Visible = false;
            etHR.Visible = false;
            etKmInic.Visible = false;
            etKmFin.Visible = false;
            etComRuta.Visible = false;
            etNumRem.Visible = false;
            etNomCli.Visible = false;
            etHoraLlegada.Visible = false;
            etHoraSal.Visible = false;
            etTD.Visible = false;
            etComCli.Visible = false;
            camion.Visible = false;
            camion2.Visible = false;
            camion3.Visible = false;
            etMin.Visible = false;

        }

        //método que carga los nombres de los choferes en una lista
        private void cargar()
        {
            
            comm.Conectar();
            
            List<string> clist = comm.CargarNombre("CargarUsuarios");
            foreach (string li in clist)
            {
                ddlNom.Items.Add(li);
            }
        }

        private List<mostrarBit3> cargarBit()
        {
            //Se establece la conexión con la base de datos
            comm.Conectar();

            //Recibe una lista con todas las bitácoras registradas en el rango de fechas del método CargarConsulta 
            List<mostrarBit3> lista = comm.CargarConsulta("CargarConsulta", txFechaInic.Text, txFechaFin.Text);

            return lista;
        }
        private List<mostrarBit3> cargarBitEsp()
        {
            //Se establece la conexión con la base de datos
            comm.Conectar();

            //Recibe una lista con todas las bitácoras registradas en el rango de fechas y el nombre especificado del método CargarConsultaEspecifica 
            List<mostrarBit3> lista = comm.CargarConsultaEspecifica("CargarConsultaEspecifica", txFechaInic.Text, txFechaFin.Text, ddlNom.Text);
            return lista;
        }


        //Busca las bitácoras en los rangos especificados y despliega una tabla con los datos
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            //Se hace una conversión donde convierte una cadena a tipo hora
            DateTime fechaFin = Convert.ToDateTime(txFechaInic.Text);
            DateTime fechaInic = Convert.ToDateTime(txFechaFin.Text);

            //Se compara que fechaInic no sea mayor que fechaFin para tener un mejor resultado sobre la búsqueda
            if (fechaFin > fechaInic)
            {
                Response.Write("<script language=javascript>alert('La fecha inicial no puede ser mayor que la fecha final!')</script>");

            }
            //Se hace una comparación donde si ddlNom está en el value=0 cargara todas las bitácoras
            //dónde esten todos los choferes relacionados con la fecha buscada estipulado en el método CargarBit()
            else {
                if (ddlNom.SelectedIndex==0)
                {
                    this.gdvBit.DataSource = cargarBit();
                    gdvBit.DataBind();
                    gdvBit.Visible = true;
                }
                //si selecciona un nombre sólo las bitácoras buscadas con el nombre específico apareceran
                else
                {
                    this.gdvBit.DataSource = cargarBitEsp();
                    gdvBit.DataBind();
                    gdvBit.Visible = true;
                    // Lista.Items.Clear();
                    // cargar();
                }
            }
        }


        //al seleccionar una bitácora este mostrará los datos completos de la bitácora
        GridViewRow row;
        protected void gdv1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            row = gdvBit.SelectedRow;
            etNom2.Text = row.Cells[0].Text;


            txFechaCon.Enabled = false;
            ddlCapCon.Enabled = false;
            txNumRuta.Enabled = false;
            txNumCam.Enabled = false;
            txHS.Enabled = false;
            txNumCaja.Enabled = false;
            txHR.Enabled = false;
            txKmInic.Enabled = false;
            txKmFin.Enabled = false;
            txComRuta.Enabled = false;
            txNumRem.Enabled = false;
            txNomCli.Enabled = false;
            txHoraLlegada.Enabled = false;
            txHoraSal.Enabled = false;
            txTD.Enabled = false;
            txComCli.Enabled = false;
            txNumRem.Enabled = false;
            ddlRevPapCon.Enabled = false;

            txFechaCon.Visible = true;
            ddlCapCon.Visible = true;
            ddlRevPapCon.Visible = true;
            txNumRuta.Visible = true;
            txNumCam.Visible = true;
            txHS.Visible = true;
            txNumCaja.Visible = true;
            txHR.Visible = true;
            txKmInic.Visible = true;
            txKmFin.Visible = true;
            txComRuta.Visible = true;
            txNumRem.Visible = true;
            txNomCli.Visible = true;
            txHoraLlegada.Visible = true;
            txHoraSal.Visible = true;
            txTD.Visible = true;
            txComCli.Visible = true;


            etFechaCon.Visible = true;
            etCapCon.Visible = true;
            etRevPapCon.Visible = true;
            etNumRuta.Visible = true;
            etNumCam.Visible = true;
            etHS.Visible = true;
            etNumCaja.Visible = false;
            etHR.Visible = true;
            etKmInic.Visible = true;
            etKmFin.Visible = true;
            etComRuta.Visible = true;
            etNumRem.Visible = true;
            etNumCaja.Visible = true;
            etNomCli.Visible = true;
            etHoraLlegada.Visible = true;
            etHoraSal.Visible = true;
            etTD.Visible = true;
            etComCli.Visible = true;
            camion.Visible = true;
            camion2.Visible = true;
            camion3.Visible = true;
            etMin.Visible = true;

            //Abre la conexión a la base de datos
            comm.Conectar();
            encabezadoBit bit = comm.obtenerBitacora("ObtenerBitacora", etNom2.Text);

            //LLena los datos en los campos especificados tomados de la base de datos mediante la
            //instancia de la clase EncabezadoBit
            ddlRevPapCon.Text = bit.revPap;
            txFechaCon.Text = bit.fecha;
            ddlCapCon.Text = bit.capCam;
            txKmInic.Text = bit.kmInic;
            txKmFin.Text = bit.kmFin;
            txNumCaja.Text = bit.noCaja;
            txHR.Text = bit.hr;
            txHS.Text = bit.hs;
            txComRuta.Text = bit.comRuta;
            txNumRem.Text = bit.noRem;
            txNomCli.Text = bit.nomCliente;
            txHoraLlegada.Text = bit.hLlegadaCli;
            txHoraSal.Text = bit.hSalCli;
            txComCli.Text = bit.comClie;
            txTD.Text = bit.tiempoDesc;
            txNumRuta.Text = bit.noRuta;
            txNumCam.Text = bit.noCam;
        }
    }
    
}