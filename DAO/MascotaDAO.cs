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
    /// Clase DAO responsable de gestionar todas las operaciones de acceso a datos
    /// relacionadas con la entidad Mascota. Incluye métodos para insertar, actualizar
    /// y consultar mascotas mediante procedimientos almacenados en SQL Server.
    /// </summary>
    public class MascotaDAO
    {
        /// <summary>
        /// Cadena de conexión utilizada para establecer comunicación con la base de datos.
        /// </summary>
        private readonly string cadenaConexion;

        /// <summary>
        /// Constructor de la clase MascotaDAO. Inicializa la cadena de conexión
        /// obteniéndola desde el archivo de configuración Web.config.
        /// </summary>
        public MascotaDAO()
        {
            // Obtiene la cadena de conexión configurada en Web.config
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        /// <summary>
        /// Inserta una nueva mascota en la base de datos ejecutando el procedimiento
        /// almacenado spInsertarMascota. Envía todos los datos necesarios como parámetros.
        /// </summary>
        /// <param name="mascota">Objeto Mascota con la información a insertar.</param>
        /// <returns>Retorna el ID generado de la mascota o 0 si no se insertó correctamente.</returns>
        public int InsertarMascota(Mascota mascota)
        {
            // Crea la conexión SQL utilizando la cadena de conexión
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                // Crea el comando SQL para ejecutar el procedimiento almacenado
                using (SqlCommand command = new SqlCommand("spInsertarMascota", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agrega parámetros necesarios para el procedimiento almacenado
                    command.Parameters.AddWithValue("@pNombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@pFechaNacimiento", mascota.FechaNacimiento);
                    command.Parameters.AddWithValue("@pSexo", mascota.Sexo);
                    command.Parameters.AddWithValue("@pPeso", mascota.Peso);
                    command.Parameters.AddWithValue("@pAlergias", mascota.Alergias);
                    command.Parameters.AddWithValue("@pIdentificadorPropietario", mascota.PropietarioId);
                    command.Parameters.AddWithValue("@pAdicionadoPor", mascota.AdicionadoPor);
                    command.Parameters.AddWithValue("@pFechaAdicion", mascota.FechaAdicion);

                    try
                    {
                        // Abre conexión
                        connection.Open();

                        // Ejecuta comando y captura ID generado
                        var filasAfectadas = command.ExecuteScalar();

                        // Si no retorna nada, devuelve 0
                        if (filasAfectadas == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(filasAfectadas);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Lanza excepción capturada
                        throw ex;
                    }
                    finally
                    {
                        // Cierra conexión
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza la información de una mascota existente mediante el procedimiento almacenado spActualizarMascota.
        /// </summary>
        /// <param name="mascota">Objeto Mascota con los datos actualizados.</param>
        /// <returns>Retorna el ID de la mascota actualizada o 0 si no se actualizó.</returns>
        public int ActualizarMascota(Mascota mascota)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spActualizarMascota", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros necesarios para actualizar la mascota
                    command.Parameters.AddWithValue("@pIdentificadorMascota", mascota.MascotaId);
                    command.Parameters.AddWithValue("@pNombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@pPeso", mascota.Peso);
                    command.Parameters.AddWithValue("@pAlergias", mascota.Alergias);
                    command.Parameters.AddWithValue("@pModificadoPor", mascota.ModificadoPor);
                    command.Parameters.AddWithValue("@pFechaModificacion", mascota.FechaModificacion);

                    try
                    {
                        connection.Open();

                        // Ejecuta y obtiene valor devuelto
                        var filasAfectadas = command.ExecuteScalar();

                        if (filasAfectadas == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(filasAfectadas);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Busca una mascota por su identificador único consultando el listado completo mediante el SP spListarMascotas.
        /// </summary>
        /// <param name="id">ID de la mascota.</param>
        /// <returns>Objeto Mascota si se encuentra; null si no existe.</returns>
        public Mascota BuscarMascotaPorID(int id)
        {
            // Conexión sin cadena de conexión (error técnico, debería incluir cadenaConexion)
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spListarMascotas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        List<Mascota> mascotas = new List<Mascota>();

                        // Abre conexión
                        connection.Open();

                        // Ejecuta lector de datos
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Lee cada fila devuelta
                            while (reader.Read())
                            {
                                Mascota mascota = new Mascota
                                {
                                    // Asignación de datos con validaciones de DBNull
                                    MascotaId = reader["MAS_ID"] as int?,
                                    Nombre = reader["MAS_NOMBRE"] == DBNull.Value ? "" : reader["MAS_NOMBRE"].ToString(),
                                    FechaNacimiento = reader["MAS_FECHA_NACIMIENTO"] as DateTime?,
                                    Sexo = reader["MAS_SEXO"] == DBNull.Value ? "" : reader["MAS_SEXO"].ToString(),
                                    Peso = (float?)Convert.ToDecimal(reader["MAS_PESO"]),
                                    Alergias = reader["MAS_ALERGIAS"] == DBNull.Value ? "" : reader["MAS_ALERGIAS"].ToString(),
                                    PropietarioId = reader["MAS_PRO_ID"] as int?,
                                    AdicionadoPor = reader["MAS_ADICIONADO_POR"] == DBNull.Value ? "" : reader["MAS_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["MAS_FECHA_ADICION"] as DateTime?,
                                    ModificadoPor = reader["MAS_MODIFICADO_POR"] == DBNull.Value ? "" : reader["MAS_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["MAS_FECHA_MODIFICACION"] as DateTime?
                                };

                                mascotas.Add(mascota);
                            }
                        }

                        // LINQ para filtrar la mascota solicitada
                        var mascotaFiltro = from m in mascotas
                                            where m.MascotaId == id
                                            select m;

                        // Devuelve la primera coincidencia
                        Mascota mascotaEncontrada = mascotaFiltro.FirstOrDefault();
                        return mascotaEncontrada;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        // Cierra conexión
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Busca una mascota por nombre y el ID del propietario.
        /// </summary>
        /// <param name="nombre">Nombre de la mascota.</param>
        /// <param name="idPropietario">ID del propietario.</param>
        /// <returns>Mascota encontrada; null si no existe.</returns>
        public Mascota BuscarMascotaPorNombrePropietarioId(string nombre, int idPropietario)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand("spListarMascotas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        List<Mascota> mascotas = new List<Mascota>();

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Mascota mascota = new Mascota
                                {
                                    MascotaId = reader["MAS_ID"] as int?,
                                    Nombre = reader["MAS_NOMBRE"] == DBNull.Value ? "" : reader["MAS_NOMBRE"].ToString(),
                                    FechaNacimiento = reader["MAS_FECHA_NACIMIENTO"] as DateTime?,
                                    Sexo = reader["MAS_SEXO"] == DBNull.Value ? "" : reader["MAS_SEXO"].ToString(),
                                    Peso = reader["MAS_PESO"] as float?,
                                    Alergias = reader["MAS_ALERGIAS"] == DBNull.Value ? "" : reader["MAS_ALERGIAS"].ToString(),
                                    PropietarioId = reader["MAS_PRO_ID"] as int?,
                                    AdicionadoPor = reader["MAS_ADICIONADO_POR"] == DBNull.Value ? "" : reader["MAS_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["MAS_FECHA_ADICION"] as DateTime?,
                                    ModificadoPor = reader["MAS_MODIFICADO_POR"] == DBNull.Value ? "" : reader["MAS_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["MAS_FECHA_MODIFICACION"] as DateTime?
                                };
                                mascotas.Add(mascota);
                            }
                        }

                        // Filtra por nombre y por propietario
                        var mascotaFiltro = from m in mascotas
                                            where m.PropietarioId == idPropietario &&
                                                  m.Nombre.ToLower() == nombre.ToLower()
                                            select m;

                        Mascota mascotaEncontrada = mascotaFiltro.FirstOrDefault();
                        return mascotaEncontrada;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
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
