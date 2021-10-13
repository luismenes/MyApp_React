using Microsoft.Extensions.Configuration;
using MyApp_React.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_React.Data
{
    public class TiempoRepository
    {

        private readonly string _connectionString;

        public TiempoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Tiempo>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllTiempo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Tiempo>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToTiempo(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Tiempo MapToTiempo(SqlDataReader reader)
        {
            return new Tiempo()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Codigo = reader["Codigo"].ToString(),
                Temp = reader["Temp"].ToString(),
                Pressure = reader["Pressure"].ToString(),
                Humidity = reader["Humidity"].ToString(),
                Temp_min = reader["Temp_min"].ToString(),
                Temp_max = reader["Temp_max"].ToString(),
                Description = reader["Description"].ToString()
            };
        }

        public async Task<Tiempo> GetById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTiempoById", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    Tiempo response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToTiempo(reader);
                        }
                    }

                    return response;
                }
            }
        }

        public async Task Insert(Tiempo tiempo)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertTiempo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Name));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo2", tiempo.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Temp));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Pressure));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Humidity));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Temp_min));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Temp_max));
                    cmd.Parameters.Add(new SqlParameter("@Tiempo1", tiempo.Description));
             
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteTiempo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

    }
}
