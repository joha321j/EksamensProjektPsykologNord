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
using ApplicationClassLibrary;


namespace BookNyAftale
{
    /// <summary>

    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        private DepartmentViewModel _departmentViewModel;
        private readonly ClientRepoViewModel _addClientRepoViewModel;
        private DepartmentRepoViewModel _departmentRepoViewModel;

        public CreateAppointment()
        {
            InitializeComponent();

            _addClientRepoViewModel = new ClientRepoViewModel();
            _addClientRepoViewModel.ClientAddedEvent += ClientRepoClientCreationHandler;
            //_departmentRepoViewModel = new DepartmentRepoViewModel();

            // UpdateDepartmentComboBox();
            //UpdateAppointmentTimeComboBox();
        }

        private void UpdatePractitionerComboBox()
        {
            throw new NotImplementedException();
        }

        //private void UpdateDepartmentComboBox()
        //{
        //    List<DepartmentViewModel> departmentViewModels = _departmentRepoViewModel.GetDepartmentViews();
        //    cmbbDepartment.Items.Clear();
        //    foreach (DepartmentViewModel departmentViewModel in departmentViewModels)
        //    {
        //        cmbbDepartment.Items.Add(departmentViewModel.Name);
        //    }
        //}

        private void UpdateAppointmentTimeComboBox()
        {

            double openTime = 9;
            for (int i = 0; i < 12; i++)
            {
                cmbbAppointmentTime.Items.Add(openTime + ":00");
                openTime++;
            }

        }

        private void UpdateClientComboBox()
        {
            List<ClientView> clients = _addClientRepoViewModel.GetClientViews();
            cmbbClient.Items.Clear();
            foreach (ClientView clientView in clients)
            {
                cmbbClient.Items.Add(clientView);
            }
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient(_addClientRepoViewModel);
            addClient.Show();
        }

        private void ClientRepoClientCreationHandler(object sender, EventArgs args)
        {
            UpdateClientComboBox();
        }

        private void BtnCreateAppointment_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CmbbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string departmentName = cmbbDepartment.SelectionBoxItem.ToString();
            _departmentViewModel = _departmentRepoViewModel.FindDepartmentViewModel(departmentName);
            UpdatePractitionerComboBox();
        }
    }
}
