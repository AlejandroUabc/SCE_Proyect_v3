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


        }

        private void cargar()
        {


        }

        protected void btest_Click(object sender, EventArgs e)
        {
            if (ddllista.SelectedIndex == 1)
            {
                com.conectar();

                GridView1.DataSource = com.consultaTiempoenRuta(txfecha1.Text, txfecha2.Text);
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            if (ddllista.SelectedIndex == 2)
            {
                com.conectar();

                GridView1.DataSource = com.consultaKmRecorrido(txfecha1.Text, txfecha2.Text);
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            if (ddllista.SelectedIndex == 3)
            {
                com.conectar();

                GridView1.DataSource = com.consultaNumOrdenes(txfecha1.Text, txfecha2.Text);
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            if (ddllista.SelectedIndex == 4)
            {
                com.conectar();

                GridView1.DataSource = com.consultaKmRecorrido(txfecha1.Text, txfecha2.Text);
                GridView1.DataBind();
                GridView1.Visible = true;

                com.conectar();

                GridView1.DataSource = com.consultaKmRecorrido(txfecha1.Text, txfecha2.Text);
                GridView1.DataBind();
                GridView1.Visible = true;

                com.conectar();

                GridView1.DataSource = com.consultaTiempoenRuta(txfecha1.Text, txfecha2.Text);
                GridView1.DataBind();
                GridView1.Visible = true;
            }

        }
    }
}