using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.API.Services;

public interface IPatientService
{
    IEnumerable<PatientDTO> GetAllPatientsWithDetails();
    PatientDTO GetPatientById(string cnp);

    bool AddPatient(Patient patient);

    Task<bool> DeletePatientAsync(string cnp);

    public bool UpdatePersonalInformation(PersonalInformationDTO personalInformationDTO);
    public bool UpdateMedicalHistory(MedicalHistoryDTO medicalHistoryDTO, string cnp);
    public bool UpdateInsuranceInformation(InsuranceInformationDTO insuranceInformationDTO, string cnp);
    bool AddConsultation(Consultation consultation);
    IEnumerable<ConsultationDTO> GetAllConsultations();
}