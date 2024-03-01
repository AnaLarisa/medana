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
        if (patients.Count < 1)
        { 
            throw new Exception("No patients found in the database.");
        }

        var patientsWithDetails = patients.Select(patient => new PatientDTO
        {
            CNP = patient.PersonalInformation.CNP,
            PersonalInformation = DTOHelper.MapToPersonalInformationDTO(patient.PersonalInformation),
            MedicalHistory = DTOHelper.MapToMedicalHistoryDTO(patient.MedicalHistory),
            InsuranceInformation = DTOHelper.MapToInsuranceInformationDTO(patient.InsuranceInformation)
        });

        return patientsWithDetails;
    }

    public PatientDTO GetPatientById(string cnp)
    {
        var patient = _patientRepository.GetPatientById(cnp);
        var patientWithDetails = new PatientDTO
        {
            CNP = patient.PersonalInformation.CNP,
            PersonalInformation = DTOHelper.MapToPersonalInformationDTO(patient.PersonalInformation),
            MedicalHistory = DTOHelper.MapToMedicalHistoryDTO(patient.MedicalHistory),
            InsuranceInformation = DTOHelper.MapToInsuranceInformationDTO(patient.InsuranceInformation)
        };

        return patientWithDetails;
    }

    public bool AddPatient(Patient patient)
    {
        if (_patientRepository.IsCNPDuplicate(patient.PersonalInformation.CNP))
        {
            throw new Exception("The CNP provided already exists in the database.");
        }

        return _patientRepository.AddPatient(patient);
    }

    public async Task<bool> DeletePatientAsync(string cnp) 
    {
        var result = await _patientRepository.DeletePatientAsync(cnp);
        return result;
    }

    public bool UpdatePersonalInformation(PersonalInformationDTO personalInformationDTO)
    {
        var result = _patientRepository.UpdatePersonalInformation(personalInformationDTO);
        return result;
    }

    public bool UpdateMedicalHistory(MedicalHistoryDTO medicalHistoryDTO, string cnp)
    {
        var result = _patientRepository.UpdateMedicalHistory(medicalHistoryDTO, cnp);
        return result;
    }

    public bool UpdateInsuranceInformation(InsuranceInformationDTO insuranceInformationDTO, string cnp)
    {
        var result = _patientRepository.UpdateInsuranceInformation(insuranceInformationDTO, cnp);
        return result;
    }

    public bool AddConsultation(Consultation consultation)
    {
        var result = _patientRepository.AddConsultation(consultation);
        return result;
    }

    public IEnumerable<ConsultationDTO> GetAllConsultations()
    {
        var consultations = _patientRepository.GetAllConsultations();
        if (consultations.Count < 1)
        {
            throw new Exception("No consultations found in the database.");
        }

        var consultationsDTO = DTOHelper.ConsultationListToConsultationDTOs(consultations);

        return consultationsDTO;        
    }
}
