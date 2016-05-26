using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SCE_Project.Mantenimienro_Bitacora
{
    public partial class modBit : System.Web.UI.Page
    {
        ComandoSQL comm;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            comm = new ComandoSQL();
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
            List<string> clist = comm.CargarNombre();
            foreach (string li in clist)
            {
                ddlNom.Items.Add(li);
            }
        }

        private List<mostrarBit3> cargarBit()
        {
            comm.Conectar();
            List<mostrarBit3> lista = comm.CargarConsulta(txFechaInic.Text, txFechaFin.Text);
            return lista;
        }
        private List<mostrarBit3> cargarBitEsp()
        {
            comm.Conectar();
            List<mostrarBit3> lista = comm.CargarConsultaEspecifica(txFechaInic.Text, txFechaFin.Text, ddlNom.Text);
            return lista;
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            
            DateTime fechaFin = Convert.ToDateTime(txFechaInic.Text);
            DateTime fechaInic = Convert.ToDateTime(txFechaFin.Text);
            


            
            if (fechaFin > fechaInic)
            {
                Response.Write("<script language=javascript>alert('La fecha inicial no puede ser mayor que la fecha final!')</script>");

            }
            
            else
                if (ddlNom.SelectedIndex == 0)
            {
                this.gdvBit.DataSource = cargarBit();
                gdvBit.DataBind();
                gdvBit.Visible = true;
                cargar();
                //Lista.Items.Clear();
                //cargar();
            }
            else
                gdvBit.DataSource = cargarBitEsp();
            gdvBit.DataBind();
            gdvBit.Visible = true;
            cargar();
        }

        GridViewRow row;
        protected void gdv1_SelectedIndexChanged1(object sender, EventArgs e)
        {


            row = gdvBit.SelectedRow;
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
            encabezadoBit bit = comm.obtenerBitacora(etNom2.Text);
            
            
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


            
            txFechaCon.Text = bit.fecha;
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


        protected void btModificar_Click(object sender, EventArgs e)
        {
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
                        comm.Conectar();
                        comm.queryExecute("UPDATE bitacoraencabezado SET fecha='" + txFechaCon.Text + "', capCam='" + ddlCapCon.Text + "', revPap=" + ddlRevPapCon.SelectedIndex + ", kmInic='" + txKmInic.Text + "', kmFin='" + txKmFin.Text + "', noCaja='" + txNumCaja.Text + "', hr='" + txHR.Text + "', hs='" + txHS.Text + "', comRuta='" + txComRuta.Text + "', noRem=" + txNumRem.Text + ", nomCliente='" + txNomCli.Text + "', hLlegadaCli='" + txHoraLlegada.Text + "', hSalCli='" + txHoraSal.Text + "', comCli='" + txComCli.Text + "', tiempoDesc=" + txTD.Text + ", noRuta=" + txNumRuta.Text + ", noCam='" + txNumCam.Text + "' WHERE idBitacoraid=" + etNom2.Text + " ");
                        Response.Write("<script language=javascript>alert('Modificación exitosa!')</script>");
                    }
        }
    }
}