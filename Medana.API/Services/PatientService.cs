using Medana.API.Entities;
using Medana.API.Entities.DTOs;
using Medana.API.Helpers;
using Medana.API.Repositories;

namespace Medana.API.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }


    public IEnumerable<PatientDTO> GetAllPatientsWithDetails()
    {
        var patients = _patientRepository.GetAllPatients();

        var patientsWithDetails = patients.Select(patient => new PatientDTO
        {
            PersonalInformation = DTOHelper.MapToPersonalInformationDTO(patient.PersonalInformation),
            MedicalHistory = DTOHelper.MapToMedicalHistoryDTO(patient.MedicalHistory),
            InsuranceInformation = DTOHelper.MapToInsuranceInformationDTO(patient.InsuranceInformation)
        });

        return patientsWithDetails;
    }

    public Patient GetPatientById(int id)
    {
        return _patientRepository.GetPatientById(id);
    }

    public bool AddPatient(Patient patient)
    {
        if (!_patientRepository.IsCNPUnique(patient.PersonalInformation.CNP))
        {
            throw new Exception("The CNP provided already exists in the database.");
        }

        return _patientRepository.AddPatient(patient);
    }

    public bool DeletePatient(int patientId) 
    {
        return _patientRepository.DeletePatient(patientId);
    }


}
