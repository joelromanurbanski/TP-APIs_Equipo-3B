using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace SQL
{
    public class ArticuloSQL
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenSQL imagenSQL = new ImagenSQL();

            try
            {
                datos.setearConsulta(@"SELECT A.Id, Codigo, Nombre, A.Descripcion, A.Precio, 
                            A.IdMarca, A.IdCategoria, 
                            M.Descripcion Marca, C.Descripcion Categoria,
                            (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) UrlImagen
                            FROM ARTICULOS A
                            LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                            LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Precio = datos.Lector["Precio"] != DBNull.Value ? (decimal)datos.Lector["Precio"] : 0,
                        IdMarca = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0,
                        IdCategoria = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0,
                        Marca = new Marca { Descripcion = datos.Lector["Marca"].ToString() },
                        Categoria = new Categoria { Descripcion = datos.Lector["Categoria"].ToString() },
                        UrlImagen = datos.Lector["UrlImagen"] != DBNull.Value ? datos.Lector["UrlImagen"].ToString() : ""
                    };

                    art.Imagenes = imagenSQL.ListarPorArticulo(art.Id);
                    lista.Add(art);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Articulo BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            ImagenSQL imagenSQL = new ImagenSQL();

            try
            {
                datos.setearConsulta(@"SELECT A.Id, Codigo, Nombre, A.Descripcion, A.Precio, 
                                A.IdMarca, A.IdCategoria, 
                                M.Descripcion Marca, C.Descripcion Categoria,
                                (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) UrlImagen
                                FROM ARTICULOS A
                                LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                                LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                                WHERE A.Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Articulo art = new Articulo
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Precio = datos.Lector["Precio"] != DBNull.Value ? (decimal)datos.Lector["Precio"] : 0,
                        IdMarca = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0,
                        IdCategoria = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0,
                        Marca = new Marca { Descripcion = datos.Lector["Marca"].ToString() },
                        Categoria = new Categoria { Descripcion = datos.Lector["Categoria"].ToString() },
                        UrlImagen = datos.Lector["UrlImagen"] != DBNull.Value ? datos.Lector["UrlImagen"].ToString() : ""
                    };

                    art.Imagenes = imagenSQL.ListarPorArticulo(art.Id);
                    return art;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar artículo por ID: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
