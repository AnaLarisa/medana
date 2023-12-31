﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities;

public class MedicalHistory
{
    [Key]
    [ForeignKey("Patient")]
    public int Id { get; set; }

    public List<string> MedicalConditions { get; set; }

    public virtual List<Consultation> Consultations { get; set; }

    public virtual List<Medication> MedicationAndDosages { get; set; }

    public List<string> Allergies { get; set; }

    public List<string> SurgicalHistory { get; set; }

    public List<string> ImmunizationHistory { get; set; }

    public string FamilyMedicalHistory { get; set; }
}

