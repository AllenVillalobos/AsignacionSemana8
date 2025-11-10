using AsignacionSemana8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AsignacionSemana8.DAO
{
    /// <summary>
    /// Clase DAO encargada de gestionar las operaciones de base de datos 
    /// relacionadas con la entidad Propietario.
    /// Incluye métodos para obtener, insertar, actualizar y eliminar propietarios.
    /// </summary>
    public class PropietarioDAO
    {
        /// <summary>
        /// Cadena de conexión utilizada para comunicarse con SQL Server.
        /// </summary>
        private readonly string cadenaConexion;

        /// <summary>
        /// Constructor del DAO. Obtiene la cadena de conexión desde Web.config.
        /// </summary>
        public PropietarioDAO()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        /// <summary>
        /// Obtiene un propietario filtrado por su número de identificación.
        /// Ejecuta el procedimiento almacenado spListarPopietarios y filtra en memoria.
        /// </summary>
        /// <param name="identificacion">Identificación del propietario a buscar.</param>
        /// <returns>Objeto Propietario encontrado o null si no existe.</returns>
        public Propietario ObtenerPropietario(string identificacion)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spListarPopietarios", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        // Lista donde se almacenarán temporalmente los propietarios
                        List<Propietario> propietarios = new List<Propietario>();

                        connection.Open(); // Abrir conexión

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Leer cada fila retornada por el SP
                            while (reader.Read())
                            {
                                Propietario propietario = new Propietario
                                {
                                    PropietarioId = reader["PRO_ID"] as int?,
                                    Identificacion = reader["PRO_IDENTIFICACION"] == DBNull.Value ? "" : reader["PRO_IDENTIFICACION"].ToString(),
                                    PrimerNombre = reader["PRO_PRIMER_NOMBRE"] == DBNull.Value ? "" : reader["PRO_PRIMER_NOMBRE"].ToString(),
                                    SegundoNombre = reader["PRO_SEGUNDO_NOMBRE"] == DBNull.Value ? "" : reader["PRO_SEGUNDO_NOMBRE"].ToString(),
                                    PrimerApellido = reader["PRO_PRIMER_APELLIDO"] == DBNull.Value ? "" : reader["PRO_PRIMER_APELLIDO"].ToString(),
                                    SegundoApellido = reader["PRO_SEGUNDO_APELLIDO"] == DBNull.Value ? "" : reader["PRO_SEGUNDO_APELLIDO"].ToString(),
                                    Telefono = reader["PRO_TELEFONO"] == DBNull.Value ? "" : reader["PRO_TELEFONO"].ToString(),
                                    Correo = reader["PRO_CORREO"] == DBNull.Value ? "" : reader["PRO_CORREO"].ToString(),
                                    AdicionadoPor = reader["PRO_ADICIONADO_POR"] == DBNull.Value ? "" : reader["PRO_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["PRO_FECHA_ADICION"] as DateTime?,
                                    ModificadoPor = reader["PRO_MODIFICADO_POR"] == DBNull.Value ? "" : reader["PRO_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["PRO_FECHA_MODIFICACION"] as DateTime?
                                };

                                propietarios.Add(propietario); // Agregar a la lista temporal
                            }
                        }

                        // LINQ para filtrar por identificación
                        var propietarioFiltro = from p in propietarios
                                                where p.Identificacion == identificacion
                                                select p;

                        // Obtiene el primer propietario coincidente
                        Propietario propietarioEncontrado = propietarioFiltro.FirstOrDefault();

                        return propietarioEncontrado;
                    }
                    catch
                    {
                        // Error al ejecutar el SP
                        throw new Exception("Error al llamar la lista de propietarios");
                    }
                    finally
                    {
                        connection.Close(); // Cerrar conexión
                    }
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo propietario en la base de datos ejecutando el SP spInsertarPropietario.
        /// </summary>
        /// <param name="propietario">Objeto Propietario con los datos a insertar.</param>
        /// <returns>Número de filas afectadas.</returns>
        public int InsertarPropietario(Propietario propietario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spInsertarPropietario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Envío de parámetros al SP
                    command.Parameters.AddWithValue("@pNumeroIdentificacion", propietario.Identificacion);
                    command.Parameters.AddWithValue("@pPrimerNombre", propietario.PrimerNombre);
                    command.Parameters.AddWithValue("@pSegundoNombre", propietario.SegundoNombre ?? string.Empty);
                    command.Parameters.AddWithValue("@pPrimerApellido", propietario.PrimerApellido);
                    command.Parameters.AddWithValue("@pSegundoApellido", propietario.SegundoApellido ?? string.Empty);
                    command.Parameters.AddWithValue("@pTelefonoCelular", propietario.Telefono);
                    command.Parameters.AddWithValue("@pCorreoElectronico", propietario.Correo);
                    command.Parameters.AddWithValue("@pAdicionadoPor", propietario.AdicionadoPor);

                    // Fecha se envía como string en formato dd/MM/yyyy
                    command.Parameters.AddWithValue("@pFechaAdicion",
                        propietario.FechaAdicion.HasValue
                        ? propietario.FechaAdicion.Value.ToString("dd/MM/yyyy")
                        : DateTime.Now.ToString("dd/MM/yyyy"));

                    try
                    {
                        connection.Open(); // Abrir conexión

                        // Retorna número de filas afectadas
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al insertar propietario: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza un propietario existente ejecutando el SP spActualizarPropietario.
        /// </summary>
        /// <param name="propietario">Objeto Propietario con los datos modificados.</param>
        /// <returns>Número de filas afectadas.</returns>
        public int ActualizarPropietario(Propietario propietario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spActualizarPropietario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros esperados por el SP
                    command.Parameters.AddWithValue("@pNumeroIdentificacion", propietario.Identificacion);
                    command.Parameters.AddWithValue("@pPrimerNombre", propietario.PrimerNombre);
                    command.Parameters.AddWithValue("@pPrimerApellido", propietario.PrimerApellido);
                    command.Parameters.AddWithValue("@pSegundoApellido", propietario.SegundoApellido ?? string.Empty);
                    command.Parameters.AddWithValue("@pTelefonoCelular", propietario.Telefono);
                    command.Parameters.AddWithValue("@pCorreoElectronico", propietario.Correo);
                    command.Parameters.AddWithValue("@pModificadoPor", propietario.ModificadoPor);

                    // Fecha en formato dd/MM/yyyy
                    command.Parameters.AddWithValue("@pFechaModificacion",
                        propietario.FechaModificacion.HasValue
                        ? propietario.FechaModificacion.Value.ToString("dd/MM/yyyy")
                        : DateTime.Now.ToString("dd/MM/yyyy"));

                    try
                    {
                        connection.Open();

                        // Ejecuta el comando y retorna filas afectadas
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al actualizar propietario: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Elimina (lógicamente) un propietario usando el SP spEliminarPropietario.
        /// </summary>
        /// <param name="idPropietario">ID del propietario a eliminar.</param>
        /// <returns>Número de filas afectadas.</returns>
        public int EliminarPropietario(int idPropietario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spEliminarPropietario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetro requerido por el SP
                    command.Parameters.AddWithValue("@pIdentificadorPropietario", idPropietario);

                    try
                    {
                        connection.Open();

                        // Realiza la eliminación lógica
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar propietario: " + ex.Message);
                    }
                }
            }
        }
    }
}
