using Medana.API.Entities;

namespace Medana.API.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);

        bool AddPatient(Patient patient);
    }
}