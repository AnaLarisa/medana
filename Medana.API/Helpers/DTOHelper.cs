using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.API.Helpers;

public static class DTOHelper
{
    public static Patient PatientDTOToPatient(PatientDTO patientDTO)
    {
        var patient = new Patient
        {
            CNP = patientDTO.CNP,
            PersonalInformation = PersonalInformationDTOToPersonalInformation(patientDTO.PersonalInformation),
            MedicalHistory = MedicalHistoryDTOToMedicalHistory(patientDTO.MedicalHistory, patientDTO.CNP),
            InsuranceInformation = InsuranceInformationDTOToInsuranceInformation(patientDTO.InsuranceInformation, patientDTO.CNP)
        };

        patient.PersonalInformation.Patient = patient;
        patient.MedicalHistory.Patient = patient;
        patient.InsuranceInformation.Patient = patient;
        return patient;
    }

    public static PersonalInformation PersonalInformationDTOToPersonalInformation(PersonalInformationDTO personalInformationDTO)
    {
        return new PersonalInformation
        {
            FirstName = personalInformationDTO.FirstName,
            LastName = personalInformationDTO.LastName,
            DateOfBirth = GetBirthDateFromCNP(personalInformationDTO.CNP),
            Sex = personalInformationDTO.Sex,
            Address = personalInformationDTO.Address,
            CNP = personalInformationDTO.CNP,
            PhoneNumber = personalInformationDTO.PhoneNumber,
            Occupation = personalInformationDTO.Occupation,
            Email = personalInformationDTO.Email
        };
    }

    private static int setAge(DateTime birthDate)
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - birthDate.Year;

