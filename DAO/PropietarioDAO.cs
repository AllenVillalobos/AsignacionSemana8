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
    public class PropietarioDAO
    {
        private readonly string cadenaConexion; 
        public PropietarioDAO()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }
        public Propietario ObtenerPropietario(string identificacion)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spListarPopietarios", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        List<Propietario> propietarios = new List<Propietario>();
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
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
                                    FechaAdicion = reader["PRO_FECHA_ADICION"] as DateTime ?,
                                    ModificadoPor = reader["PRO_MODIFICADO_POR"] == DBNull.Value ? "" : reader["PRO_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["PRO_FECHA_MODIFICACION"] as DateTime?
                                };
                                propietarios.Add(propietario);
                            }
                        }
                        var propietarioFiltro = from p in propietarios
                                                where p.Identificacion == identificacion
                                                select p;
                        Propietario propietarioEncontrado = propietarioFiltro.FirstOrDefault();
                        return propietarioEncontrado;
                    }
                    catch
                    {
                        throw new Exception("Error al llamar la lista de propietarios");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        // Insertar propietario
        public int InsertarPropietario(Propietario propietario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spInsertarPropietario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros según el SP de la base de datos
                    command.Parameters.AddWithValue("@pNumeroIdentificacion", propietario.Identificacion);
                    command.Parameters.AddWithValue("@pPrimerNombre", propietario.PrimerNombre);
                    command.Parameters.AddWithValue("@pSegundoNombre", propietario.SegundoNombre ?? string.Empty);
                    command.Parameters.AddWithValue("@pPrimerApellido", propietario.PrimerApellido);
                    command.Parameters.AddWithValue("@pSegundoApellido", propietario.SegundoApellido ?? string.Empty);
                    command.Parameters.AddWithValue("@pTelefonoCelular", propietario.Telefono);
                    command.Parameters.AddWithValue("@pCorreoElectronico", propietario.Correo);
                    command.Parameters.AddWithValue("@pAdicionadoPor", propietario.AdicionadoPor);
                    command.Parameters.AddWithValue("@pFechaAdicion", propietario.FechaAdicion.HasValue
                        ? propietario.FechaAdicion.Value.ToString("dd/MM/yyyy")
                        : DateTime.Now.ToString("dd/MM/yyyy"));

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery(); // devuelve filas afectadas
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al insertar propietario: " + ex.Message);
                    }
                }
            }
        }

        // Actualizar propietario
        public int ActualizarPropietario(Propietario propietario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spActualizarPropietario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros según el SP de la base de datos
                    command.Parameters.AddWithValue("@pNumeroIdentificacion", propietario.Identificacion);
                    command.Parameters.AddWithValue("@pPrimerNombre", propietario.PrimerNombre);
                    command.Parameters.AddWithValue("@pPrimerApellido", propietario.PrimerApellido);
                    command.Parameters.AddWithValue("@pSegundoApellido", propietario.SegundoApellido ?? string.Empty);
                    command.Parameters.AddWithValue("@pTelefonoCelular", propietario.Telefono);
                    command.Parameters.AddWithValue("@pCorreoElectronico", propietario.Correo);
                    command.Parameters.AddWithValue("@pModificadoPor", propietario.ModificadoPor);
                    command.Parameters.AddWithValue("@pFechaModificacion", propietario.FechaModificacion.HasValue
                        ? propietario.FechaModificacion.Value.ToString("dd/MM/yyyy")
                        : DateTime.Now.ToString("dd/MM/yyyy"));

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al actualizar propietario: " + ex.Message);
                    }
                }
            }
        }
        // Eliminar propietario (eliminación lógica)
        public int EliminarPropietario(int idPropietario)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spEliminarPropietario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdentificadorPropietario", idPropietario);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery(); // devuelve el número de filas afectadas
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