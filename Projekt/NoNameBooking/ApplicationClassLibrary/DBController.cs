using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    class DBController : IPersistable
    {
        private static string _connectionString = "Server=EALSQL1.eal.local; Database = B_DB19_2018; User Id = B_STUDENT19; Password = B_OPENDB19; MultipleActiveResultSets=True;";

        public void AddAppointment(int id, DateTime dateAndTime, string  roomName, string departmentName, int practitionerId, double price, int treatmentTypeId, string note)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertAppointment", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DateAndTime", dateAndTime);
                    command.Parameters.AddWithValue("@RoomName", roomName);
                    command.Parameters.AddWithValue("@DepartmentName", departmentName);
                    command.Parameters.AddWithValue("@PractitionerId", practitionerId);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@TreatmentTypeId", treatmentTypeId);
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
        public void AddClient(int id, Boolean medicalRefferal, int journalId, int SSN, int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertClient", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@MedicalRefferal", medicalRefferal);
                    command.Parameters.AddWithValue("@JournalId", journalId);
                    command.Parameters.AddWithValue("@SocialSecurityNumber", SSN);
                    command.Parameters.AddWithValue("@UserId", userId);
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

        public void AddDepartment(int id, string address, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertDepartment", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Name", name);
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

        public void AddInvoice(int id, DateTime dueDate, int appointmentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertInvoice", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DueDate", dueDate);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);
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

        public void AddUser(int id, string name, string address, string phoneNumber, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);
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

        public void AddJournalEntry(int id, int journalId, string text)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertJournal_Entry", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Journal_EntryId", id);
                    command.Parameters.AddWithValue("@JournalId", journalId);
                    command.Parameters.AddWithValue("@Text", text);
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

        public void AddPractitioner(int id, int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertPractitioner", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@UserId", userId);
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

        public void AddRoom(int id, int departmentId, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertRoom", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@DepartmentI", departmentId);
                    command.Parameters.AddWithValue("@Name", name);
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

        public void AddTreatementType(int id, string name, DateTime duration, double price)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spInsertTreatmentType", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TreatmentTypeId", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@StandardPrice", price);
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

        public List<Client> GetClients()
        {
            List<Appointment> listOfAppointments = new List<Appointment>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spGetClients", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfAppointments.Add(new Appointment(reader.GetValue(1), reader.GetValue(1), reader.GetValue(2)));
                    }
                }

                return listOfAppointments;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }

        public List<Appointment> GetAppointments()
        {
            List<Appointment> listOfAppointments = new List<Appointment>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spGetAppointments", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfAppointments.Add(new Appointment(reader.GetValue(1), reader.GetValue(1), reader.GetValue(2)));
                    }
                }

                return listOfAppointments;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }
    

        public List<Department> GetDepartments()
        {
            List<Appointment> listOfAppointments = new List<Appointment>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spGetDeparments", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfAppointments.Add(new Appointment(reader.GetValue(1), reader.GetValue(1), reader.GetValue(2)));
                    }
                }

                return listOfAppointments;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }

        public List<Practitioner> GetPractitioners()
        {
            List<Appointment> listOfAppointments = new List<Appointment>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spGetPractitioners", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfAppointments.Add(new Appointment(reader.GetValue(1), reader.GetValue(1), reader.GetValue(2)));
                    }
                }

                return listOfAppointments;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }
    }
}
