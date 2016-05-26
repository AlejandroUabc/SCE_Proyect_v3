using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Globalization;

//ddlNom.SelectedIndex = Nombre del chofer
//txHS.Text = Hora de salida de la empresa
//txHR.Text = Hora de regreso a la empresa
//txKmInic.Text = Kilometraje inicial
//txKmFin.Text = Kilometraje final
//txComRuta.Text = Comentario sobre ruta
//txNumCam.Text = Número de camión
//txNumCaja.Text = Número de caja
//txFecha.Text = Fecha
//txNumRuta.Text = Número de ruta
//ddlRev.Text = Revisión de papeleo
//ddlCap.SelectedIndex = Capacidad del camión
//txNumRem.Text = Número de remisión
//txNomCli.Text = Nombre del cliente
//txHoraLlegada.Text = Hora de llegada con el cliente
//txHoraSal.Text = Hora de salida con el cliente
//txTD.Text = Tiempo en descargar
//txComCli.Text = Comentario para el cliente

namespace SCE_Project.Mantenimienro_Bitacora
{
    public partial class registro : System.Web.UI.Page
    {
        ComandoSQL comm;

        //Page Load es un contructor que carga la página y manda a llamar el metodo cargar que este a su vez
        //te muestra los nombres de los choferes que están registrados en la tabla 'usuario'.
        private void Page_Load(object sender, EventArgs e)
        {
            //Se instancia a la clase ComandoSQL para poder usar los metodos que trae consigo esa clase.
            comm = new ComandoSQL();
            cargar();

        }

        //El método cargar trae consigo 
        private void cargar()
        {
           
            comm.Conectar();
            List<string> clist = comm.CargarNombre("CargarUsuarios");
            foreach (string li in clist)
            {
                ddlNom.Items.Add(li);
            }
            
        }

        //BtReg_Click es el método que se activa al dar click en el botón "Registrar Bitácora"
        protected void BtReg_Click(object sender, EventArgs e)
        {
            //se declararon variables(KmFin, KmInic) para hacer la validación de que el kilometraje inicial 
            //No pudiera ser mayor al kilometraje final igual con las demas variables para hacer diferentes validaciones.!.
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
             if (ddlNom.SelectedIndex == 0)
            {
                Response.Write("<script language=javascript>alert('Selecciona el nombre del chofer!')</script>");
            }
            else
            {
                //En caso de que la bitácora alla sido llenada satisfactoriamente se hace abre la conexión,
                //se registran los datos en la tabla bitacoraencabezado a partir del queryExecute
                //y se limpian los campos para poder ser llenada nuevamente
                encabezadoBit bit = new encabezadoBit();
                bit.nomUsu = ddlNom.Text;
                bit.hs = txHS.Text;
                bit.hr = txHR.Text;
                bit.kmInic = txKmInic.Text;
                bit.kmFin = txKmFin.Text;
                bit.comRuta = txComRuta.Text;
                bit.noCam = txNumCam.Text;
                bit.noCaja = txNumCaja.Text;
                bit.fecha = txFecha.Text;
                bit.noRuta = txNumRuta.Text;
                bit.revPap = ddlRev.Text;
                bit.capCam = ddlCap.Text;
                bit.noRem = txNumRem.Text;
                bit.nomCliente = txNomCli.Text;
                bit.hLlegadaCli = txHoraLlegada.Text;
                bit.hSalCli = txHoraSal.Text;
                bit.tiempoDesc = txTD.Text;
                bit.comClie = txComCli.Text;
                comm.Conectar();
                comm.queryExecute("RegistrarBitacora",bit);
                Response.Write("<script language=javascript>alert('Registro exitoso!')</script>");
                ddlNom.SelectedIndex = 0;
                txHS.Text = " ";
                txHR.Text = " ";
                txKmInic.Text = " ";
                txKmFin.Text = " ";
                txComRuta.Text = " ";
                txNumCam.Text = " ";
                txNumCaja.Text = " ";
                txFecha.Text = " ";
                txNumRuta.Text = " ";
                ddlRev.Text = " ";
                ddlCap.SelectedIndex = 0;
                txNumRem.Text = " ";
                txNomCli.Text = " ";
                txHoraLlegada.Text = " ";
                txHoraSal.Text = " ";
                txTD.Text = " ";
                txComCli.Text = " ";
            }
        }
    }
}