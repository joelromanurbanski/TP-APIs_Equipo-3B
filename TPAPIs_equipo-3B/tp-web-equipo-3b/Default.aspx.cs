using Dominio;
using SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;   
using WebGrease.Activities;

namespace tp_web_equipo_3b
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            string codigo = txtVoucher.Text.Trim();
            VoucherSQL voucherSQL = new VoucherSQL();

            if (voucherSQL.CodigoValido(codigo))
            {
                // Guardamos el voucher en Session
                Session["voucher"] = codigo;
                Response.Redirect("ElegirProducto.aspx");
            }
            else
            {
                lblMensaje.Text = "El código ingresado no es válido o ya fue utilizado.";
            }
        }
    }
}
