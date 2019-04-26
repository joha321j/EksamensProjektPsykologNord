using System;
using System.Collections.Generic;
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

namespace BookNyAftale
{
    /// <summary>

    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();
            double openTime = 9;
            for (int i = 0; i < 12; i++)
            {
                cmbbAppointmentTime.Items.Add(openTime + ":00");
                openTime++;
            }
            
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();

        }
    }
}
