using AsignacionSemana8.Models;
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

        public GridView Login(string nombre, string contra)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spListaUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        List<Usuario> usuarios = new List<Usuario>();
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario
                                {
                                    UsuarioId = reader["USU_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["USU_ID"]),
                                    NombreUsuario = reader["USU_USUARIO"] == DBNull.Value ? "" : reader["USU_USUARIO"].ToString(),
                                    Clave = reader["USU_CLAVE"] == DBNull.Value ? "" : reader["USU_CLAVE"].ToString(),
                                    Estado = reader["USU_ESTADO"] == DBNull.Value ? "" : reader["USU_ESTADO"].ToString(),
                                    AdicionadoPor = reader["USU_ADICIONADO_POR"] == DBNull.Value ? "" : reader["USU_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["USU_FECHA_ADICION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["USU_FECHA_ADICION"]),
                                    ModificadoPor = reader["USU_MODIFICADO_POR"] == DBNull.Value ? "" : reader["USU_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["USU_FECHA_MODIFICACION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["USU_FECHA_MODIFICACION"])


                                };
                                usuarios.Add(usuario);
                            }
                        }
                        var usuarioEncontrado = from u in usuarios
                                                where u.NombreUsuario == nombre && u.Clave == contra
                                                select u;
                        GridView gridView = new GridView();

                        gridView.DataSource = usuarioEncontrado.ToList();
                        gridView.DataBind();
                        return gridView;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al ejecutar el procedimiento almacenado spLogin: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}