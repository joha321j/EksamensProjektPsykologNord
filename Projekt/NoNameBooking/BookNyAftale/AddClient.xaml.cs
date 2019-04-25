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
using System.Windows.Shapes;
using ViewModelClassLibrary;

namespace BookNyAftale
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        private readonly ClientRepoViewModel _addClientRepoViewModel;
        public AddClient(ClientRepoViewModel clientRepoViewModel)
        {
            _addClientRepoViewModel = clientRepoViewModel;
            InitializeComponent();
        }

        private void BtnSaveClient_Click(object sender, RoutedEventArgs e)
        {
           
            if (EnsureValidInput())
            {
                CreateClient();

                MessageBox.Show("Klienten er oprettet!", "Succes!", MessageBoxButton.OK, MessageBoxImage.None);
                Close();
            }
            
        }

        private bool EnsureValidInput()
        {
            string invalidInput = string.Empty;
            bool validInput = false;


            if (ContainsLetters(txtClientSSN.Text))
            {
                invalidInput += "CPR-nummeret må kun indeholde tal!\n";
            }

            if (ContainsLetters(txtClientPhone.Text))
            {
                invalidInput += "Telefonnummeret må kun indeholde tal!\n";
            }


            if (ContainsLetters(txtClientZip.Text))
            {
                invalidInput += "Postnummeret må kun indeholde tal!\n";
            }

            if (string.Equals(invalidInput, string.Empty))
            {
                validInput = true;
            }
            else
            {
                MessageBox.Show(invalidInput, "Ugyldigt information!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return validInput;
        }

        private void CreateClient()
        {
            string clientAddress = txtClientAddress.Text + ";" + txtClientZip.Text + ";" + txtClientCity.Text;

            _addClientRepoViewModel.CreateClient(txtClientName.Text, txtClientEmail.Text, txtClientPhone.Text,
                clientAddress, txtClientSSN.Text, txtClientNote.Text);
        }

        private bool ContainsLetters(string text)
        {
            return !int.TryParse(text, out _);
        }
    }
}
