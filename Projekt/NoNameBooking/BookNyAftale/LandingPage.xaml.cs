using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using ApplicationClassLibrary;
using System.Xml;

namespace BookNyAftale
{
    public partial class LandingPage : Window
    {
        private readonly List<ListView> _listViews = new List<ListView>();
        private List<PractitionerView> _practitionerViews;
        private readonly Controller _controller;
        private int _openingTime;
        private int _openingHours;
        private readonly DateTime _mondayDateCurrentWeek;
        private DateTime _mondayDate;
        private readonly int _forwardAmount;
        private int _currentUserId;

        public LandingPage()
        {
            InitializeComponent();
            _controller = Controller.GetInstance();
            _controller.NewAppointmentCreatedEventHandler += UpdateCalendar;

            PopulatePractitionerComboBox();

            _openingTime = _practitionerViews[0].Start.Hour;
            _openingHours = _practitionerViews[0].DayLength.Hours;
            _currentUserId = _practitionerViews[0].Id;

            cmbbPractitioner.SelectedItem = _practitionerViews[0].Name;

            _forwardAmount = 7;

            _listViews.Add(lvMonday);
            _listViews.Add(lvTuesday);
            _listViews.Add(lvWednesday);
            _listViews.Add(lvThursday);
            _listViews.Add(lvFriday);
            _listViews.Add(lvSaturday);
            _listViews.Add(lvSunday);
            _listViews.Add(lvTime);

            ResetCalendarView();

            _mondayDateCurrentWeek = _controller.GetMondayDate(DateTime.Today);
            _mondayDate = _mondayDateCurrentWeek;

            UpdateCalendarDatesWeekPage(_mondayDateCurrentWeek);

            UpdateAppointmentView(_mondayDateCurrentWeek, _mondayDateCurrentWeek.AddDays(_forwardAmount),
                _currentUserId);
        }

        private void PopulatePractitionerComboBox()
        {
            _practitionerViews = _controller.GetPractitioners();

            cmbbPractitioner.Items.Clear();

            foreach (PractitionerView practitionerName in _practitionerViews)
            {
                cmbbPractitioner.Items.Add(practitionerName.Name);
            }
        }

        private void UpdateCalendar(object sender, EventArgs e)
        {
            ResetCalendarView();
            UpdateCalendarDatesWeekPage(_mondayDate);
            UpdateAppointmentView(_mondayDate, _mondayDate.AddDays(_forwardAmount), _currentUserId);
        }

        private void ResetCalendarView()
        {
            int timeCounter = _openingTime;

            _listViews.ForEach(listView => listView.Items.Clear());

            for (int i = 0; i < _openingHours; i++)
            {
                ListViewItem listItemTime = new ListViewItem();
                ListViewItem listItemMonday = new ListViewItem();
                ListViewItem listItemTuesday = new ListViewItem();
                ListViewItem listItemWednesday = new ListViewItem();
                ListViewItem listItemThursday = new ListViewItem();
                ListViewItem listItemFriday = new ListViewItem();
                ListViewItem listItemSaturday = new ListViewItem();
                ListViewItem listItemSunday = new ListViewItem();

                listItemTime.Content = timeCounter + ":00";
                listItemMonday.Content = " ";
                listItemTuesday.Content = " ";
                listItemWednesday.Content = " ";
                listItemThursday.Content = " ";
                listItemFriday.Content = " ";
                listItemSaturday.Content = " ";
                listItemSunday.Content = " ";
                if (timeCounter % 2 == 0)
                {
                    listItemTime.Background = Brushes.LightGray;
                    listItemMonday.Background = Brushes.LightGray;
                    listItemTuesday.Background = Brushes.LightGray;
                    listItemWednesday.Background = Brushes.LightGray;
                    listItemThursday.Background = Brushes.LightGray;
                    listItemFriday.Background = Brushes.LightGray;
                    listItemSaturday.Background = Brushes.LightGray;
                    listItemSunday.Background = Brushes.LightGray;
                }
                else
                {
                    listItemTime.Background = Brushes.White;
                    listItemMonday.Background = Brushes.White;
                    listItemTuesday.Background = Brushes.White;
                    listItemWednesday.Background = Brushes.White;
                    listItemThursday.Background = Brushes.White;
                    listItemFriday.Background = Brushes.White;
                    listItemSaturday.Background = Brushes.White;
                    listItemSunday.Background = Brushes.White;
                }

                lvMonday.Items.Add(listItemMonday);
                lvTuesday.Items.Add(listItemTuesday);
                lvWednesday.Items.Add(listItemWednesday);
                lvThursday.Items.Add(listItemThursday);
                lvFriday.Items.Add(listItemFriday);
                lvSaturday.Items.Add(listItemSaturday);
                lvSunday.Items.Add(listItemSunday);
                lvTime.Items.Add(listItemTime);
                timeCounter++;
            }
        }

