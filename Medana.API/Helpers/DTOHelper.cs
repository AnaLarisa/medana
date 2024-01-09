using System.Collections.Generic;
using Medana.API.Entities;
using Medana.API.Entities.DTOs;

namespace Medana.API.Helpers;

public static class DTOHelper
{
    public static Patient PatientDTOToPatient(PatientDTO patientDTO)
    {
        return new Patient
        {
            PersonalInformation = PersonalInformationDTOToPersonalInformation(patientDTO.PersonalInformation),
            MedicalHistory = MedicalHistoryDTOToMedicalHistory(patientDTO.MedicalHistory),
            InsuranceInformation = InsuranceInformationDTOToInsuranceInformation(patientDTO.InsuranceInformation)
        };
    }

    public static PersonalInformation PersonalInformationDTOToPersonalInformation(PersonalInformationDTO personalInformationDTO)
    {
        return new PersonalInformation
        {
            FirstName = personalInformationDTO.FirstName,
            LastName = personalInformationDTO.LastName,
            DateOfBirth = personalInformationDTO.DateOfBirth,
            Sex = personalInformationDTO.Sex,
            Address = personalInformationDTO.Address,
            CNP = personalInformationDTO.CNP,
            PhoneNumber = personalInformationDTO.PhoneNumber,
            Occupation = personalInformationDTO.Occupation,
            Email = personalInformationDTO.Email
        };
    }

    public static MedicalHistory MedicalHistoryDTOToMedicalHistory(MedicalHistoryDTO medicalHistoryDTO)
    {
        return new MedicalHistory
        {
            MedicalConditions = medicalHistoryDTO.MedicalConditions,
            Consultations = ConsultationDTOListToConsultations(medicalHistoryDTO.Consultations),
            MedicationAndDosages = MedicationDTOListToMedications(medicalHistoryDTO.MedicationAndDosages),
            Allergies = medicalHistoryDTO.Allergies,
            SurgicalHistory = medicalHistoryDTO.SurgicalHistory,
            ImmunizationHistory = medicalHistoryDTO.ImmunizationHistory,
            FamilyMedicalHistory = medicalHistoryDTO.FamilyMedicalHistory
        };
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
            Temperature = consultationDTO.Temperature
        };
    }

    public static List<Consultation> ConsultationDTOListToConsultations(List<ConsultationDTO> consultationDTOs)
    {
        return consultationDTOs?.ConvertAll(ConsultationDTOToConsultation);
    }

    public static Medication MedicationDTOToMedication(MedicationDTO medicationDTO)
    {
        return new Medication
        {
            MedicationName = medicationDTO.MedicationName,
            Dosage = medicationDTO.Dosage,
            Frequency = medicationDTO.Frequency
        };
    }

    public static List<Medication> MedicationDTOListToMedications(List<MedicationDTO> medicationDTOs)
    {
        return medicationDTOs?.ConvertAll(MedicationDTOToMedication);
    }

    public static InsuranceInformation InsuranceInformationDTOToInsuranceInformation(InsuranceInformationDTO insuranceInformationDTO)
    {
        return new InsuranceInformation
        {
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
            Sex = personalInformation.Sex,
            Age = personalInformation.Age,
            Address = personalInformation.Address,
            CNP = personalInformation.CNP,
            PhoneNumber = personalInformation.PhoneNumber,
            Occupation = personalInformation.Occupation,
            Email = personalInformation.Email
        };
       
    }

    public static MedicalHistoryDTO MapToMedicalHistoryDTO(MedicalHistory medicalHistory)
    {
        return new MedicalHistoryDTO 
        { 
            MedicalConditions = medicalHistory.MedicalConditions,   
            Consultations = medicalHistory.Consultations.ConvertAll(MapToConsultationDTO),
            MedicationAndDosages = medicalHistory.MedicationAndDosages.ConvertAll(MapToMedicationDTO),
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
            Temperature = consultation.Temperature
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

}
