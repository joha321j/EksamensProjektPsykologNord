﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class AppointmentView
    {  
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public List<UserView> Users { get; set; }
        public AppointmentTypeView TypeView { get; set; }
        public RoomView RoomView { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public AppointmentView(int id, DateTime dateAndTime, AppointmentTypeView appointmentType)
        {
            Id = id;
            DateAndTime = dateAndTime;
            TypeView = appointmentType;
        }

        public AppointmentView(int id, DateTime dateAndTime,List<UserView> users, AppointmentTypeView appointmentType, RoomView room,string note, double price)
        {
            Id = id;
            this.DateAndTime = dateAndTime;
            Users = users;
            TypeView = appointmentType;
            RoomView = room;
            Note = note;
            Price = price;
        }
    }
}
