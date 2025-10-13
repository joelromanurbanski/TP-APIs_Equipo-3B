using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }  
        public bool Usado { get; set; }       
    }
}

