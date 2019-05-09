using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class DBController : IPersistable
    {
        private static string _connectionString = "Server=EALSQL1.eal.local; Database = B_DB19_2018; User Id = B_STUDENT19; Password = B_OPENDB19; MultipleActiveResultSets=True;";

     
        public void AddAppointment(int id, DateTime dateAndTime, string  roomName, string departmentName, List<int> userId, double price, int appointmentTypeId, string note)
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
                    command.Parameters.AddWithValue("@PractitionerId", userId);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@TreatmentTypeId", appointmentTypeId);
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

        public void AddAppointmentType(int id, string name, DateTime duration, double price)
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
            List<Client> listOfClients = new List<Client>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllClients", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                      Client tempClient = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
                            reader.GetString(5), reader.GetString(6), reader.GetInt32(0));
                      listOfClients.Add(tempClient);
                    }
                }

                return listOfClients;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }

        public List<Appointment> GetAppointments(List<User> users, List<Department> departments)
        {
            List<Appointment> listOfAppointments = new List<Appointment>();
            List<User> tempUsers = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllAppointments", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlCommand getUsersCommand = new SqlCommand("SPGetUsersFromAppointmentId", connection);
                    getUsersCommand.CommandType = CommandType.StoredProcedure;

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            getUsersCommand.Parameters.AddWithValue("AppointmentId", reader.GetInt32(0));

                            using (SqlDataReader userReader = getUsersCommand.ExecuteReader())
                            {
                                while (userReader.Read())
                                {
                                    User tempUser = users.Find(user => user.Id == userReader.GetInt32(0));
                                    tempUsers.Add(tempUser);
                                }
                            }

                            Room tempRoom = FindRoom(departments, reader.GetInt32(2));
                            AppointmentType tempAppointmentType = new AppointmentType(reader.GetString(5),
                                reader.GetDouble(7), reader.GetTimeSpan(6), reader.GetInt32(4));
                            Appointment newAppointment = new Appointment(reader.GetDateTime(1), tempUsers,
                                tempAppointmentType, tempRoom, reader.GetString(8), reader.GetDouble(9),
                                reader.GetInt32(0));

                            listOfAppointments.Add(newAppointment);

                            tempUsers.Clear();
                            getUsersCommand.Parameters.Clear();
                        }
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

        private Practitioner GetPractitionerHelp(List<User> users)
        {
            foreach (User user in users)
            {
                if (user.GetType() == typeof(Practitioner))
                {
                    return (Practitioner) user;
                }
            }
            throw new CultureNotFoundException();
        }

        private Room FindRoom(List<Department> departments, int roomId)
        {
            foreach (Department department in departments)
            {
                foreach (Room room in department.Rooms)
                {
                    if (room.Id == roomId)
                    {
                        return room;
                    }
                }
            }

            throw new CultureNotFoundException();
        }

        public List<Department> GetDepartments(List<Practitioner> practitioners)
        {
            List<Department> listOfDepartments = new List<Department>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand commandDepartment = new SqlCommand("SPGetAllDepartments", connection);
                    commandDepartment.CommandType = CommandType.StoredProcedure;

                    SqlCommand commandRoom = new SqlCommand("SPGetRoomsFromDepartment", connection);
                    commandRoom.CommandType = CommandType.StoredProcedure;

                    SqlCommand commandPractitioners = new SqlCommand("SPGetPractitionersFromDepartment", connection);
                    commandPractitioners.CommandType = CommandType.StoredProcedure;

                    using(SqlDataReader reader = commandDepartment.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department tempDepartment = new Department(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());

                            List<Room> tempRooms = new List<Room>();
                            commandRoom.Parameters.AddWithValue("DepartmentId", reader.GetInt32(0));
                            commandPractitioners.Parameters.AddWithValue("DepartmentId", reader.GetValue(0));

                            using (SqlDataReader readRoom = commandRoom.ExecuteReader())
                            {

                                while (readRoom.Read())
                                {
                                    Room tempRoom = new Room(readRoom.GetString(1), default(DateTime), 24, readRoom.GetInt32(0));
                                    tempRooms.Add(tempRoom);
                                }

                                

                            }

                            using (SqlDataReader readPractitioners = commandPractitioners.ExecuteReader())
                            {
                                

                                while (readPractitioners.Read())
                                {
                                    Practitioner tempPractitioner = practitioners.Find(x => x.Id == readPractitioners.GetInt32(0));
                                    tempDepartment.AddPractitioner(tempPractitioner);
                                }

                                tempDepartment.Rooms = tempRooms;

                                listOfDepartments.Add(tempDepartment);
                            }

                            commandRoom.Parameters.Clear();
                            commandPractitioners.Parameters.Clear();
                        }
                    }
                }

                return listOfDepartments;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }

        public List<Practitioner> GetPractitioners()
        {
            List<Practitioner> listOfPractitioners = new List<Practitioner>();


            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();


                    SqlCommand command = new SqlCommand("SPGetAllPractitioners", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlCommand appointmentCommand = new SqlCommand("SPGetAppointmentTypeByPractitionerId", connection);
                    appointmentCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<AppointmentType> appointmentTypes = new List<AppointmentType>();
                            appointmentCommand.Parameters.AddWithValue("PractitionerId", reader.GetInt32(0));
                            using (SqlDataReader appointmentReader = appointmentCommand.ExecuteReader())
                            {
                                while (appointmentReader.Read())
                                {
                                    AppointmentType tempAppointmentType =
                                        new AppointmentType(appointmentReader.GetString(0),
                                            appointmentReader.GetDouble(1), appointmentReader.GetTimeSpan(2),
                                            appointmentReader.GetInt32(3));
                                    appointmentTypes.Add(tempAppointmentType);
                                }
                            }
                           
                            Practitioner tempPractitioner = new Practitioner(reader.GetInt32(0), appointmentTypes, reader.GetDateTime(5), reader.GetTimeSpan(6),
                                reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            listOfPractitioners.Add(tempPractitioner);

                            appointmentCommand.Parameters.Clear();
                        }
                    }

                }

                return listOfPractitioners;
            }
            catch (Exception e)
            {
                /// TODO: Actually handle the exception!
                throw e;
            }
        }

        public void SaveAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note)
        {
            throw new NotImplementedException();
        }

        public void RemoveAppointment(string clientName, DateTime dateAndTime)
        {
            throw new NotImplementedException();
        }
    }
}
