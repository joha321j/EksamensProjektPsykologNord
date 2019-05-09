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
        private readonly Controller _controller;
        public LandingPage()
        {
            InitializeComponent();
            _controller = Controller.GetInstance();
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
                btnToday.Content = DateTime.Today.AddDays(-5).ToString("dd/MM") + " - " + DateTime.Today.AddDays(1).ToString("dd/MM");
                ((GridView)lvMonday.View).Columns[0].Header = "Mandag: " + DateTime.Today.AddDays(-5).ToString("dd/MM");
                ((GridView)lvTuesday.View).Columns[0].Header = "Tirsdag: " + DateTime.Today.AddDays(-4).ToString("dd/MM");
                ((GridView)lvWednesday.View).Columns[0].Header = "Onsdag: " + DateTime.Today.AddDays(-3).ToString("dd/MM");
                ((GridView)lvThursday.View).Columns[0].Header = "Torsdag: " + DateTime.Today.AddDays(-2).ToString("dd/MM");
                ((GridView)lvFriday.View).Columns[0].Header = "Fredag: " + DateTime.Today.AddDays(-1).ToString("dd/MM");
                ((GridView)lvSaturday.View).Columns[0].Header = "Lørdag: " + DateTime.Today.AddDays(0).ToString("dd/MM");
                ((GridView)lvSunday.View).Columns[0].Header = "Søndag: " + DateTime.Today.AddDays(1).ToString("dd/MM");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
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
            appoViews = _controller.GetAllAppointmentsByPracId(3);
            foreach (AppointmentView item in appoViews)
            {
                switch (item.dateAndTime.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(0,listItemSunday);
                                break;
                            case 10:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(1, listItemSunday);
                                break;
                            case 11:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(2, listItemSunday);
                                break;
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(3, listItemSunday);
                                break;
                            case 13:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(4, listItemSunday);
                                break;
                            case 14:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(5, listItemSunday);
                                break;
                            case 15:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(6, listItemSunday);
                                break;
                            case 16:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(7, listItemSunday);
                                break;
                            case 17:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(8, listItemSunday);
                                break;
                            case 18:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(8, listItemSunday);
                                break;
                            case 19:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(9, listItemSunday);
                                break;
                            case 20:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(10, listItemSunday);
                                break;

                            default:
                                break;
                        }

                        break;
                    case DayOfWeek.Monday:
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(0, listItemMonday);
                                break;
                            case 10:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(1, listItemMonday);
                                break;
                            case 11:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(2, listItemMonday);
                                break;
                            case 12:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(3, listItemMonday);
                                break;
                            case 13:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(4, listItemMonday);
                                break;
                            case 14:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(5, listItemMonday);
                                break;
                            case 15:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(6, listItemMonday);
                                break;
                            case 16:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(7, listItemMonday);
                                break;
                            case 17:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(8, listItemMonday);
                                break;
                            case 18:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(9, listItemMonday);
                                break;
                            case 19:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(10, listItemMonday);
                                break;
                            case 20:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.Insert(11, listItemMonday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(4, listItemSunday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(5, listItemSunday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Thursday:
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(5, listItemSunday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Friday:
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(2, listItemSunday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Saturday:
                        listItemSunday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.Insert(1, listItemSunday);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                listItemMonday = new ListViewItem();                
                listItemMonday.Content = "aftale";
                listItemMonday.Background = Brushes.Magenta;
                lvMonday.Items.Add(listItemMonday);
                
            }
                _controller.GetAllAppointmentsByPracId(3);
        }
    }       
}
