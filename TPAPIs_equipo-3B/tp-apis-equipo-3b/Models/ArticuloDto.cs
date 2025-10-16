using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_apis_equipo_3b.Models
{
    public class ArticuloDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string UrlImagen { get; set; }  // Imagen principal

    }
}

    

