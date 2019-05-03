using System.Collections.Generic;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public interface IPersistable
    {
        List<Client> GetClients();
        List<Appointment> GetAppointments();
        List<Department> GetDepartments();
        List<Practitioner> GetPractitioners();
    }
}