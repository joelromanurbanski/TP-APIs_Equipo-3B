using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_3b
{
    public partial class UsuarioRegistrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["nombreUsuario"] != null)
                {
                    lblMensaje.Text = "¡Bienvenido, " + Session["nombreUsuario"].ToString() + "! Tu registro fue exitoso 🎉";
                }
                else
                {
                    lblMensaje.Text = "¡Registro exitoso!";
                }
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            // Redirige al inicio
            Response.Redirect("Default.aspx");
        }
    }
}
