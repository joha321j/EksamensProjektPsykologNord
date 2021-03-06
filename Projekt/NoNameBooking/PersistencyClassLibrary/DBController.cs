﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using ModelClassLibrary;

namespace PersistencyClassLibrary
{
    public class DbController : IPersistable
    {
        private static string _connectionString = "Server=EALSQL1.eal.local; Database = B_DB19_2018; User Id = B_STUDENT19; Password = B_OPENDB19; MultipleActiveResultSets=True;";

        /// <summary>
        /// Gets all the clients in the database and returns them as list of client objects.
        /// </summary>
        /// <returns></returns>
        public List<Client> GetClients()
        {
            List<Client> listOfClients = new List<Client>();

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

        /// <summary>
        /// Gets all appointments from the database and inserts users into these appointments from another table.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="departments"></param>
        /// <returns></returns>
        public List<Appointment> GetAppointments(List<User> users, List<Department> departments)
        {
            List<Appointment> listOfAppointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SPGetAllAppointments", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlCommand getUsersCommand = new SqlCommand("SPGetUsersFromAppointmentId", connection);
                getUsersCommand.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<User> tempUsers = new List<User>();
                        getUsersCommand.Parameters.AddWithValue("AppointmentId", reader.GetInt32(0));

                        using (SqlDataReader userReader = getUsersCommand.ExecuteReader())
                        {
                            while (userReader.Read())
                            {
                                User tempUser = users.Find(user => user.Id == userReader.GetInt32(0));
                                tempUsers.Add(tempUser);
                            }
                        }

                        //FindRoom is a private help method to find the associated rooms.
                        Room tempRoom = FindRoom(departments, reader.GetInt32(2)); 

                        AppointmentType tempAppointmentType = new AppointmentType(reader.GetString(5),
                            reader.GetDouble(7), reader.GetTimeSpan(6), reader.GetInt32(4));

                        int tempTimeInt = reader.GetInt32(10);

                        TimeSpan tempTimeSpan = TimeSpan.FromHours(tempTimeInt);

                        Appointment newAppointment = new Appointment(reader.GetDateTime(1), tempUsers,
                            tempAppointmentType, tempRoom, reader.GetString(8), tempTimeSpan, reader.GetBoolean(11),
                            reader.GetBoolean(12), reader.GetDouble(9), reader.GetInt32(0));

                        listOfAppointments.Add(newAppointment);

                        getUsersCommand.Parameters.Clear();
                    }
                }
            }

