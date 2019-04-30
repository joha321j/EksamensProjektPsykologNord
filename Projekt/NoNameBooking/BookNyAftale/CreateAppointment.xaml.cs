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
        private DepartmentRepoViewModel _departmentRepoViewModel;
        private Controller _controller;

        public CreateAppointment()
        {
            InitializeComponent();
            _controller = Controller.GetInstance();

            _controller.NewClientCreatedEventHandler += ClientRepoClientCreationHandler;

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
            List<string> clients = _controller.GetClientNames();

            cmbbClient.Items.Clear();

            foreach (string clientName in clients)
            {
                cmbbClient.Items.Add(clientName);
            }
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
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
