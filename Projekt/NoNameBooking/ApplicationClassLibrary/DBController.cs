using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationClassLibrary
{
    class DBController
    {
        private static string _connectionString = "Server=EALSQL1.eal.local; Database = B_DB19_2018; User Id = B_STUDENT19; Password = B_OPENDB19; MultipleActiveResultSets=True;";

        public void AddAppointment(string connectionString, DateTime dateAndTime, string note)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertAppointment", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DateAndTime", dateAndTime);
                    command.Parameters.AddWithValue("@")
                    command.Parameters.AddWithValue("@Note", note);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                }
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }
    }
}