            return listOfAppointments;
        }

        /// <summary>
        /// Finds the room with the given id.
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all the departments from the database and returns them as a list of depart object.
        /// </summary>
        /// <param name="practitioners"></param>
        /// <returns> List of Department objects </returns>
        public List<Department> GetDepartments(List<Practitioner> practitioners)
        {
            List<Department> listOfDepartments = new List<Department>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand commandDepartment = new SqlCommand("SPGetAllDepartments", connection);
                commandDepartment.CommandType = CommandType.StoredProcedure;

                SqlCommand commandRoom = new SqlCommand("SPGetRoomsFromDepartment", connection);
                commandRoom.CommandType = CommandType.StoredProcedure;

                SqlCommand commandPractitioners = new SqlCommand("SPGetPractitionersFromDepartment", connection);
                commandPractitioners.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = commandDepartment.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department tempDepartment = new Department(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetInt32(0));

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

        /// <summary>
        /// Gets all the practitioners from database and returns them as a list of practitioner objects.
        /// </summary>
        /// <returns></returns>
        public List<Practitioner> GetPractitioners()
        {
            List<Practitioner> listOfPractitioners = new List<Practitioner>();


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

        /// <summary>
        /// Saves the appointment to the database.
        /// </summary>
        /// <param name="dateAndTime"></param>
        /// <param name="room"></param>
        /// <param name="users"></param>
        /// <param name="appointmentType"></param>
        /// <param name="note"></param>
        /// <param name="notificationTime"></param>
        /// <param name="emailNotification"></param>
        /// <param name="smsNotification"></param>
        public void SaveAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType,
            string note, TimeSpan notificationTime, bool emailNotification, bool smsNotification)
        {
            //Only here because of a missing feature where you could change the price according to discounts.
            double price = 0.0; 

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                
                int appointmentId;
                connection.Open();

                SqlCommand appointmentCommand = new SqlCommand("SPInsertAppointmentOutId", connection);
                appointmentCommand.CommandType = CommandType.StoredProcedure;

                appointmentCommand.Parameters.Add("@DateAndTime", SqlDbType.DateTime2).Value = dateAndTime;
                appointmentCommand.Parameters.AddWithValue("@RoomId", room.Id);
                appointmentCommand.Parameters.AddWithValue("@Price", price);
                appointmentCommand.Parameters.AddWithValue("@AppointmentTypeId", appointmentType.Id);
                appointmentCommand.Parameters.AddWithValue("@Note", note);
                appointmentCommand.Parameters.AddWithValue("@NotificationTime", (int)notificationTime.TotalHours);
                appointmentCommand.Parameters.AddWithValue("@EmailNotification", emailNotification);
                appointmentCommand.Parameters.AddWithValue("@SMSNotification", smsNotification);

                try
                {
                    appointmentId = (int) appointmentCommand.ExecuteScalar();
                }
                catch (NullReferenceException)
                {
                    throw new SqlAppointmentAlreadyExistsException();
                }

                SqlCommand userAppointmentCommand = new SqlCommand("SPInsertAppointmentForUser", connection);
                userAppointmentCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter userId = userAppointmentCommand.Parameters.Add("@UserId", SqlDbType.Int);
                SqlParameter appointmentIdtemp = userAppointmentCommand.Parameters.Add("@AppointmentId", SqlDbType.Int);

                appointmentIdtemp.Value = appointmentId;
                foreach (User user in users)
                {
                    userId.Value = user.Id;

                    userAppointmentCommand.ExecuteNonQuery();

                }

            }
        }

        public void RemoveAppointment(int appointmentId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SPDeleteAppointment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Saves parts of the client's information in user table in the database.
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="clientAddress"></param>
        /// <param name="clientPhoneNumber"></param>
        /// <param name="clientEmail"></param>
        /// <returns></returns>
        public int SaveUser(string clientName, string clientAddress, string clientPhoneNumber, string clientEmail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SPInsertUserOutId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", clientName);
                command.Parameters.AddWithValue("@Address", clientAddress);
                command.Parameters.AddWithValue("@PhoneNumber", clientPhoneNumber);
                command.Parameters.AddWithValue("@Email", clientEmail);

                int userId = (int)command.ExecuteScalar();

                return userId;
            }
        }

        /// <summary>
        /// Saves parts of the client's infomation in the client table in the database.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientNote"></param>
        /// <param name="clientSsn"></param>
        public void SaveClient(int clientId, string clientNote, string clientSsn)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SPInsertClient", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClientId", clientId);
                command.Parameters.AddWithValue("@MedicalRefferal", DBNull.Value); //We haven't made this yet, therefore it passes as null
                command.Parameters.AddWithValue("@JournalId", DBNull.Value);      // Ditto

                command.Parameters.AddWithValue("@Note", clientNote);
                command.Parameters.AddWithValue("@SocialSecurityNumber", clientSsn);

                command.ExecuteNonQuery();
            }
        }

        public void EditAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SPUpdateAppointment", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@AppointmentId", appointment.Id);
                command.Parameters.AddWithValue("@DateAndTime", appointment.DateAndTime);
                command.Parameters.AddWithValue("@Note", appointment.Note);
                command.Parameters.AddWithValue("@EmailNotification", appointment.EmailNotification);
                command.Parameters.AddWithValue("@SmsNotification", appointment.SmsNotification);
                command.Parameters.AddWithValue("@NotificationTime", appointment.NotificationTime.Hours);

                command.ExecuteNonQuery();
            }
        }
    }
}
