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
        public HojaClinicaDAO()
        {
            cs = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        // Crea una atención y devuelve true si se insertó
        public int CrearAtencion(HojaClinica h)
        {
            using (var cn = new SqlConnection(cs))
            {
                using (var cmd = new SqlCommand("spCrearHojaClinica", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdMascota", h.MascotaId);
                    cmd.Parameters.AddWithValue("@pFechaAdiccion", h.FechaAtencion);
                    cmd.Parameters.AddWithValue("@pSintomas", h.Sintomas);
                    cmd.Parameters.AddWithValue("@pDiagnostico", h.Diagnostico);
                    cmd.Parameters.AddWithValue("@pTratamiento", h.Tratamiento);
                    cmd.Parameters.AddWithValue("@pAdicionadoPor", h.AdicionadoPor);

                    try
                    {
                        cn.Open();
                        var nuevoId = cmd.ExecuteScalar();
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
                        throw new Exception("Error al crear la atención: " + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
        }
    }
}