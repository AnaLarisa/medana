using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.Web.Client;

public interface IClient
{
    Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    Task<Patient> GetPatientByIdAsync(int id);
    Task<bool> AddPatientAsync(PatientDTO patientDto);
}