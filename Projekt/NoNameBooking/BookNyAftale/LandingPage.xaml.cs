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
            int openingTime = 9;
            
            for (int i = 0; i < 12; i++)
            {
                ListViewItem listItemTime = new ListViewItem();
                ListViewItem listItemMonday = new ListViewItem();
                ListViewItem listItemTuesday = new ListViewItem();
                ListViewItem listItemWednesday = new ListViewItem();
                ListViewItem listItemThursday = new ListViewItem();
                ListViewItem listItemFriday = new ListViewItem();
                ListViewItem listItemSaturday = new ListViewItem();
                ListViewItem listItemSunday = new ListViewItem();


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
        }
    }   
}
