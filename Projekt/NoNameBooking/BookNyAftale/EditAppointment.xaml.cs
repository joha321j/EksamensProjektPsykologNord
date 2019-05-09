﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationClassLibrary;
using DateTime = System.DateTime;

namespace BookNyAftale
{
    /// <summary>
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        private readonly Controller _controller;
        public EditAppointment()
        {
            InitializeComponent();
            _controller = Controller.GetInstance();

            UpdateDepartmentComboBox();
        }
        private void UpdatePractitionerComboBox()
        {
            List<string> practitionerNames =
                _controller.GetPractitionerNamesForDepartment(cmbbDepartment.SelectionBoxItem.ToString());

            cmbbPractitioner.Items.Clear();

            foreach (string practitionerName in practitionerNames)
            {
                cmbbPractitioner.Items.Add(practitionerName);
            }
        }

        private void UpdateDepartmentComboBox()
        {
            List<string> departmentViewModels = _controller.GetDepartmentNames();
            cmbbDepartment.Items.Clear();
            foreach (string departmentName in departmentViewModels)
            {
                cmbbDepartment.Items.Add(departmentName);
            }
        }

        private void UpdateAppointmentTimeComboBox()
        {
            if (dpAppointmentDate.SelectedDate != null)
            {
                List<string> availableTimes = _controller.GetAvailableTimes(dpAppointmentDate.SelectedDate.Value,
                    cmbbPractitioner.SelectionBoxItem.ToString(), cmbbDepartment.SelectionBoxItem.ToString());

                cmbbAppointmentTime.ItemsSource = availableTimes;
            }

            cmbbAppointmentTime.SelectedIndex = 0;
        }

        private void UpdateClientComboBox(object sender)
        {
            List<string> clients = _controller.GetClientNames();

            cmbbClient.ItemsSource = clients;
            cmbbClient.SelectedIndex = 0;


            cmbbClient.SelectedItem = sender;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();
        }

        private void ClientRepoClientCreationHandler(object sender, EventArgs args)
        {
            UpdateClientComboBox(sender);
        }

        private void BtnCreateAppointment_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime date = default(DateTime);
            if (dpAppointmentDate.SelectedDate != null)
            {
                date = (DateTime)dpAppointmentDate.SelectedDate;
            }

            try
            {
                _controller.CreateAppointment(date, cmbbAppointmentTime.SelectionBoxItem.ToString(),
                    cmbbDepartment.SelectionBoxItem.ToString(), cmbbClient.SelectionBoxItem.ToString(),
                    cmbbPractitioner.SelectionBoxItem.ToString(), cmbbAppointmentType.SelectionBoxItem.ToString(), txtNotes.Text);
            }
            catch (InvalidInputException exception)
            {
                MessageBox.Show(exception.Message, "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePractitionerComboBox();
        }

        private void CmbbPractitioner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTreatmentComboBox();
            UpdateAppointmentDates();
        }

        private void UpdateAppointmentDates()
        {
            if (dpAppointmentDate.DisplayDateStart != null && dpAppointmentDate.DisplayDateEnd != null)
            {
                List<DateTime> blockedDates = _controller.GetBusyDates(cmbbPractitioner.SelectionBoxItem.ToString(),
                    cmbbDepartment.SelectionBoxItem.ToString(), (DateTime)dpAppointmentDate.DisplayDateStart,
                    (DateTime)dpAppointmentDate.DisplayDateEnd);

                dpAppointmentDate.BlackoutDates.Clear();

                foreach (DateTime blockedDate in blockedDates)
                {
                    if (!dpAppointmentDate.BlackoutDates.Contains(blockedDate))
                    {
                        dpAppointmentDate.BlackoutDates.Add(new CalendarDateRange(blockedDate));
                    }
                }
            }
        }

        private void UpdateTreatmentComboBox()
        {
            List<string> treatments = _controller.GetTreatments(cmbbPractitioner.SelectionBoxItem.ToString());

            cmbbAppointmentType.ItemsSource = treatments;
            cmbbAppointmentType.SelectedIndex = 0;
        }

        private void DpAppointmentDate_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAppointmentTimeComboBox();
        }
    }
}