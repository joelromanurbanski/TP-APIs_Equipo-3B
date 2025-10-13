using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQL;
using Dominio;

namespace tp_web_equipo_3b
{
    public partial class ElegirProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarPremios();
        }

        private void CargarPremios()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Traemos artículos con TODAS sus imágenes
                datos.setearConsulta(@"
                    SELECT A.Id, A.Nombre, A.Descripcion, I.ImagenUrl
                    FROM ARTICULOS A
                    LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");

                datos.ejecutarLectura();

                Dictionary<int, Articulo> articulos = new Dictionary<int, Articulo>();

                while (datos.Lector.Read())
                {
                    int id = (int)datos.Lector["Id"];

                    // Si el artículo aún no existe en el diccionario, lo agregamos
                    if (!articulos.ContainsKey(id))
                    {
                        Articulo art = new Articulo
                        {
                            Id = id,
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Descripcion = datos.Lector["Descripcion"].ToString(),
                            Imagenes = new List<string>()
                        };
                        articulos.Add(id, art);
                    }

                    // Agregar la imagen si existe
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articulos[id].Imagenes.Add(datos.Lector["ImagenUrl"].ToString());
                }

                lista = articulos.Values.ToList();
            }
            finally
            {
                datos.cerrarConexion();
            }

            repPremios.DataSource = lista;
            repPremios.DataBind();
        }

        protected void repPremios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Elegir")
            {
                if (Session["voucher"] == null)
                {
                    lblMensaje.Text = "El voucher no está definido. Volvé al inicio.";
                    return;
                }

                string codigo = Session["voucher"].ToString();
                int idArticulo = int.Parse(e.CommandArgument.ToString());

                // Guardamos en Session lo necesario para el siguiente paso
                Session["codigoVoucher"] = codigo;
                Session["idArticulo"] = idArticulo;

                // Redirigimos a la página para que el cliente ingrese sus datos
                Response.Redirect("IngresaTusDatos.aspx");
            }
        }

        protected void repPremios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Articulo art = (Articulo)e.Item.DataItem;

                DropDownList ddl = (DropDownList)e.Item.FindControl("ddlImagenes");
                Image img = (Image)e.Item.FindControl("imgArticulo");

                ddl.Items.Clear();

                if (art.Imagenes.Count > 0)
                {
                    int contador = 1;
                    foreach (string url in art.Imagenes)
                    {
                        ddl.Items.Add(new ListItem("Imagen " + contador, url));
                        contador++;
                    }

                    img.ImageUrl = art.Imagenes[0];
                }
                else
                {
                    ddl.Items.Add(new ListItem("Sin imagen disponible", "https://via.placeholder.com/200?text=Sin+imagen"));
                    img.ImageUrl = "https://via.placeholder.com/200?text=Sin+imagen";
                }
            }
        }

        protected void ddlImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)ddl.NamingContainer;

            Image img = (Image)item.FindControl("imgArticulo");
            img.ImageUrl = ddl.SelectedValue;
        }
    }
}
