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

namespace BookNyAftale
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage()
        {
            InitializeComponent();
            Controller controller = Controller.GetInstance();
            int openingTime = 9;
            List<AppointmentView> appoViews = new List<AppointmentView>();
            ListViewItem listItemTime;
            ListViewItem listItemMonday;
            ListViewItem listItemTuesday;
            ListViewItem listItemWednesday;
            ListViewItem listItemThursday;
            ListViewItem listItemFriday;
            ListViewItem listItemSaturday;
            ListViewItem listItemSunday;
            for (int i = 0; i < 12; i++)
            {
                 listItemTime = new ListViewItem();
                 listItemMonday = new ListViewItem();
                 listItemTuesday = new ListViewItem();
                 listItemWednesday = new ListViewItem();
                 listItemThursday = new ListViewItem();
                 listItemFriday = new ListViewItem();
                 listItemSaturday = new ListViewItem();
                 listItemSunday = new ListViewItem();

                listItemTime.Content = openingTime + ":00";
                listItemMonday.Content = " ";
                listItemTuesday.Content = " ";
                listItemWednesday.Content = " ";
                listItemThursday.Content = " ";
                listItemFriday.Content = " ";
                listItemSaturday.Content = " ";
                listItemSunday.Content = " ";
                if (openingTime%2 == 0)
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
                openingTime++;
            }
            
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today, DateTime.Today.AddDays(6));
                btnToday.Content = DateTime.Today.ToString("dd/MM") + " - "+DateTime.Today.AddDays(6).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(1).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(2).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(3).ToString("dd/MM");
                ((GridView)lvFriday .View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(4).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(5).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(6).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(5));
                btnToday.Content = DateTime.Today.AddDays(-1).ToString("dd/MM") + " - " + DateTime.Today.AddDays(5).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(1).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(2).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(3).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(4).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(5).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today.AddDays(-2), DateTime.Today.AddDays(4));
                btnToday.Content = DateTime.Today.AddDays(-2).ToString("dd/MM") + " - " + DateTime.Today.AddDays(4).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-2).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(0).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(1).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(2).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(3).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(4).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today.AddDays(-3), DateTime.Today.AddDays(3));
                btnToday.Content = DateTime.Today.AddDays(-3).ToString("dd/MM") + " - " + DateTime.Today.AddDays(3).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-3).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(-2).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(0).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(1).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(2).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(3).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today.AddDays(-4), DateTime.Today.AddDays(2));
                btnToday.Content = DateTime.Today.AddDays(-4).ToString("dd/MM") + " - " + DateTime.Today.AddDays(2).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-4).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(-3).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(-2).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(0).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(2).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(3).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today.AddDays(-5), DateTime.Today.AddDays(1));
                btnToday.Content = DateTime.Today.AddDays(-5).ToString("dd/MM") + " - " + DateTime.Today.AddDays(1).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-5).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(-4).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(-3).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(-2).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(0).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(1).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                appoViews = controller.GetAllAppointmentsByPracId(3, DateTime.Today.AddDays(-6), DateTime.Today);
                btnToday.Content = DateTime.Today.AddDays(0).ToString("dd/MM") + " - " + DateTime.Today.AddDays(0).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-6).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(-5).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(-4).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(-3).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(-2).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(0).ToString("dd/MM");
            }
            
            //ComboBoxItem calendarPicked = (ComboBoxItem)cmbbCalendar.SelectedItem;

            foreach (AppointmentView item in appoViews)
            {
                switch (item.dateAndTime.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        listItemSunday = new ListViewItem();
                        listItemSunday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemSunday.Background = Brushes.Magenta;
                        lvSunday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvSunday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemSunday);
                        break;
                    case DayOfWeek.Monday:
                        listItemMonday = new ListViewItem();
                        listItemMonday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemMonday.Background = Brushes.Magenta;
                        lvMonday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvMonday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemMonday);
                        break;
                    case DayOfWeek.Tuesday:
                        listItemTuesday = new ListViewItem();
                        listItemTuesday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemTuesday.Background = Brushes.Magenta;
                        lvTuesday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvTuesday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemTuesday);
                        break;
                    case DayOfWeek.Wednesday:
                        listItemWednesday = new ListViewItem();
                        listItemWednesday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemWednesday.Background = Brushes.Magenta;
                        lvWednesday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvWednesday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemWednesday);
                        break;
                    case DayOfWeek.Thursday:
                        listItemThursday = new ListViewItem();
                        listItemThursday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemThursday.Background = Brushes.Magenta;
                        lvThursday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvThursday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemThursday);
                        break;
                    case DayOfWeek.Friday:
                        listItemFriday = new ListViewItem();
                        listItemFriday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemFriday.Background = Brushes.Magenta;
                        lvFriday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvFriday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemFriday);
                        break;
                    case DayOfWeek.Saturday:

                        listItemSaturday= new ListViewItem();
                        listItemSaturday.Content = item.dateAndTime.ToString("dd/MM HH:mm");
                        listItemSaturday.Background = Brushes.Magenta;
                        lvSaturday.Items.RemoveAt(item.dateAndTime.Hour - openingTime);
                        lvSaturday.Items.Insert(item.dateAndTime.Hour - openingTime, listItemSaturday);
                        break;
                    default:
                        break;
                }                               
            }                
        }
    }       
}
