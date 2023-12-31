﻿using Medana.API.Entities;

namespace Medana.API.Repositories;

public interface IPatientRepository
{
    bool AddPatient(Patient patient);
    IEnumerable<Patient> GetAllPatients();
    Patient GetPatientById(int id);
}