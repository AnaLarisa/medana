using iTextSharp.text;
using iTextSharp.text.pdf;
using Medana.API.Entities.DTOs;

namespace Medana.Web.Services;

public class PatientReportService : IPatientReportService
{
    public byte[] GeneratePatientReport(PatientDTO patient)
    {
        Document document = new Document();
        MemoryStream memoryStream = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        document.Open();

        document.Add(new Paragraph("Patient Report"));
        document.Add(new Paragraph($"Name: {patient.PersonalInformation.FirstName} {patient.PersonalInformation.LastName}"));
        document.Add(new Paragraph($"Date of Birth: {patient.PersonalInformation.DateOfBirth.ToShortDateString()}"));
        document.Add(new Paragraph($"Sex: {patient.PersonalInformation.Sex}"));
        document.Add(new Paragraph($"Address: {patient.PersonalInformation.Address}"));

        if (patient.MedicalHistory.Consultations.Count > 0)
        {
            var lastConsultation = patient.MedicalHistory.Consultations.Last();
            document.Add(new Paragraph("Last Consultation:"));
            document.Add(new Paragraph($"Date: {lastConsultation.ConsultationDate.ToShortDateString()}"));
            document.Add(new Paragraph($"Symptoms: {lastConsultation.Symptoms}"));
            document.Add(new Paragraph($"Diagnosis: {lastConsultation.Diagnosis}"));
            document.Add(new Paragraph($"Treatment Plan: {lastConsultation.TreatmentPlan}"));
            document.Add(new Paragraph($"Notes: {lastConsultation.Notes}"));
            document.Add(new Paragraph($"Prescriptions: {lastConsultation.Prescriptions}"));
            document.Add(new Paragraph($"Blood Pressure: {lastConsultation.BloodPressure}"));
            document.Add(new Paragraph($"Heart Rate: {lastConsultation.HeartRate}"));
            document.Add(new Paragraph($"Respiratory Rate: {lastConsultation.RespiratoryRate}"));
            document.Add(new Paragraph($"Temperature: {lastConsultation.Temperature}"));
        }

        if (patient.MedicalHistory.MedicationAndDosages.Count > 0)
        {
            var lastMedication = patient.MedicalHistory.MedicationAndDosages.Last();
            document.Add(new Paragraph("Last Medication Given:"));
            document.Add(new Paragraph($"Name: {lastMedication.MedicationName}"));
            document.Add(new Paragraph($"Dosage: {lastMedication.Dosage}"));
            document.Add(new Paragraph($"Frequency: {lastMedication.Frequency}"));
        }

        if (patient.MedicalHistory.MedicalConditions != null && patient.MedicalHistory.MedicalConditions.Count > 0)
        {
            document.Add(new Paragraph("Medical Conditions:"));
            foreach (var condition in patient.MedicalHistory.MedicalConditions)
            {
                document.Add(new Paragraph($"- {condition}"));
            }
        }

        document.Add(new Paragraph("Insurance Information:"));
        document.Add(new Paragraph($"Provider: {patient.InsuranceInformation.InsuranceProvider}"));
        document.Add(new Paragraph($"Policy Number: {patient.InsuranceInformation.InsurancePolicyNumber}"));

        document.Close();

        return memoryStream.ToArray();
    }

}