        if (birthDate.Date > currentDate.AddYears(-age))
        {
            age--;
        }
        return age;
    }

    public static MedicalHistory MedicalHistoryDTOToMedicalHistory(MedicalHistoryDTO medicalHistoryDTO, string cnp)
    {
        return new MedicalHistory
        {
            CNP = cnp,
            MedicalConditions = medicalHistoryDTO.MedicalConditions,
            Consultations = ConsultationDTOListToConsultations(medicalHistoryDTO.Consultations, cnp),
            MedicationAndDosages = MedicationDTOListToMedications(medicalHistoryDTO.MedicationAndDosages),
            Allergies = medicalHistoryDTO.Allergies,
            SurgicalHistory = medicalHistoryDTO.SurgicalHistory,
            ImmunizationHistory = medicalHistoryDTO.ImmunizationHistory,
            FamilyMedicalHistory = medicalHistoryDTO.FamilyMedicalHistory
        };
    }

    public static Consultation ConsultationDTOToConsultation(ConsultationDTO consultationDTO, string cnp)
    {
        return new Consultation
        {
            PatientCNP = cnp,
            ConsultationDate = consultationDTO.ConsultationDate,
            Symptoms = consultationDTO.Symptoms,
            Diagnosis = consultationDTO.Diagnosis,
            TreatmentPlan = consultationDTO.TreatmentPlan,
            Notes = consultationDTO.Notes,
            Prescriptions = consultationDTO.Prescriptions,
            BloodPressure = consultationDTO.BloodPressure,
            HeartRate = consultationDTO.HeartRate,
            RespiratoryRate = consultationDTO.RespiratoryRate,
            Temperature = consultationDTO.Temperature
        };
    }

    public static IList<Consultation>? ConsultationDTOListToConsultations(IList<ConsultationDTO>? consultationDTOs, string cnp)
    {
        if (consultationDTOs == null) return null;
        return consultationDTOs.Select(dto => ConsultationDTOToConsultation(dto, cnp)).ToList();
    }

    public static IList<ConsultationDTO> ConsultationListToConsultationDTOs(IList<Consultation> consultations)
    {
        if (consultations == null) return null;
        return consultations.Select(c => MapToConsultationDTO(c)).ToList();
    }

    public static Medication? MedicationDTOToMedication(MedicationDTO medicationDTO)
    {
        if (medicationDTO == null) return null;
        return new Medication
        {
            MedicationName = medicationDTO.MedicationName,
            Dosage = medicationDTO.Dosage,
            Frequency = medicationDTO.Frequency
        };
    }

    public static IList<Medication>? MedicationDTOListToMedications(IList<MedicationDTO> medicationDTOs)
    {
        if (medicationDTOs == null) return null;
        return medicationDTOs.Select(MedicationDTOToMedication).ToList();
    }

    public static InsuranceInformation? InsuranceInformationDTOToInsuranceInformation(InsuranceInformationDTO insuranceInformationDTO, string cnp)
    {
        if(insuranceInformationDTO == null) return null;
        return new InsuranceInformation
        {
            CNP = cnp,
            InsuranceProvider = insuranceInformationDTO.InsuranceProvider,
            InsurancePolicyNumber = insuranceInformationDTO.InsurancePolicyNumber
        };
    }




    public static PersonalInformationDTO MapToPersonalInformationDTO(PersonalInformation personalInformation)
    {
        return new PersonalInformationDTO 
        {
            FirstName = personalInformation.FirstName,
            LastName = personalInformation.LastName,
            DateOfBirth = personalInformation.DateOfBirth,
            Age = setAge(personalInformation.DateOfBirth),
            Sex = personalInformation.Sex,
            Address = personalInformation.Address,
            PhoneNumber = personalInformation.PhoneNumber,
            Occupation = personalInformation.Occupation,
            Email = personalInformation.Email,
            CNP = personalInformation.CNP
        };
       
    }

    public static MedicalHistoryDTO MapToMedicalHistoryDTO(MedicalHistory medicalHistory)
    {
        return new MedicalHistoryDTO 
        { 
            MedicalConditions = medicalHistory.MedicalConditions,
            Consultations = medicalHistory.Consultations?.Select(MapToConsultationDTO)?.ToList(),
            MedicationAndDosages = medicalHistory.MedicationAndDosages?.Select(MapToMedicationDTO)?.ToList(),
            Allergies = medicalHistory.Allergies,
            SurgicalHistory = medicalHistory.SurgicalHistory,
            ImmunizationHistory = medicalHistory.ImmunizationHistory,
            FamilyMedicalHistory = medicalHistory.FamilyMedicalHistory
        };
    }

    public static InsuranceInformationDTO MapToInsuranceInformationDTO(InsuranceInformation insuranceInformation)
    {
        return new InsuranceInformationDTO
        {
            InsuranceProvider = insuranceInformation.InsuranceProvider,
            InsurancePolicyNumber = insuranceInformation.InsurancePolicyNumber
        };
    }

    public static ConsultationDTO MapToConsultationDTO(Consultation consultation)
    {
        return new ConsultationDTO
        {
            ConsultationDate = consultation.ConsultationDate,
            Symptoms = consultation.Symptoms,
            Diagnosis = consultation.Diagnosis,
            TreatmentPlan = consultation.TreatmentPlan,
            Notes = consultation.Notes,
            Prescriptions = consultation.Prescriptions,
            BloodPressure = consultation.BloodPressure,
            HeartRate = consultation.HeartRate,
            RespiratoryRate = consultation.RespiratoryRate,
            Temperature = consultation.Temperature,
            PatientCNP = consultation.PatientCNP
        };
    }
    
    public static MedicationDTO MapToMedicationDTO (Medication medication)
    {
        return new MedicationDTO 
        { 
            MedicationName = medication.MedicationName,  
            Dosage = medication.Dosage,
            Frequency = medication.Frequency
        };
    }

    private static DateTime GetBirthDateFromCNP(string cnp)
    {
        string datePart = cnp.Substring(1, 6);
        string yearPart = datePart.Substring(0, 2);
        string monthPart = datePart.Substring(2, 2);
        string dayPart = datePart.Substring(4, 2);

        int year = int.Parse(yearPart);
        int month = int.Parse(monthPart);
        int day = int.Parse(dayPart);

        int century = (year < 22) ? 2000 : 1900;

        DateTime birthDate = new DateTime(century + year, month, day);
        return birthDate;
    }

    public static Consultation ConsultationDTOToConsultation(ConsultationDTO consultationDTO)
    {
        return new Consultation
        {
            ConsultationDate = consultationDTO.ConsultationDate,
            Symptoms = consultationDTO.Symptoms,
            Diagnosis = consultationDTO.Diagnosis,
            TreatmentPlan = consultationDTO.TreatmentPlan,
            Notes = consultationDTO.Notes,
            Prescriptions = consultationDTO.Prescriptions,
            BloodPressure = consultationDTO.BloodPressure,
            HeartRate = consultationDTO.HeartRate,
            RespiratoryRate = consultationDTO.RespiratoryRate,
            Temperature = consultationDTO.Temperature,
            PatientCNP = consultationDTO.PatientCNP
        };
    }
}
