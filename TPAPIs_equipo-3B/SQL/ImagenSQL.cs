using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class ImagenSQL
    {
        public List<Imagen> ListarPorArticulo(int idArticulo)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, ImagenUrl FROM IMAGENES WHERE IdArticulo = @id");
                datos.setearParametro("@id", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen
                    {
                        Id = (int)datos.Lector["Id"],
                        UrlImagen = datos.Lector["ImagenUrl"].ToString()
                    };
                    lista.Add(img);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imágenes: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
