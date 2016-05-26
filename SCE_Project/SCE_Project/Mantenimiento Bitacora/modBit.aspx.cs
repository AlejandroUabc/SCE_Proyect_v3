using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace SCE_Project.Mantenimienro_Bitacora
{
    public partial class modBit : System.Web.UI.Page
    {
        ComandoSQL comm;

        //método Page_Load carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se intancia la clase ComandoSQL que contiene el manejo de
            //la base de datos para hacer un uso mas practico de la conexión
            comm = new ComandoSQL();

            //Se hace uso del método Cargar() creado con anterioridad, para que cargue 
            //los choferes que estén registrados
            cargar();

            txFechaCon.Text = DateTime.Now.ToString("YYYY-MM-DD");

            txFechaCon.Visible = false;
            ddlCapCon.Visible = false;
            //txRevPap.Visible = false;
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
            btModificar.Visible = false;
            ddlRevPapCon.Visible = false;
            camion3.Visible = false;
            camion.Visible = false;
            camion2.Visible = false;


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
            etNom2.Visible = false;

        }

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
            comm.Conectar();
            List<mostrarBit3> lista = comm.CargarConsulta("CargarConsulta", txFechaInic.Text, txFechaFin.Text);
            return lista;
        }
        private List<mostrarBit3> cargarBitEsp()
        {
            comm.Conectar();
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
                if (ddlNom.SelectedIndex == 0)
                {
                    this.gdvBit.DataSource = cargarBit();
                    gdvBit.DataBind();
                    gdvBit.Visible = true;
                    cargar();

                }

                //si selecciona un nombre sólo las bitácoras buscadas con el nombre específico apareceran
                else {
                    gdvBit.DataSource = cargarBitEsp();
                    gdvBit.DataBind();
                    gdvBit.Visible = true;
                    cargar();
                }
            }
        }

        GridViewRow row;
        //Muestra la tabla con los datos de la bitácora encontrada
        protected void gdv1_SelectedIndexChanged1(object sender, EventArgs e)
        {


            row = gdvBit.SelectedRow;

            //Toma los datos de la bitácora del renglon seleccionado y los iguala a un label para despúes ser utilizado
            etNom2.Text = row.Cells[0].Text;

            gdvBit.Visible = false;


            etFechaInic.Visible = false;
            txFechaInic.Visible = false;
            etFechaFin.Visible = false;
            txFechaFin.Visible = false;
            btBuscar.Visible = false;
            ddlNom.Visible = false;
            etNom.Visible = false;

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
            btModificar.Visible = true;

            etFechaCon.Visible = true;
            etCapCon.Visible = true;
            etRevPapCon.Visible = true;
            etNumRuta.Visible = true;
            etNumCam.Visible = true;
            etHS.Visible = true;
            etNumCaja.Visible = true;
            etHR.Visible = true;
            etKmInic.Visible = true;
            etKmFin.Visible = true;
            etComRuta.Visible = true;
            etNumRem.Visible = true;
            etNomCli.Visible = true;
            etHoraLlegada.Visible = true;
            etHoraSal.Visible = true;
            etTD.Visible = true;
            etComCli.Visible = true;
            camion3.Visible = true;
            camion.Visible = true;
            camion2.Visible = true;

            comm.Conectar();
            encabezadoBit bit = comm.obtenerBitacora("ObtenerBitacora", etNom2.Text);


            //Se hace una comparación donde se posiciona el textbox en la revisión de papeleo con el que se habia registrado
            // y se le da la opcion al supervisor de modificar ese dato
            if ((string.Compare(bit.revPap, "Mañana") == 0))
            {
                ddlRevPapCon.SelectedIndex = 1;
            }
            else if ((string.Compare(bit.revPap, "Tarde") == 0))
            {
                ddlRevPapCon.SelectedIndex = 2;
            }

            //Se hace una comparación donde se posiciona el textbox en el porcentaje con el que se habia registrado
            // y se le da la opcion al supervisor de modificar ese dato
            if (string.Compare(bit.capCam, "10%") == 0)
            {
                ddlCapCon.SelectedIndex = 1;
            }
            else if ((string.Compare(bit.capCam, "20%") == 0))
            {
                ddlCapCon.SelectedIndex = 2;
            }
            else if ((string.Compare(bit.capCam, "30%") == 0))
            {
                ddlCapCon.SelectedIndex = 3;
            }
            else if ((string.Compare(bit.capCam, "40%") == 0))
            {
                ddlCapCon.SelectedIndex = 4;
            }
            else if ((string.Compare(bit.capCam, "50%") == 0))
            {
                ddlCapCon.SelectedIndex = 5;
            }
            else if ((string.Compare(bit.capCam, "60%") == 0))
            {
                ddlCapCon.SelectedIndex = 6;
            }
            else if ((string.Compare(bit.capCam, "70%") == 0))
            {
                ddlCapCon.SelectedIndex = 7;
            }
            else if ((string.Compare(bit.capCam, "80%") == 0))
            {
                ddlCapCon.SelectedIndex = 8;
            }
            else if ((string.Compare(bit.capCam, "90%") == 0))
            {
                ddlCapCon.SelectedIndex = 9;
            }
            else if ((string.Compare(bit.capCam, "100%") == 0))
            {
                ddlCapCon.SelectedIndex = 10;
            }

            string[] fecha = bit.fecha.Split(' ');
            txFechaCon.Text = fecha[0];

            //txFechaCon.Text = bit.fecha;



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

        // se hace la modificación de los datos 
        protected void btModificar_Click(object sender, EventArgs e)
        {
            //Se hacen diferentes conversiones para después poder hacer validaciones especificadas en los IF
            int KmFin, KmInic;
            KmFin = Convert.ToInt32(txKmFin.Text);
            KmInic = Convert.ToInt32(txKmInic.Text);
            DateTime HS = Convert.ToDateTime(txHS.Text);
            DateTime HR = Convert.ToDateTime(txHR.Text);
            DateTime HoraLlegada = Convert.ToDateTime(txHoraLlegada.Text);
            DateTime HoraSal = Convert.ToDateTime(txHoraSal.Text);

            if (KmFin < KmInic)
            {
                Response.Write("<script language=javascript>alert('El kilometraje inicial no puede ser mayor que el kilometraje final!')</script>");
            }
            else
                if (HS > HR)
            {
                Response.Write("<script language=javascript>alert('La hora de salida no puede ser menor que la hora de regreso!')</script>");
            }
            else
                    if (HoraSal < HoraLlegada)
            {
                Response.Write("<script language=javascript>alert('La hora de salida con el cliente no puede ser menor que la <br> hora de llegada con el cliente!')</script>");
            }
            else
            {
                encabezadoBit bit = new encabezadoBit();
                bit.idBitacoraid = etNom2.Text;
                bit.nomUsu = ddlNom.Text;
                bit.hs = txHS.Text;
                bit.hr = txHR.Text;
                bit.kmInic = txKmInic.Text;
                bit.kmFin = txKmFin.Text;
                bit.comRuta = txComRuta.Text;
                bit.noCam = txNumCam.Text;
                bit.noCaja = txNumCaja.Text;
                bit.noRuta = txNumRuta.Text;
                bit.revPap = ddlRevPapCon.Text;
                bit.capCam = ddlCapCon.Text;
                bit.noRem = txNumRem.Text;
                bit.nomCliente = txNomCli.Text;
                bit.hLlegadaCli = txHoraLlegada.Text;
                bit.hSalCli = txHoraSal.Text;
                bit.tiempoDesc = txTD.Text;
                bit.comClie = txComCli.Text;
                comm.Conectar();
                comm.queryExecuteMod("ModificarBitacora", bit);
                Response.Write("<script language=javascript>alert('Modificación exitosa!')</script>");
            }
        }
    }
}