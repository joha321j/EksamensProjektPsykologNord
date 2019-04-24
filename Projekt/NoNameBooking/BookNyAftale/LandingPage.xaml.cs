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
            ObservableCollection<Days> dataTest = new ObservableCollection<Days>();
            
            dataTest.Add(new Days { Day = "Mandag" });
            dataTest.Add(new Days { Day = "Tirsdag" });
            dataTest.Add(new Days { Day = "Onsdag" });
            dataTest.Add(new Days { Day = "Torsdag" });
            dataTest.Add(new Days { Day = "Fredag" });
            dataTest.Add(new Days { Day = "Lørdag" });
            dataTest.Add(new Days { Day = "Søndag" });
            
            grCalendar.ItemsSource = dataTest;
            
        }
    }
    public class Days
    {
        public string Day { get; set; }
    }
}
