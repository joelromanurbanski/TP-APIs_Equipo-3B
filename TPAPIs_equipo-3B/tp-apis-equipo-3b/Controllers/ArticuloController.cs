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
        public IHttpActionResult Post([FromBody] ArticuloDto articuloDto)
        {
            if (articuloDto == null)
                return BadRequest("No se recibió ningún artículo.");

            if (string.IsNullOrWhiteSpace(articuloDto.Codigo) || string.IsNullOrWhiteSpace(articuloDto.Nombre))
                return BadRequest("El código y el nombre son obligatorios.");

            if (articuloDto.Precio < 0)
                return BadRequest("El precio no puede ser negativo.");

            try
            {
                Articulo nuevoArticulo = new Articulo();
                nuevoArticulo.Codigo = articuloDto.Codigo;
                nuevoArticulo.Nombre = articuloDto.Nombre;
                nuevoArticulo.Categoria = new Categoria { Id = articuloDto.IdCategoria };
                nuevoArticulo.Marca = new Marca { Id = articuloDto.IdMarca };
                nuevoArticulo.Descripcion = articuloDto.Descripcion;
                nuevoArticulo.Precio = articuloDto.Precio;
                nuevoArticulo.UrlImagen = articuloDto.UrlImagen;

                int id = new ArticuloSQL().AgregarYDevolverId(nuevoArticulo);
                return Content(HttpStatusCode.Created, $"Artículo creado con ID: {id}");
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al agregar el artículo: " + ex.Message));
            }
        }

        // PUT: api/Articulo/5
        public IHttpActionResult Put(int id, [FromBody] ArticuloDto articuloDto)
        {
            if (id <= 0)
                return BadRequest("ID inválido.");

            if (articuloDto == null)
                return BadRequest("No se recibió ningún artículo.");

            try
            {
                ArticuloSQL negocio = new ArticuloSQL();
                Articulo existente = negocio.BuscarPorId(id);

                if (existente == null)
                    return NotFound();

                Articulo nuevoArticulo = new Articulo();
                nuevoArticulo.Id = id;
                nuevoArticulo.Codigo = articuloDto.Codigo;
                nuevoArticulo.Nombre = articuloDto.Nombre;
                nuevoArticulo.Categoria = new Categoria { Id = articuloDto.IdCategoria };
                nuevoArticulo.Marca = new Marca { Id = articuloDto.IdMarca };
                nuevoArticulo.Descripcion = articuloDto.Descripcion;
                nuevoArticulo.Precio = articuloDto.Precio;
                nuevoArticulo.UrlImagen = articuloDto.UrlImagen;

                negocio.Modificar(nuevoArticulo);
                return Ok("Artículo modificado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al modificar el artículo: " + ex.Message));
            }
        }

        // DELETE: api/Articulo/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("ID inválido.");

            try
            {
                ArticuloSQL negocio = new ArticuloSQL();
                Articulo existente = negocio.BuscarPorId(id);

                if (existente == null)
                    return NotFound();

                negocio.Eliminar(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al eliminar el artículo: " + ex.Message));
            }
        }
    }
}
