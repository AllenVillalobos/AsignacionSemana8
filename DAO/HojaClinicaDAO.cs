using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AsignacionSemana8.Models;

namespace AsignacionSemana8.DAO
{
    public class HojaClinicaDAO
    {
        private readonly string cs;
        /// <summary>
        /// Constructor del DAO. Obtiene la cadena de conexión desde Web.config.
        /// </summary>
        public HojaClinicaDAO()
        {
            cs = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        /// <summary>
        /// Crea una nueva atención (hoja clínica) en la base de datos usando un procedimiento almacenado.
        /// </summary>
        /// <param name="h">Objeto HojaClinica con los datos de la atención.</param>
        /// <returns>
        /// Devuelve el ID generado de la nueva hoja clínica.
        /// Retorna 0 si la inserción no generó un ID.
        /// </returns>
        public int CrearAtencion(HojaClinica h)
        {
            using (var cn = new SqlConnection(cs))
            {
                using (var cmd = new SqlCommand("spCrearHojaClinica", cn))
                {
                    // Configurar el comando como Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Asignar parámetros al SP
                    cmd.Parameters.AddWithValue("@pIdMascota", h.MascotaId);
                    cmd.Parameters.AddWithValue("@pFechaAdiccion", h.FechaAtencion);
                    cmd.Parameters.AddWithValue("@pSintomas", h.Sintomas);
                    cmd.Parameters.AddWithValue("@pDiagnostico", h.Diagnostico);
                    cmd.Parameters.AddWithValue("@pTratamiento", h.Tratamiento);
                    cmd.Parameters.AddWithValue("@pAdicionadoPor", h.AdicionadoPor);

                    try
                    {
                        cn.Open();

                        // Ejecuta el SP y obtiene el ID insertado
                        var nuevoId = cmd.ExecuteScalar();

                        // Si no devuelve ID, se considera fallo
                        if (nuevoId == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(nuevoId);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Error controlado que se envía hacia arriba
                        throw new Exception("Error al crear la atención: " + ex.Message);
                    }
                    finally
                    {
                        // Cierre explícito de la conexión
                        cn.Close();
                    }
                }
            }
        }
    }
}






