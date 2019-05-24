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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ApplicationClassLibrary;

namespace BookNyAftale
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        internal readonly Controller _controller;

        public CreateClient()
        {
            InitializeComponent();

            _controller = Controller.GetInstance();
        }

        private void BtnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateNewClient();
                Close();
            }
            catch (InvalidInputException exception)
            {
                MessageBox.Show(exception.Message, "Fejl!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateNewClient()
        {
            string clientAddress = txtClientAddress.Text + ";" + txtClientZip.Text + ";" + txtClientCity.Text;

            _controller.CreateClient(txtClientName.Text, txtClientEmail.Text, txtClientPhone.Text,
                clientAddress, txtClientSSN.Text, txtClientNote.Text);
        }

        private bool ContainsLetters(string text)
        {
            return !int.TryParse(text, out _);
        }
    }
}
