using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment9
{
    class DBManager
    {
        private string connStr = Utility.GetConnectionString();

        public DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, fname, lname, address, facepiece1, facepiece2, facepiece3, facepiece4 FROM Person";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }

            return dt;
        }

        public void AddPerson(string firstName, string lastName, string address, string facepiece1, string facepiece2, string facepiece3, string facepiece4)
        {
            string query = "INSERT INTO Person(fname, lname, address, facepiece1, facepiece2, facepiece3, facepiece4) VALUES(@fn, @ln, @address, @facepiece1, @facepiece2, @facepiece3, @facepiece4)";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fn", firstName);
                    cmd.Parameters.AddWithValue("@ln", lastName);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@facepiece1", facepiece1);
                    cmd.Parameters.AddWithValue("@facepiece2", facepiece2);
                    cmd.Parameters.AddWithValue("@facepiece3", facepiece3);
                    cmd.Parameters.AddWithValue("@facepiece4", facepiece4);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding person: " + ex.Message);
                    }
                }
            }
        }

        public void DeletePerson(int id)
        {
            string query = "DELETE FROM Person WHERE Id = @id";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting person: " + ex.Message);
                    }
                }
            }
        }

        public void UpdatePerson(int id, string firstName, string lastName, string address, string facepiece1, string facepiece2, string facepiece3, string facepiece4)
        {
            string query = "UPDATE Person SET fname = @fn, lname = @ln, address = @address, facepiece1 = @facepiece1, facepiece2 = @facepiece2, facepiece3 = @facepiece3, facepiece4 = @facepiece4 WHERE Id = @id";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fn", firstName);
                    cmd.Parameters.AddWithValue("@ln", lastName);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@facepiece1", facepiece1);
                    cmd.Parameters.AddWithValue("@facepiece2", facepiece2);
                    cmd.Parameters.AddWithValue("@facepiece3", facepiece3);
                    cmd.Parameters.AddWithValue("@facepiece4", facepiece4);
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating person: " + ex.Message);
                    }
                }
            }
        }

        public DataTable SearchPerson(string lastName)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, fname, lname, address, facepiece1, facepiece2, facepiece3, facepiece4 FROM Person WHERE lname LIKE @lastName";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lastName", "%" + lastName + "%");

                    try
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error searching database: " + ex.Message);
                    }
                }
            }

            return dt;
        }
    }
}
