using AsignacionSemana8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}