using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using SQL;
using System.Configuration;
using System.Data.SqlClient;

namespace TiendaGrupo15Progra3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string email = LoginTextUsuario.Text.Trim();
            string dni = LoginTextContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(dni))
            {
                lblMensaje.Text = "Por favor complete todos los campos.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["PromoDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Id FROM Clientes WHERE Email = @Email AND DNI = @Dni";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Dni", dni);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // Guardamos en sesión el Id del cliente autenticado
                    Session["IdCliente"] = Convert.ToInt32(result);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                }
            }
        }
    }
}

