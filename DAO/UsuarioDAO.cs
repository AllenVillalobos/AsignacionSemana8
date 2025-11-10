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
    /// <summary>
    /// DAO encargado de gestionar la autenticación y obtención 
    /// de usuarios desde la base de datos.
    /// </summary>
    public class UsuarioDAO
    {
        /// <summary>
        /// Cadena de conexión obtenida desde Web.config.
        /// </summary>
        private readonly string cadenaConexion;

        /// <summary>
        /// Constructor. Inicializa la cadena de conexión del DAO.
        /// </summary>
        public UsuarioDAO()
        {
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        /// <summary>
        /// Realiza el proceso de inicio de sesión.
        /// Ejecuta el procedimiento almacenado spListaUsuarios y filtra 
        /// al usuario por nombre y contraseña.
        /// </summary>
        /// <param name="nombre">Nombre de usuario ingresado.</param>
        /// <param name="contra">Contraseña ingresada.</param>
        /// <returns>
        /// Objeto Usuario si coincide usuario y contraseña, 
        /// de lo contrario null.
        /// </returns>
        public Usuario Login(string nombre, string contra)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spListaUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        // Lista temporal donde cargaremos todos los usuarios
                        List<Usuario> usuarios = new List<Usuario>();

                        connection.Open(); // Abrimos conexión

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Leemos todos los usuarios retornados por el SP
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario
                                {
                                    UsuarioId = reader["USU_ID"] as int?,
                                    NombreUsuario = reader["USU_USUARIO"] == DBNull.Value ? "" : reader["USU_USUARIO"].ToString(),
                                    Clave = reader["USU_CLAVE"] == DBNull.Value ? "" : reader["USU_CLAVE"].ToString(),
                                    Estado = reader["USU_ESTADO"] == DBNull.Value ? "" : reader["USU_ESTADO"].ToString(),
                                    AdicionadoPor = reader["USU_ADICIONADO_POR"] == DBNull.Value ? "" : reader["USU_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["USU_FECHA_ADICION"] as DateTime?,
                                    ModificadoPor = reader["USU_MODIFICADO_POR"] == DBNull.Value ? "" : reader["USU_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["USU_FECHA_MODIFICACION"] as DateTime?
                                };

                                // Agregamos el usuario leído a la lista
                                usuarios.Add(usuario);
                            }
                        }

                        // Filtramos por credenciales
                        var usuarioFiltro = from u in usuarios
                            where u.NombreUsuario == nombre && u.Clave == contra
                            select u;

                        // Obtenemos el primer usuario coincidente
                        Usuario usuarioEncontrado = usuarioFiltro.FirstOrDefault();

                        return usuarioEncontrado;
                    }
                    catch (Exception ex)
                    {
                        // Control de errores al ejecutar el SP
                        throw new Exception("Error al ejecutar el procedimiento almacenado spLogin: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close(); // Se asegura cerrar la conexión
                    }
                }
            }
        }
    }
}
