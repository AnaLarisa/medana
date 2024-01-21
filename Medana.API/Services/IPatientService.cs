using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.API.Services;

public interface IPatientService
{
    IEnumerable<PatientDTO> GetAllPatientsWithDetails();
    Patient GetPatientById(int id);

    bool AddPatient(Patient patient);

    bool DeletePatient(int patientId);
}