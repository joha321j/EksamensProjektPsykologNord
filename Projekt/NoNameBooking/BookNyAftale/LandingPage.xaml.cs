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
                                lvSunday.Items.RemoveAt(0);
                                lvSunday.Items.Insert(0,listItemSunday);
                                break;
                            case 10:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(1);
                                lvSunday.Items.Insert(1, listItemSunday);
                                
                                break;
                            case 11:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(2);
                                lvSunday.Items.Insert(2, listItemSunday);
                                break;
                            case 12:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(3);
                                lvSunday.Items.Insert(3, listItemSunday);
                                break;
                            case 13:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(4);
                                lvSunday.Items.Insert(4, listItemSunday);
                                break;
                            case 14:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(5);
                                lvSunday.Items.Insert(5, listItemSunday);
                                break;
                            case 15:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(6);
                                lvSunday.Items.Insert(6, listItemSunday);
                                break;
                            case 16:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(7);
                                lvSunday.Items.Insert(7, listItemSunday);
                                break;
                            case 17:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(8);
                                lvSunday.Items.Insert(8, listItemSunday);
                                break;
                            case 18:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(9);
                                lvSunday.Items.Insert(9, listItemSunday);
                                break;
                            case 19:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(10);
                                lvSunday.Items.Insert(10, listItemSunday);
                                break;
                            case 20:
                                listItemSunday = new ListViewItem();
                                listItemSunday.Content = item.dateAndTime;
                                listItemSunday.Background = Brushes.Magenta;
                                lvSunday.Items.RemoveAt(11);
                                lvSunday.Items.Insert(11, listItemSunday);
                                break;

                            default:
                                break;
                        }

                        break;
                    case DayOfWeek.Monday:
                        listItemMonday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(0);
                                lvMonday.Items.Insert(0, listItemMonday);
                                break;
                            case 10:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(1);
                                lvMonday.Items.Insert(1, listItemMonday);
                                break;
                            case 11:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(2);
                                lvMonday.Items.Insert(2, listItemMonday);
                                break;
                            case 12:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(3);
                                lvMonday.Items.Insert(3, listItemMonday);
                                break;
                            case 13:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(4);
                                lvMonday.Items.Insert(4, listItemMonday);
                                break;
                            case 14:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(5);
                                lvMonday.Items.Insert(5, listItemMonday);
                                break;
                            case 15:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(6);
                                lvMonday.Items.Insert(6, listItemMonday);
                                break;
                            case 16:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(7);
                                lvMonday.Items.Insert(7, listItemMonday);
                                break;
                            case 17:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(8);
                                lvMonday.Items.Insert(8, listItemMonday);
                                break;
                            case 18:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(9);
                                lvMonday.Items.Insert(9, listItemMonday);
                                break;
                            case 19:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(10);
                                lvMonday.Items.Insert(10, listItemMonday);
                                break;
                            case 20:
                                listItemMonday = new ListViewItem();
                                listItemMonday.Content = item.dateAndTime;
                                listItemMonday.Background = Brushes.Magenta;
                                lvMonday.Items.RemoveAt(11);
                                lvMonday.Items.Insert(11, listItemMonday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        listItemTuesday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(0, listItemTuesday);
                                break;
                            case 10:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(1, listItemTuesday);
                                break;
                            case 11:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(2, listItemTuesday);
                                break;
                            case 12:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(3, listItemTuesday);
                                break;
                            case 13:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(4, listItemTuesday);
                                break;
                            case 14:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(5, listItemTuesday);
                                break;
                            case 15:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(6, listItemTuesday);
                                break;
                            case 16:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(7, listItemTuesday);
                                break;
                            case 17:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(8, listItemTuesday);
                                break;
                            case 18:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(9, listItemTuesday);
                                break;
                            case 19:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(10, listItemTuesday);
                                break;
                            case 20:
                                listItemTuesday = new ListViewItem();
                                listItemTuesday.Content = item.dateAndTime;
                                listItemTuesday.Background = Brushes.Magenta;
                                lvTuesday.Items.RemoveAt(0);
                                lvTuesday.Items.Insert(11, listItemTuesday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        listItemWednesday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(0, listItemWednesday);
                                break;
                            case 10:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(1, listItemWednesday);
                                break;
                            case 11:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(2, listItemWednesday);
                                break;
                            case 12:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(3, listItemWednesday);
                                break;
                            case 13:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(4, listItemWednesday);
                                break;
                            case 14:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(5, listItemWednesday);
                                break;
                            case 15:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(6, listItemWednesday);
                                break;
                            case 16:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(7, listItemWednesday);
                                break;
                            case 17:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(8, listItemWednesday);
                                break;
                            case 18:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(9, listItemWednesday);
                                break;
                            case 19:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(10, listItemWednesday);
                                break;
                            case 20:
                                listItemWednesday = new ListViewItem();
                                listItemWednesday.Content = item.dateAndTime;
                                listItemWednesday.Background = Brushes.Magenta;
                                lvWednesday.Items.RemoveAt(0);
                                lvWednesday.Items.Insert(11, listItemWednesday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Thursday:
                        listItemThursday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(0, listItemThursday);
                                break;
                            case 10:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(1, listItemThursday);
                                break;
                            case 11:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(2, listItemThursday);
                                break;
                            case 12:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(3, listItemThursday);
                                break;
                            case 13:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(4, listItemThursday);
                                break;
                            case 14:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(5, listItemThursday);
                                break;
                            case 15:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(6, listItemThursday);
                                break;
                            case 16:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(7, listItemThursday);
                                break;
                            case 17:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(8, listItemThursday);
                                break;
                            case 18:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(9, listItemThursday);
                                break;
                            case 19:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(10, listItemThursday);
                                break;
                            case 20:
                                listItemThursday = new ListViewItem();
                                listItemThursday.Content = item.dateAndTime;
                                listItemThursday.Background = Brushes.Magenta;
                                lvThursday.Items.RemoveAt(0);
                                lvThursday.Items.Insert(11, listItemThursday);
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Friday:
                        listItemFriday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(0);
                                lvFriday.Items.Insert(0, listItemFriday);
                                lvFriday.Items.RemoveAt(0);
                                break;
                            case 10:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(1);
                                lvFriday.Items.Insert(1, listItemFriday);
                                break;
                            case 11:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(2);
                                lvFriday.Items.Insert(2, listItemFriday);
                                break;
                            case 12:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(3);
                                lvFriday.Items.Insert(3, listItemFriday);
                                break;
                            case 13:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(4);
                                lvFriday.Items.Insert(4, listItemFriday);                                
                                break;
                            case 14:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(5);
                                lvFriday.Items.Insert(5, listItemFriday);
                                break;
                            case 15:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(6);
                                lvFriday.Items.Insert(6, listItemFriday);
                                break;
                            case 16:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(7);
                                lvFriday.Items.Insert(7, listItemFriday);
                                break;
                            case 17:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(8);
                                lvFriday.Items.Insert(8, listItemFriday);
                                break;
                            case 18:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(9);
                                lvFriday.Items.Insert(9, listItemFriday);
                                break;
                            case 19:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(10);
                                lvFriday.Items.Insert(10, listItemFriday);                                
                                break;
                            case 20:
                                listItemFriday = new ListViewItem();
                                listItemFriday.Content = item.dateAndTime;
                                listItemFriday.Background = Brushes.Magenta;
                                lvFriday.Items.RemoveAt(11);
                                lvFriday.Items.Insert(11, listItemFriday);                                
                                break;
                            default:
                                break;
                        }
                        break;
                    case DayOfWeek.Saturday:
                        listItemSaturday = new ListViewItem();
                        switch (item.dateAndTime.Hour)
                        {
                            case 09:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(0);
                                lvSaturday.Items.Insert(0, listItemSaturday);
                                break;
                            case 10:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(1);
                                lvSaturday.Items.Insert(1, listItemSaturday);
                                break;
                            case 11:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(2);
                                lvSaturday.Items.Insert(2, listItemSaturday);
                                break;
                            case 12:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(3);
                                lvSaturday.Items.Insert(3, listItemSaturday);
                                break;
                            case 13:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(4);
                                lvSaturday.Items.Insert(4, listItemSaturday);
                                break;
                            case 14:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(5);
                                lvSaturday.Items.Insert(5, listItemSaturday);
                                break;
                            case 15:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(6);
                                lvSaturday.Items.Insert(6, listItemSaturday);
                                break;
                            case 16:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(7);
                                lvSaturday.Items.Insert(7, listItemSaturday);
                                break;
                            case 17:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(8);
                                lvSaturday.Items.Insert(8, listItemSaturday);
                                break;
                            case 18:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(9);
                                lvSaturday.Items.Insert(9, listItemSaturday);
                                break;
                            case 19:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(10);
                                lvSaturday.Items.Insert(10, listItemSaturday);
                                break;
                            case 20:
                                listItemSaturday = new ListViewItem();
                                listItemSaturday.Content = item.dateAndTime;
                                listItemSaturday.Background = Brushes.Magenta;
                                lvSaturday.Items.RemoveAt(11);
                                lvSaturday.Items.Insert(11, listItemSaturday);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }                               
            }                
        }
    }       
}
