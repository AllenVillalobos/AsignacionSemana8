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
    public class MascotaDAO
    {
        private readonly string cadenaConexion;
        public MascotaDAO()
        {
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }

        public int InsertarMascota(Mascota mascota)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spInsertarMascota", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                        connection.Open();
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
        public int ActualizarMascota(Mascota mascota)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand command = new SqlCommand("spActualizarMascota", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdentificadorMascota", mascota.MascotaId);
                    command.Parameters.AddWithValue("@pNombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@pPeso", mascota.Peso);
                    command.Parameters.AddWithValue("@pAlergias", mascota.Alergias);
                    command.Parameters.AddWithValue("@pModificadoPor", mascota.ModificadoPor);
                    command.Parameters.AddWithValue("@pFechaModificacion", mascota.FechaModificacion);
                    try
                    {
                        connection.Open();
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
        public Mascota BuscarMascotaPorID(int id)
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

                                    MascotaId = reader["MAS_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MAS_ID"]),
                                    Nombre = reader["MAS_NOMBRE"] == DBNull.Value ? "" : reader["MAS_NOMBRE"].ToString(),
                                    FechaNacimiento = reader["MAS_FECHA_NACIMIENTO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MAS_FECHA_NACIMIENTO"]),
                                    Sexo = reader["MAS_SEXO"] == DBNull.Value ? "" : reader["MAS_SEXO"].ToString(),
                                    Peso = reader["MAS_PESO"] == DBNull.Value ? 0 : Convert.ToSingle(reader["MAS_PESO"]),
                                    Alergias = reader["MAS_ALERGIAS"] == DBNull.Value ? "" : reader["MAS_ALERGIAS"].ToString(),
                                    PropietarioId = reader["MAS_PRO_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MAS_PRO_ID"]),
                                    AdicionadoPor = reader["MAS_ADICIONADO_POR"] == DBNull.Value ? "" : reader["MAS_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["MAS_FECHA_ADICION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MAS_FECHA_ADICION"]),
                                    ModificadoPor = reader["MAS_MODIFICADO_POR"] == DBNull.Value ? "" : reader["MAS_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["MAS_FECHA_MODIFICACION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MAS_FECHA_MODIFICACION"])
                                };
                                mascotas.Add(mascota);
                            }
                        }
                        var mascotaFiltro = from m in mascotas
                                            where m.MascotaId == id
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

                                    MascotaId = reader["MAS_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MAS_ID"]),
                                    Nombre = reader["MAS_NOMBRE"] == DBNull.Value ? "" : reader["MAS_NOMBRE"].ToString(),
                                    FechaNacimiento = reader["MAS_FECHA_NACIMIENTO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MAS_FECHA_NACIMIENTO"]),
                                    Sexo = reader["MAS_SEXO"] == DBNull.Value ? "" : reader["MAS_SEXO"].ToString(),
                                    Peso = reader["MAS_PESO"] == DBNull.Value ? 0 : Convert.ToSingle(reader["MAS_PESO"]),
                                    Alergias = reader["MAS_ALERGIAS"] == DBNull.Value ? "" : reader["MAS_ALERGIAS"].ToString(),
                                    PropietarioId = reader["MAS_PRO_ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["MAS_PRO_ID"]),
                                    AdicionadoPor = reader["MAS_ADICIONADO_POR"] == DBNull.Value ? "" : reader["MAS_ADICIONADO_POR"].ToString(),
                                    FechaAdicion = reader["MAS_FECHA_ADICION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MAS_FECHA_ADICION"]),
                                    ModificadoPor = reader["MAS_MODIFICADO_POR"] == DBNull.Value ? "" : reader["MAS_MODIFICADO_POR"].ToString(),
                                    FechaModificacion = reader["MAS_FECHA_MODIFICACION"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["MAS_FECHA_MODIFICACION"])
                                };
                                mascotas.Add(mascota);
                            }
                        }
                        var mascotaFiltro = from m in mascotas
                                            where m.PropietarioId == idPropietario && m.Nombre.ToLower() == nombre.ToLower()
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
