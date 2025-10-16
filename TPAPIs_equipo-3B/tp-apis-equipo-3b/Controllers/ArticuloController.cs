using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using SQL;
using tp_apis_equipo_3b.Models;

namespace tp_apis_equipo_3b.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulos
        public IEnumerable<Articulo> Get()
        {
            ArticuloSQL negocio = new ArticuloSQL();
            return negocio.Listar();
        }

        // GET: api/Articulo/5
        public IHttpActionResult Get(int id)
        {
            ArticuloSQL negocio = new ArticuloSQL();
            Articulo articulo = negocio.BuscarPorId(id);

            if (articulo == null)
                return NotFound();

            return Ok(articulo);
        }


        // POST: api/Articulo
        public void Post([FromBody]ArticuloDto articuloDto)
        {
            ArticuloSQL negocio = new ArticuloSQL();
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.Codigo = articuloDto.Codigo;
            nuevoArticulo.Nombre = articuloDto.Nombre;
            nuevoArticulo.Categoria = new Categoria { Id = articuloDto.IdCategoria };
            nuevoArticulo.Marca = new Marca { Id = articuloDto.IdMarca };
            nuevoArticulo.Descripcion = articuloDto.Descripcion;
            nuevoArticulo.Precio = articuloDto.Precio;
            nuevoArticulo.UrlImagen = articuloDto.UrlImagen;

            negocio.AgregarYDevolverId(nuevoArticulo);
            // Aquí podrías devolver el ID del nuevo artículo si es necesario
        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody]ArticuloDto articuloDto)
        {
            ArticuloSQL negocio = new ArticuloSQL();
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.Codigo = articuloDto.Codigo;
            nuevoArticulo.Nombre = articuloDto.Nombre;
            nuevoArticulo.Categoria = new Categoria { Id = articuloDto.IdCategoria };
            nuevoArticulo.Marca = new Marca { Id = articuloDto.IdMarca };
            nuevoArticulo.Descripcion = articuloDto.Descripcion;
            nuevoArticulo.Precio = articuloDto.Precio;
            nuevoArticulo.UrlImagen = articuloDto.UrlImagen;
            nuevoArticulo.Id = id;

            negocio.Modificar(nuevoArticulo);
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
