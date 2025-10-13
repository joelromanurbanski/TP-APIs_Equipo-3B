using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Dominio;
using SQL;


namespace SQL
{
    public class VoucherSQL
    {
        private AccesoDatos datos;

        public VoucherSQL()
        {
            datos = new AccesoDatos();
        }

        public bool CodigoValido(string codigo)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @codigo AND IdCliente IS NULL AND IdArticulo IS NULL");
                datos.setearParametro("@codigo", codigo);
                object result = datos.ejecutarEscalar();

                return Convert.ToInt32(result) > 0;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void CanjearVoucher(string codigo, int idCliente, int idArticulo)
        {
            try
            {
                datos.setearConsulta(@"UPDATE Vouchers 
                                       SET IdCliente = @idCliente, 
                                           IdArticulo = @idArticulo, 
                                           FechaCanje = @fecha 
                                       WHERE CodigoVoucher = @codigo 
                                       AND IdCliente IS NULL 
                                       AND IdArticulo IS NULL");

                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@fecha", DateTime.Now);
                datos.setearParametro("@codigo", codigo);

                int filas = datos.ejecutarAccion();

                if (filas == 0)
                    throw new Exception("El voucher ya fue canjeado o no es válido.");
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
