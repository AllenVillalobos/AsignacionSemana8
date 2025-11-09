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
        private readonly string cs =
            ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;

        // Crea una atención y devuelve true si se insertó
        public bool CrearAtencion(HojaClinica h)
        {
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand("spCrearHojaClinica", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MascotaId", (object)h.MascotaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaAtencion", (object)h.FechaAtencion ?? DateTime.Now);
                cmd.Parameters.AddWithValue("@Sintomas", (object)h.Sintomas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Diagnostico", (object)h.Diagnostico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Tratamiento", (object)h.Tratamiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notas", DBNull.Value);
                cmd.Parameters.AddWithValue("@AdicionadoPor", (object)h.AdicionadoPor ?? DBNull.Value);

                var idOut = new SqlParameter("@IdGenerado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(idOut);

                cn.Open();
                var rows = cmd.ExecuteNonQuery();
                if (idOut.Value != DBNull.Value) h.HojaClinicaId = Convert.ToInt32(idOut.Value);
                return rows > 0;
            }
        }

        // Actualiza una atención existente
        public bool ActualizarAtencion(HojaClinica h)
        {
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand("spActualizarHojaClinica", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HojaClinicaId", (object)h.HojaClinicaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MascotaId", (object)h.MascotaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaAtencion", (object)h.FechaAtencion ?? DateTime.Now);
                cmd.Parameters.AddWithValue("@Sintomas", (object)h.Sintomas ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Diagnostico", (object)h.Diagnostico ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Tratamiento", (object)h.Tratamiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Notas", DBNull.Value);
                cmd.Parameters.AddWithValue("@ModificadoPor", (object)h.ModificadoPor ?? DBNull.Value);

                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Elimina una atención por id
        public bool EliminarAtencion(int id)
        {
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand("spEliminarHojaClinica", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAtencion", id);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Obtiene una atención por id
        public HojaClinica ObtenerAtencionPorId(int id)
        {
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand("spObtenerHojaClinica", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAtencion", id);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read()) return Map(rd);
                }
            }
            return null;
        }

        // Lista atenciones por mascota
        public List<HojaClinica> ListarAtencionesPorMascota(int mascotaId)
        {
            var lista = new List<HojaClinica>();
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand("spListarHojaClinicaPorMascota", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MascotaId", mascotaId);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) lista.Add(Map(rd));
                }
            }
            return lista;
        }

        // 
        private static HojaClinica Map(SqlDataReader dr)
        {
            return new HojaClinica
            {
                HojaClinicaId = dr["HojaClinicaId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["HojaClinicaId"]),
                MascotaId = dr["MascotaId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["MascotaId"]),
                FechaAtencion = dr["FechaAtencion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaAtencion"]),
                Sintomas = dr["Sintomas"] == DBNull.Value ? null : dr["Sintomas"].ToString(),
                Diagnostico = dr["Diagnostico"] == DBNull.Value ? null : dr["Diagnostico"].ToString(),
                Tratamiento = dr["Tratamiento"] == DBNull.Value ? null : dr["Tratamiento"].ToString(),
                AdicionadoPor = dr["AdicionadoPor"] == DBNull.Value ? null : dr["AdicionadoPor"].ToString(),
                FechaAdicion = dr["FechaAdicion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaAdicion"]),
                ModificadoPor = dr["ModificadoPor"] == DBNull.Value ? null : dr["ModificadoPor"].ToString(),
                FechaModificacion = dr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaModificacion"])
            };
        }
    }
}
