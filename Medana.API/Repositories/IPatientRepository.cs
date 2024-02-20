using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.API.Repositories;

public interface IPatientRepository
{
    bool AddPatient(Patient patient);
    IList<Patient> GetAllPatients();
    Patient GetPatientById(string cnp);
    public bool IsCNPDuplicate(string CNP);
    public Task<bool> DeletePatientAsync(string cnp);
    public bool UpdatePersonalInformation(PersonalInformationDTO personalInformationDTO);
    public bool UpdateMedicalHistory(MedicalHistoryDTO medicalHistoryDTO, string cnp);
    public bool UpdateInsuranceInformation(InsuranceInformationDTO insuranceInformationDTO, string cnp);
    bool AddConsultation(Consultation consultation);
}