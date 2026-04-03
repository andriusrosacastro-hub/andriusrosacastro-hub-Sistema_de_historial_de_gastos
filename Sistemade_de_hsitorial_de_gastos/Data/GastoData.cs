using System.Data;
using Microsoft.Data.SqlClient;
using Sistemade_de_hsitorial_de_gastos.Models;

namespace Sistemade_de_hsitorial_de_gastos.Data
{
    public class GastoData
    {
        private readonly string _connectionString;

        public GastoData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("GastosDB")!;
        }

        // Obtener todos los gastos
        public List<Gasto> ObtenerGastos()
        {
            var lista = new List<Gasto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SP_ObtenerGastos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Gasto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Monto = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                Categoria = reader.GetString(reader.GetOrdinal("Categoria"))
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Obtener un gasto por Id
        public Gasto? ObtenerGastoPorId(int id)
        {
            Gasto? gasto = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SP_ObtenerGastoPorId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gasto = new Gasto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Monto = reader.GetDecimal(reader.GetOrdinal("Monto")),
                                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                Categoria = reader.GetString(reader.GetOrdinal("Categoria"))
                            };
                        }
                    }
                }
            }

            return gasto;
        }

        // Insertar un nuevo gasto
        public bool InsertarGasto(Gasto gasto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SP_InsertarGasto", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
                    cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                    cmd.Parameters.AddWithValue("@Fecha", gasto.Fecha);
                    cmd.Parameters.AddWithValue("@Categoria", gasto.Categoria);

                    connection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Actualizar un gasto existente
        public bool ActualizarGasto(Gasto gasto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SP_ActualizarGasto", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", gasto.Id);
                    cmd.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
                    cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                    cmd.Parameters.AddWithValue("@Fecha", gasto.Fecha);
                    cmd.Parameters.AddWithValue("@Categoria", gasto.Categoria);

                    connection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Eliminar un gasto
        public bool EliminarGasto(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("SP_EliminarGasto", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}