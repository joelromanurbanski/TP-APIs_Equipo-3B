using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using SQL;

namespace tp_web_equipo_3b
{
    public partial class IngresaTusDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Podés precargar datos si ya están en Session
        }

        // Valida que el checkbox de Términos esté marcado
        protected void cvTerminos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkTerminos.Checked;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblMensaje.Text = "⚠️ Debés completar todos los campos correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                string dni = txtDocumento.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string email = txtEmail.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string ciudad = txtCiudad.Text.Trim();
                string cpTexto = txtCP.Text.Trim();

                // Validación extra en backend (no solo cliente)
                if (!dni.All(char.IsDigit))
                {
                    lblMensaje.Text = "⚠️ El DNI solo puede contener números.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!cpTexto.All(char.IsDigit))
                {
                    lblMensaje.Text = "⚠️ El Código Postal solo puede contener números.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                int cp = int.Parse(cpTexto);

                ClienteSQL clienteSQL = new ClienteSQL();

                // Verifica si ya existe el cliente
                if (!clienteSQL.DniExiste(dni))
                {
                    clienteSQL.AgregarCliente(dni, nombre, apellido, email, direccion, ciudad, cp);
                }

                // Obtengo el Id del cliente
                int idCliente = clienteSQL.ObtenerIdCliente(dni);

                // Recupero voucher y artículo desde Session
                string codigoVoucher = Session["codigoVoucher"] != null ? Session["codigoVoucher"].ToString() : null;
                int idArticulo = Session["idArticulo"] != null ? Convert.ToInt32(Session["idArticulo"]) : 0;

                if (!string.IsNullOrEmpty(codigoVoucher) && idArticulo > 0)
                {
                    VoucherSQL voucherSQL = new VoucherSQL();
                    voucherSQL.CanjearVoucher(codigoVoucher, idCliente, idArticulo);
                }
                else
                {
                    lblMensaje.Text = "Error: faltan datos de voucher o premio.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Guardamos en Session el nombre del cliente para mostrarlo en la confirmación
                Session["nombreusuario"] = nombre;

                // Redirige a la pantalla de confirmación
                Response.Redirect("UsuarioRegistrado.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
