using Medana.API.Entities;
using Medana.API.Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Medana.API.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PatientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IList<Patient> GetAllPatients()
    {
        var patients = _dbContext.Patients
            .Include(p => p.PersonalInformation)
            .Include(p => p.MedicalHistory)
            .Include(p => p.InsuranceInformation)
            .Include(p => p.MedicalHistory.Consultations)
            .Include(p => p.MedicalHistory.MedicationAndDosages)
            .ToList();
        return patients;
    }


    public Patient GetPatientById(string cnp)
    {
        var patient = _dbContext.Patients
            .Include(p => p.PersonalInformation)
            .Include(p => p.MedicalHistory)
                .ThenInclude(mh => mh.Consultations)
            .Include(p => p.MedicalHistory)
                .ThenInclude(mh => mh.MedicationAndDosages)
            .Include(p => p.InsuranceInformation)
            .FirstOrDefault(p => p.CNP == cnp);

        if (patient == null)
        {
            throw new Exception("No patient found with the provided CNP.");
        }
         return patient;
    }


    public bool AddPatient(Patient patient)
    {
        try 
        {
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the patient: {ex.Message}");
            throw;
        }
    }

    public bool IsCNPDuplicate(string CNP)
    {
        return _dbContext.Patients.Any(p => p.PersonalInformation.CNP == CNP);
    }

    public async Task<bool> DeletePatientAsync(string cnp)
    {
        var patient = await _dbContext.Patients
            .Include(p => p.MedicalHistory)
                .ThenInclude(mh => mh.Consultations)
            .Include(p => p.MedicalHistory)
                .ThenInclude(mh => mh.MedicationAndDosages)
            .FirstOrDefaultAsync(p => p.CNP == cnp);

        if (patient == null)
        {
            return false;
        }

        if (patient.MedicalHistory != null && patient.MedicalHistory.Consultations != null)
        {
            _dbContext.Consultations.RemoveRange(patient.MedicalHistory.Consultations);
        }

        if (patient.MedicalHistory != null && patient.MedicalHistory.MedicationAndDosages != null)
        {
            _dbContext.Medications.RemoveRange(patient.MedicalHistory.MedicationAndDosages);
        }

        _dbContext.Patients.Remove(patient);

        try
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while deleting the patient: {ex.Message}");
            throw;
        }
    }

    public bool UpdatePersonalInformation(PersonalInformationDTO personalInformationDTO)
    {
        var personalInformation = _dbContext.PersonalInformation.FirstOrDefault(p => p.CNP == personalInformationDTO.CNP);

        if (personalInformation == null)
        {
            return false;
        }

        personalInformation.Occupation = personalInformationDTO.Occupation;
        personalInformation.PhoneNumber = personalInformationDTO.PhoneNumber;
        personalInformation.Email = personalInformationDTO.Email;
        personalInformation.Address = personalInformationDTO.Address;
        personalInformation.FirstName = personalInformationDTO.FirstName;
        personalInformation.LastName = personalInformationDTO.LastName;
        personalInformation.Sex = personalInformationDTO.Sex;

        _dbContext.SaveChanges();
        return true;
    }

    public bool UpdateMedicalHistory(MedicalHistoryDTO medicalHistoryDTO, string cnp)
    {
        var medicalHistory = _dbContext.MedicalHistory.FirstOrDefault(mh => mh.CNP == cnp);

        if (medicalHistory == null)
        {
            return false;
        }

        medicalHistory.Allergies = medicalHistoryDTO.Allergies;
        medicalHistory.FamilyMedicalHistory = medicalHistoryDTO.FamilyMedicalHistory;
        medicalHistory.ImmunizationHistory = medicalHistoryDTO.ImmunizationHistory;
        medicalHistory.MedicalConditions = medicalHistoryDTO.MedicalConditions;
        medicalHistory.SurgicalHistory = medicalHistoryDTO.SurgicalHistory;
        medicalHistory.MedicationAndDosages = medicalHistoryDTO.MedicationAndDosages.Select(m => new Medication
        {
            MedicationName = m.MedicationName,
            Dosage = m.Dosage,
            Frequency = m.Frequency
        }).ToList();

        medicalHistory.Consultations = medicalHistoryDTO.Consultations.Select(c => new Consultation
        {
            ConsultationDate = c.ConsultationDate,
            Symptoms = c.Symptoms,
            Diagnosis = c.Diagnosis,
            TreatmentPlan = c.TreatmentPlan,
            Notes = c.Notes,
            Prescriptions = c.Prescriptions,
            BloodPressure = c.BloodPressure,
            HeartRate = c.HeartRate,
            RespiratoryRate = c.RespiratoryRate,
            Temperature = c.Temperature,
            PatientCNP = cnp
        }).ToList();

        _dbContext.SaveChanges();
        return true;
    }


    public bool UpdateInsuranceInformation(InsuranceInformationDTO insuranceInformationDTO, string cnp)
    {
        var insuranceInformation = _dbContext.InsuranceInformation.FirstOrDefault(ii => ii.CNP == cnp);

        if (insuranceInformation == null)
        {
            return false;
        }

        insuranceInformation.InsurancePolicyNumber = insuranceInformationDTO.InsurancePolicyNumber;
        insuranceInformation.InsuranceProvider = insuranceInformationDTO.InsuranceProvider;

        _dbContext.SaveChanges();
        return true;
    }

    public bool AddConsultation(Consultation consultation)
    {
        try 
        {
            var cnp = consultation.PatientCNP;
            var medicalHistory = _dbContext.MedicalHistory.FirstOrDefault(mh => mh.CNP == cnp);

            if (medicalHistory != null)
            {
                _dbContext.Consultations.Add(consultation);
                if (medicalHistory.Consultations == null)
                {
                    medicalHistory.Consultations = new List<Consultation> { consultation };
                }
                else
                {
                    medicalHistory.Consultations.Add(consultation);
                }

                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception($"Patient {cnp} does not exist in the database.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the consultation: {ex.Message}");
            throw;
        }
        
    }

    public IList<Consultation> GetAllConsultations()
    {
        var consultations = _dbContext.Consultations.ToList();
        return consultations;
    }

}
