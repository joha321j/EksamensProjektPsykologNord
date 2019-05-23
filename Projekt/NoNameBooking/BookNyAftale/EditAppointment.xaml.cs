using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public EditAppointment(int appointmentId)
        {
            InitializeComponent();
            _controller = Controller.GetInstance();
            UpdateDepartmentComboBox();
            AppointmentView appoView = GetAppointmentById(appointmentId);
            UpdateEditWpf(appoView);
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
                    cmbbPractitioner.SelectionBoxItem.ToString(), cmbbAppointmentType.SelectionBoxItem.ToString(), txtNotes.Text, (TimeSpan)cmbbNotificationTime.SelectionBoxItem, (bool)cbEmail.IsChecked, (bool)cbSMS.IsChecked);
            }
            catch (InvalidInputException exception)
            {
                MessageBox.Show(exception.Message, "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbbPractitioner.SelectedValue.ToString() == "")
            {
                UpdatePractitionerComboBox();
            }
            
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
            List<string> treatments = _controller.GetTreatments(cmbbPractitioner.SelectedItem.ToString());

            cmbbAppointmentType.ItemsSource = treatments;
            cmbbAppointmentType.SelectedIndex = 0;
        }

        private void DpAppointmentDate_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAppointmentTimeComboBox();
        }

        public AppointmentView GetAppointmentById(int appoId)
        {
            AppointmentView view = _controller.GetAppointmentById(appoId);
            return view;
        }

        public void UpdateEditWpf(AppointmentView appoView)
        {
            List<UserView> clients = _controller.GetClientsFromAppointmentView(appoView);
            List<UserView> practitioners = _controller.GetPractitionerFromAppointmentView(appoView);
            if (clients.Count >= 2)
            {
                cmbbClient.Items.Add(clients[0].Name+" & "+clients[1].Name);
                cmbbClient.SelectedIndex = cmbbClient.Items.IndexOf(clients[0].Name+" & "+clients[1].Name);
                cmbbClient.IsEnabled = false;
            }
            else if (clients.Count == 1)
            {
                cmbbClient.Items.Add(clients[0].Name);
                cmbbClient.SelectedIndex = cmbbClient.Items.IndexOf(clients[0].Name);
                cmbbClient.IsEnabled = false;
            }                                            
            foreach (UserView prac in practitioners)
            {
                cmbbPractitioner.Items.Add(prac.Name);
                cmbbPractitioner.SelectedIndex = cmbbPractitioner.Items.IndexOf(prac.Name);                
            }
            cmbbPractitioner.IsEnabled = false;

            DepartmentView departmentView = _controller.GetDepartmentViewFromRoomId(appoView.RoomView.Id);
            cmbbDepartment.SelectedIndex = cmbbDepartment.Items.IndexOf(departmentView.Name);
            cmbbDepartment.IsEnabled = false;
            dpAppointmentDate.SelectedDate = appoView.DateAndTime.Date;           
            cmbbAppointmentTime.SelectedIndex = cmbbAppointmentTime.Items.IndexOf(appoView.DateAndTime.ToString("H:mm"));
            txtNotes.Text = appoView.Note;
            cmbbAppointmentType.IsEnabled = false;
            lblHiddenId.Content = appoView.Id;
            if (appoView.EmailNotification == true)
            {
                cbEmail.IsChecked = true;
            }
            else if (appoView.EmailNotification == false)
            {
                cbEmail.IsChecked = false;
            }
            if (appoView.SMSNotification == true)
            {
                cbSMS.IsChecked = true;
            }
            else if(appoView.SMSNotification == false)
            {
                cbSMS.IsChecked = false;
            }
        }

        private void BtnRemoveAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.RemoveAppointment(int.Parse(lblHiddenId.Content.ToString()));
                Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Kunne ikke oprette forbindlse til databasen.\nPrøv at checke din internet forbindelse",
                    "Fejl!!!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
        }

        private void BtnSaveAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int appoId = int.Parse(lblHiddenId.Content.ToString());
                string selectedTime = cmbbAppointmentTime.SelectedValue.ToString();
                string selectedHour = selectedTime.Substring(0, 2);
                if (dpAppointmentDate.SelectedDate != null)
                {
                    DateTime dateTime = new DateTime(dpAppointmentDate.SelectedDate.Value.Year, dpAppointmentDate.SelectedDate.Value.Month, dpAppointmentDate.SelectedDate.Value.Day,
                        int.Parse(selectedHour), 00, 00);

                    AppointmentTypeView typeView = _controller.GetAppointmentTypeByName(cmbbAppointmentType.SelectedValue.ToString(), cmbbPractitioner.SelectedValue.ToString());
                    RoomView roomview = _controller.GetRoomByAppointmentId(appoId, cmbbDepartment.SelectedValue.ToString());
                    AppointmentView tempAppoView = _controller.GetAppointmentById(appoId);
                    AppointmentView appoView = new AppointmentView(appoId, dateTime, tempAppoView.Users, typeView, roomview, txtNotes.Text, tempAppoView.Price, tempAppoView.NotficationTime, tempAppoView.EmailNotification, tempAppoView.SMSNotification);
                    _controller.EditAppointment(appoView);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Kunne ikke oprette forbindlse til databasen.\nPrøv at checke din internet forbindelse",
                    "Fejl!!!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
