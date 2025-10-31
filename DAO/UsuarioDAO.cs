using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AsignacionSemana8.DAO
{
    public class UsuarioDAO
    {
        private readonly string cadenaConexion;
        public UsuarioDAO()
        {
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        public DataTable Login(string nombre, string contra)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spLogin", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pNombreUsuario", nombre);
                    command.Parameters.AddWithValue("@pContra", contra);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al ejecutar el procedimiento almacenado spLogin: " + ex.Message);
                    }
                }
            }
        }
    }
}