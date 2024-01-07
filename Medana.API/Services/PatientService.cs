using Medana.API.Entities;
using Medana.API.Repositories;

namespace Medana.API.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }


    public IEnumerable<Patient> GetAllPatients()
    {
        return _patientRepository.GetAllPatients();
    }

    public Patient GetPatientById(int id)
    {
        return _patientRepository.GetPatientById(id);
    }

    public bool AddPatient(Patient patient)
    {
        return _patientRepository.AddPatient(patient);
    }
}
