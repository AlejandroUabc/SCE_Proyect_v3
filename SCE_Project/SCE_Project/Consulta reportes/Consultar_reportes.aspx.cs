using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Security;

namespace SCE_Project.Consulta_reportes
{
    public partial class Consultar_reportes : System.Web.UI.Page
    {
        ComandoSQLCon com;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page_load es un constructor que carga la pagina y crea un objeto de la clase ComandoSQLCon

            com = new ComandoSQLCon();
            cargar();
            gdv1.Visible = false;
            etres1.Visible = false;
            etres2.Visible = false;

            txres1.Visible = false;
            txres2.Visible = false;



        }

        private void cargar()
        {


        }

        protected void btest_Click(object sender, EventArgs e)
        {
            //el metodo btest_Click hace la ejecución de un botón el cual visualizará las consultas correspondientes
            DateTime fechaInic = Convert.ToDateTime(txfecha1.Text);
            DateTime fechaFin = Convert.ToDateTime(txfecha2.Text);

            if (fechaInic > fechaFin)
            {
                //Se valida la fecha que no sea mayor a la segunda fecha
                Response.Write("<script language='JavaScript'>alert('La fecha inicial no puede ser mayor que la fecha final');</script>");
            }
            else {
                if (ddllista.SelectedIndex == 0)
                {
                    Response.Write("<script language='JavaScript'>alert('No has seleccionado ninguna opción.');</script>");
                    gdv1.Visible = false;
                    etres1.Visible = false;
                    etres2.Visible = false;

                    txres1.Visible = false;
                    txres2.Visible = false;

                }

                if (ddllista.SelectedIndex == 1)
                {
                    com.conectar();
                    etres1.Visible = true;
                    etres2.Visible = false;

                    txres1.Visible = true;
                    txres2.Visible = false;


                    gdv1.DataSource = com.consultaTiempoenRuta(txfecha1.Text, txfecha2.Text);
                    gdv1.DataBind();
                    gdv1.Visible = true;
                    double total = 0;
                    for (int x = 0; x < gdv1.Rows.Count; x++)
                    {
                        total = total + double.Parse(gdv1.Rows[x].Cells[0].Text);
                    }
                    txres1.Text = total.ToString();
                }

                if (ddllista.SelectedIndex == 2)
                {
                    com.conectar();
                    etres1.Visible = false;
                    etres2.Visible = true;

                    txres1.Visible = false;
                    txres2.Visible = true;

                    gdv1.DataSource = com.consultaKmRecorrido(txfecha1.Text, txfecha2.Text);
                    gdv1.DataBind();
                    gdv1.Visible = true;
                    double total = 0;
                    for (int x = 0; x < gdv1.Rows.Count; x++)
                    {
                        total = total + double.Parse(gdv1.Rows[x].Cells[0].Text);
                    }
                    txres2.Text = total.ToString();

                }
                if (ddllista.SelectedIndex == 3)
                {
                    com.conectar();
                    etres1.Visible = false;
                    etres2.Visible = false;

                    txres1.Visible = false;
                    txres2.Visible = false;

                    gdv1.DataSource = com.consultaNumOrdenes(txfecha1.Text, txfecha2.Text);
                    gdv1.DataBind();
                    gdv1.Visible = true;

                }

                if (ddllista.SelectedIndex == 4)
                {
                    com.conectar();
                    etres1.Visible = true;
                    etres2.Visible = true;

                    txres1.Visible = true;
                    txres2.Visible = true;

                    gdv1.DataSource = com.consultaEstGen(txfecha1.Text, txfecha2.Text);
                    gdv1.DataBind();
                    gdv1.Visible = true;
                    double tr = 0;
                    double km = 0;
                    for (int x = 0; x < gdv1.Rows.Count; x++)
                    {
                        tr = tr + double.Parse(gdv1.Rows[x].Cells[0].Text);
                        km = km + double.Parse(gdv1.Rows[x].Cells[1].Text);
                    }
                    txres1.Text = tr.ToString();
                    txres2.Text = km.ToString();



                }
            }

        }
    }
}