using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.Web.Client;

public interface IClient
{
    Task<bool> AddPatientAsync(PatientDTO patientDto);
    Task<bool> AddConsultationAsync(ConsultationDTO consultationDTO);
    Task<bool> DeletePatientAsync(string cnp);
    Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    Task<PatientDTO> GetPatientByIdAsync(string cnp);
    Task<bool> UpdateInsuranceInformationAsync(string cnp, InsuranceInformationDTO insuranceInformationDTO);
    Task<bool> UpdateMedicalHistoryAsync(string cnp, MedicalHistoryDTO medicalHistoryDTO);
    Task<bool> UpdatePersonalInformationAsync(string cnp, PersonalInformationDTO personalInformationDTO);
}