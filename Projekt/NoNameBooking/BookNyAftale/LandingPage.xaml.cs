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

                lvTime.Items.Add(openingTime+":00");
                lvTime.Items.Add(openingTime + ":30");
                openingTime++;
            }
            
            
        }
    }   
}
