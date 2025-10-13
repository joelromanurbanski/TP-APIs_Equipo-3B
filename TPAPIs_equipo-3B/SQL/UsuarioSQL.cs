using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Dominio;

namespace SQL
{
    public class UsuarioSQL
    {
        private readonly string connectionString;

        public UsuarioSQL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PromoDB"].ConnectionString;
        }

        public Usuario ValidarLogin(string usuario, string contrasenia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Id, Nombre, Apellido, Email " +
                               "FROM Clientes WHERE Email = @usuario AND DNI = @pass";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", contrasenia);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }
                }
            }
            return null; // No encontró usuario
        }
    }
}