        public void UpdateAppointmentView(DateTime startDate, DateTime endDate, int userId)
        {

            List<AppointmentView> appoViews = _controller.GetAllAppointmentsByPracId(userId, startDate, endDate);
           
            foreach (AppointmentView item in appoViews)
            {
                ListView listView =
                    _listViews.Find(view => view.Name.Equals("lv" + item.DateAndTime.DayOfWeek.ToString()));

                for (int i = 0; i < item.TypeView.Duration.Hours; i++)
                {
                    
                    List<UserView> userViews =  _controller.GetClientsFromAppointmentView(item);
                    ListViewItem listViewItem = new ListViewItem()
                    {                        
                        Content = userViews[0].Name,
                        Background = Brushes.Magenta,
                        Tag = item.Id
                    };

                    listView.Items.RemoveAt(item.DateAndTime.Hour + i - _openingTime);
                    listView.Items.Insert(item.DateAndTime.Hour + i - _openingTime, listViewItem);
                }
                
            }
        }

        private void UpdateCalendarDatesWeekPage(DateTime startDate)
        {
            string dateFormat = "dd/MM";
            btnToday.Content = startDate.ToString(dateFormat) + " - " + startDate.AddDays(6).ToString(dateFormat);
            ((GridView) lvMonday.View).Columns[0].Header = "Manday: " + startDate.ToString(dateFormat);
            ((GridView) lvTuesday.View).Columns[0].Header = "Tirsday: " + startDate.AddDays(1).ToString(dateFormat);
            ((GridView) lvWednesday.View).Columns[0].Header = "Onsdag: " + startDate.AddDays(2).ToString(dateFormat);
            ((GridView) lvThursday.View).Columns[0].Header = "Torsdag: " + startDate.AddDays(3).ToString(dateFormat);
            ((GridView) lvFriday.View).Columns[0].Header = "Fredag: " + startDate.AddDays(4).ToString(dateFormat);
            ((GridView) lvSaturday.View).Columns[0].Header = "Lørdag: " + startDate.AddDays(5).ToString(dateFormat);
            ((GridView) lvSunday.View).Columns[0].Header = "Søndag: " + startDate.AddDays(6).ToString(dateFormat);

        }

        private void BtnForward_OnClick(object sender, RoutedEventArgs e)
        {
            _mondayDate = _mondayDate.AddDays(_forwardAmount);

            ResetCalendarView();

            UpdateCalendarDatesWeekPage(_mondayDate);

            UpdateAppointmentView(_mondayDate, _mondayDate.AddDays(_forwardAmount), _currentUserId);
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            _mondayDate = _mondayDate.AddDays(_forwardAmount * -1);

            ResetCalendarView();

            UpdateCalendarDatesWeekPage(_mondayDate);

            UpdateAppointmentView(_mondayDate, _mondayDate.AddDays(_forwardAmount), _currentUserId);
        }

        private void BtnToday_OnClick(object sender, RoutedEventArgs e)
        {
            _mondayDate = _mondayDateCurrentWeek;

            ResetCalendarView();

            UpdateCalendarDatesWeekPage(_mondayDate);

            UpdateAppointmentView(_mondayDate, _mondayDate.AddDays(_forwardAmount), _currentUserId);
        }

        private void CmbbPractitioner_DropDownClosedEvent(object sender, EventArgs e)
        {
            PractitionerView selectedPractitionerView =
                _practitionerViews.Find(practitioner => practitioner.Name.Equals(cmbbPractitioner.SelectionBoxItem.ToString()));

            _openingTime = selectedPractitionerView.Start.Hour;
            _openingHours = selectedPractitionerView.DayLength.Hours;
            _currentUserId = selectedPractitionerView.Id;

            ResetCalendarView();

            UpdateCalendarDatesWeekPage(_mondayDate);

            UpdateAppointmentView(_mondayDate, _mondayDate.AddDays(_forwardAmount), _currentUserId);

        }

        private void BtnCreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment createAppointment = new CreateAppointment();
            
            createAppointment.Show();
        }

        private void Item_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListView lvView = ((ListView)e.Source);
            ListViewItem item = sender as ListViewItem;
            
            switch (lvView.Name)
            {
                case "lvMonday":
                     item = lvMonday.SelectedItems[0] as ListViewItem;
                    break;
                case "lvTuesday":
                    item = lvTuesday.SelectedItems[0] as ListViewItem;
                    break;
                case "lvWednesday":
                    item = lvWednesday.SelectedItems[0] as ListViewItem;
                    break;
                case "lvThursday":
                    item = lvThursday.SelectedItems[0] as ListViewItem;
                    break;
                case "lvFriday":
                    item = lvFriday.SelectedItems[0] as ListViewItem;
                    break;
                case "lvSaturday":
                    item = lvSaturday.SelectedItems[0] as ListViewItem;
                    break;
                case "lvSunday":
                    item = lvSunday.SelectedItems[0] as ListViewItem;
                    break;
                default:
                    break;
            }
            
            if (item.Tag != null)
            {
                int appoId = ((int)item.Tag);
                string appoDate = item.Content.ToString();
                EditAppointment edit = new EditAppointment(appoId);
                edit.Show();

            }
        }
    }       
}
