using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelectSmart.Models
{
    public class candidateDataAccessLayer
    {
        string connectionString = "Put Your Connection string here";
        //To View all employees details
        public IEnumerable<candidate> GetAllCandidate()
        {
            try
            {
                List<candidate> lstcandidate = new List<candidate>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("cpGetAllCandidate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        candidate candidate = new candidate();
                        candidate.Regno = Convert.ToInt32(rdr["Regno"]);
                        candidate.Name = rdr["Name"].ToString();
                        candidate.Email = rdr["Email"].ToString();
                        candidate.Phoneno = rdr["Phoneno"].ToString();
                        candidate.Dept = rdr["Dept"].ToString();
                        candidate.skills = rdr["skills"].ToString();
                        candidate.Yearofpassing = Convert.ToInt32(rdr["Yearofpassing"]);
                        candidate.Backlogs = Convert.ToInt32(rdr["Backlogs"]);
                        lstcandidate.Add(candidate);
                    }
                    con.Close();
                }
                return lstcandidate;
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record 
        public int AddCandidate(candidate candidate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("cpAddCandidate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Regno", candidate.Regno);
                    cmd.Parameters.AddWithValue("@Name", candidate.Name);
                    cmd.Parameters.AddWithValue("@Email", candidate.Email);
                    cmd.Parameters.AddWithValue("@Phoneno", candidate.Phoneno);
                    cmd.Parameters.AddWithValue("@Dept", candidate.Dept);
                    cmd.Parameters.AddWithValue("@skills", candidate.skills);
                    cmd.Parameters.AddWithValue("@Yearofpassing", candidate.Yearofpassing);
                    cmd.Parameters.AddWithValue("@CGPA", candidate.CGPA);
                    cmd.Parameters.AddWithValue("@Backlogs", candidate.Backlogs);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee
        public int UpdateCandidate(candidate candidate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("cpUpdateCandidate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Regno", candidate.Regno);
                    cmd.Parameters.AddWithValue("@Name", candidate.Name);
                    cmd.Parameters.AddWithValue("@Email", candidate.Email);
                    cmd.Parameters.AddWithValue("@Phoneno", candidate.Phoneno);
                    cmd.Parameters.AddWithValue("@Dept", candidate.Dept);
                    cmd.Parameters.AddWithValue("@skills", candidate.skills);
                    cmd.Parameters.AddWithValue("@Yearofpassing", candidate.Yearofpassing);
                    cmd.Parameters.AddWithValue("@CGPA", candidate.CGPA);
                    cmd.Parameters.AddWithValue("@Backlogs", candidate.Backlogs);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee
        public candidate GetCandidateData(int id)
        {
            try
            {
                candidate candidate = new candidate();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM candidate WHERE Regno= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        candidate.Regno = Convert.ToInt32(rdr["Regno"]);
                        candidate.Name = rdr["Name"].ToString();
                        candidate.Email = rdr["Email"].ToString();
                        candidate.Phoneno = rdr["Phoneno"].ToString();
                        candidate.Dept = rdr["Dept"].ToString();
                        candidate.skills = rdr["skills"].ToString();
                        candidate.Yearofpassing = Convert.ToInt32(rdr["Yearofpassing"]);
                        candidate.Backlogs = Convert.ToInt32(rdr["Backlogs"]);
                    }
                }
                return candidate;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record on a particular employee
        public int DeleteCandidate(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("cpDeleteCandidate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Regno", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}