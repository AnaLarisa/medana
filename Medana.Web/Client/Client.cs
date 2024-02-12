using Medana.API.Entities;
using Medana.API.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Medana.Web.Client;

public class Client : IClient
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public Client(HttpClient client)
    {
        _client = client;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
    {
        var response = await _client.GetAsync("Patient/all");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<PatientDTO>>(json, _jsonSerializerOptions);
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }

    public async Task<PatientDTO> GetPatientByIdAsync(string cnp)
    {
        var response = await _client.GetAsync($"Patient/{cnp}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PatientDTO>(json, _jsonSerializerOptions);
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }

    public async Task<bool> AddPatientAsync(PatientDTO patientDto)
    {
        var content = new StringContent(JsonSerializer.Serialize(patientDto), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("Patient/add", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(result, _jsonSerializerOptions);
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }

    public async Task<bool> DeletePatientAsync(string cnp)
    {
        var response = await _client.DeleteAsync($"Patient/delete/{cnp}");

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }

    public async Task<bool> UpdatePersonalInformationAsync(string cnp, PersonalInformationDTO personalInformationDTO)
    {
        var content = new StringContent(JsonSerializer.Serialize(personalInformationDTO), Encoding.UTF8, "application/json");

        var response = await _client.PatchAsync($"Patient/edit/personalInformation/{cnp}", content);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }

    public async Task<bool> UpdateMedicalHistoryAsync(string cnp, MedicalHistoryDTO medicalHistoryDTO)
    {
        var content = new StringContent(JsonSerializer.Serialize(medicalHistoryDTO), Encoding.UTF8, "application/json");

        var response = await _client.PatchAsync($"Patient/edit/medicalHistory/{cnp}", content);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }

    public async Task<bool> UpdateInsuranceInformationAsync(string cnp, InsuranceInformationDTO insuranceInformationDTO)
    {
        var content = new StringContent(JsonSerializer.Serialize(insuranceInformationDTO), Encoding.UTF8, "application/json");

        var response = await _client.PatchAsync($"Patient/edit/insuranceInformation/{cnp}", content);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        var errorMessage = await response.Content.ReadAsStringAsync();
        throw new Exception(errorMessage);
    }
}
