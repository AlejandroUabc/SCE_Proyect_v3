using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;

namespace SCE_Project.Login
{
    public partial class Login : System.Web.UI.Page
    {
        ComandoSQLLog clog;

        protected void Page_Load(object sender, EventArgs e)
        {
            clog=new ComandoSQLLog();
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            clog.conectar();
            if (clog.ValidateUser(Login1.UserName, Login1.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);

            }
        }  
    }
}