using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using ApplicationClassLibrary;
using PersistencyClassLibrary;

namespace BookNyAftale
{
    /// <summary>
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        private readonly Controller _controller;

        private bool _departmentChosen;
        private bool _practitionerChosen;
        private bool _appointmentTypeChosen;
        private bool _dateChosen;
        private bool _timeChosen;
        private bool _clientChosen;

        public CreateAppointment()
        {
            InitializeComponent();
            _controller = Controller.GetInstance();

            _controller.NewClientCreatedEventHandler += ClientRepoClientCreationHandler;

            UpdateClientComboBox(null);
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
                date = (DateTime) dpAppointmentDate.SelectedDate;
            }

            try
            {
                _controller.CreateAppointment(date, cmbbAppointmentTime.SelectionBoxItem.ToString(),
                    cmbbDepartment.SelectionBoxItem.ToString(), cmbbClient.SelectionBoxItem.ToString(),
                    cmbbPractitioner.SelectionBoxItem.ToString(), cmbbAppointmentType.SelectionBoxItem.ToString(), txtNotes.Text);
            }
            catch (Exception exception) when (exception is InvalidInputException || exception is SqlException || exception is SqlAppointmentAlreadyExistsException)
            {
                if (exception is SqlAppointmentAlreadyExistsException)
                {
                    MessageBox.Show("Kunne ikke oprette en aftale dette tidspunkt.\nPrøv igen med et andet tidspunkt", "Aftale eksistere allerede",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (exception is InvalidInputException)
                {
                    MessageBox.Show(exception.Message, "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(
                        "Kunne ikke oprette forbindlse til databasen.\nPrøv at checke din internet forbindelse",
                        "Fejl!!!", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    Close();
                }
            }


        }

        private void CmbbDepartment_DropDownClosed(object sender, EventArgs e)
        {

            if ((string) cmbbDepartment.SelectionBoxItem != string.Empty)
            {
                UpdatePractitionerComboBox();

                _departmentChosen = true;

                cmbbPractitioner.IsEnabled = _departmentChosen;
            }
            
        }

        private void CmbbPractitioner_DropDownClosed(object sender, EventArgs e)
        {
            if ((string) cmbbPractitioner.SelectionBoxItem != string.Empty)
            {
                UpdateTreatmentComboBox();
                UpdateAppointmentDates();

                _practitionerChosen = true;
                cmbbAppointmentType.IsEnabled = _practitionerChosen;
            }
            
        }

        private void UpdateAppointmentDates()
        {
            if (dpAppointmentDate.DisplayDateStart != null && dpAppointmentDate.DisplayDateEnd != null)
            {
                List<DateTime> blockedDates = _controller.GetBusyDates(cmbbPractitioner.SelectionBoxItem.ToString(),
                    cmbbDepartment.SelectionBoxItem.ToString(), (DateTime) dpAppointmentDate.DisplayDateStart,
                    (DateTime) dpAppointmentDate.DisplayDateEnd);

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
            if (dpAppointmentDate.SelectedDate != null)
            {
                UpdateAppointmentTimeComboBox();
                _dateChosen = true;
                cmbbAppointmentTime.IsEnabled = _dateChosen;
            }
            
        }

        private void CmbbAppointmentType_OnDropDownClosed(object sender, EventArgs e)
        {
            if ((string) cmbbAppointmentType.SelectionBoxItem != string.Empty)
            {
                _appointmentTypeChosen = true;
                dpAppointmentDate.IsEnabled = _appointmentTypeChosen;
            }
            
        }



        private void CmbbAppointmentTime_OnDropDownClosed(object sender, EventArgs e)
        {
            if ((string) cmbbAppointmentTime.SelectionBoxItem != string.Empty)
            {
                _timeChosen = true;

                if (_practitionerChosen && _appointmentTypeChosen && _dateChosen && _departmentChosen && _timeChosen && _clientChosen)
                {
                    btnCreateAppointment.IsEnabled = true;
                }
            }
            


        }

        private void CmbbClient_OnDropDownClosed(object sender, EventArgs e)
        {
            if ((string) cmbbClient.SelectionBoxItem != string.Empty)
            {
                _clientChosen = true;
            }
        }
    }
}
