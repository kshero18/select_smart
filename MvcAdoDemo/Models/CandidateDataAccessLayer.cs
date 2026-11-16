using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MvcAdoDemo.Models
{
    // Modernisation of the recovered 2020 ADO.NET exercise.
    public class CandidateDataAccessLayer
    {
        private readonly string connectionString =
            Environment.GetEnvironmentVariable("CPSMART_CONNECTION_STRING")
            ?? throw new InvalidOperationException(
                "Set CPSMART_CONNECTION_STRING before running the application.");

        public IEnumerable<candidate> GetAllCandidate()
        {
            var result = new List<candidate>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("cpGetAllCandidate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapCandidate(reader));
                    }
                }
            }
            return result;
        }

        public void AddCandidate(candidate value)
        {
            ExecuteCandidateProcedure("cpAddCandidate", value);
        }

        public void UpdateCandidate(candidate value)
        {
            ExecuteCandidateProcedure("cpUpdateCandidate", value);
        }

        public candidate GetCandidateData(int? id)
        {
            if (!id.HasValue) return null;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(
                "SELECT Regno, Name, Email, Phoneno, Dept, skills, Yearofpassing, CGPA, Backlogs " +
                "FROM dbo.candidate WHERE Regno = @Regno", connection))
            {
                command.Parameters.Add("@Regno", SqlDbType.Int).Value = id.Value;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapCandidate(reader) : null;
                }
            }
        }

        public void DeleteCandidate(int? id)
        {
            if (!id.HasValue) throw new ArgumentException("Candidate ID is required.", nameof(id));
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("cpDeleteCandidate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Regno", SqlDbType.Int).Value = id.Value;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteCandidateProcedure(string procedure, candidate value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(procedure, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Regno", SqlDbType.Int).Value = value.Regno;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = value.Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 254).Value = value.Email;
                command.Parameters.Add("@Phoneno", SqlDbType.NVarChar, 30).Value = value.Phoneno;
                command.Parameters.Add("@Dept", SqlDbType.NVarChar, 20).Value = (object)value.Dept ?? DBNull.Value;
                command.Parameters.Add("@skills", SqlDbType.NVarChar, 100).Value = (object)value.skills ?? DBNull.Value;
                command.Parameters.Add("@Yearofpassing", SqlDbType.Int).Value = (object)value.Yearofpassing ?? DBNull.Value;
                command.Parameters.Add("@CGPA", SqlDbType.Float).Value = (object)value.CGPA ?? DBNull.Value;
                command.Parameters.Add("@Backlogs", SqlDbType.Int).Value = (object)value.Backlogs ?? DBNull.Value;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static candidate MapCandidate(SqlDataReader reader)
        {
            return new candidate
            {
                Regno = reader.GetInt32(reader.GetOrdinal("Regno")),
                Name = reader["Name"].ToString(),
                Email = reader["Email"].ToString(),
                Phoneno = reader["Phoneno"].ToString(),
                Dept = reader["Dept"] == DBNull.Value ? null : reader["Dept"].ToString(),
                skills = reader["skills"] == DBNull.Value ? null : reader["skills"].ToString(),
                Yearofpassing = reader["Yearofpassing"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Yearofpassing"]),
                CGPA = reader["CGPA"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["CGPA"]),
                Backlogs = reader["Backlogs"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Backlogs"])
            };
        }
    }
}
