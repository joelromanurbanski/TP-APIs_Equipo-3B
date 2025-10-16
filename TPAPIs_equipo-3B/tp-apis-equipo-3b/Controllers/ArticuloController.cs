using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio;
using SQL;

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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Articulo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Articulo/5
        public void Delete(int id)
        {
        }
    }
}
