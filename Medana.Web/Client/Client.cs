using Medana.API.Entities;
using Medana.API.Entities.DTOs;
using System.Text;
using System.Text.Json;

namespace Medana.Web.Client
{
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

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var response = await _client.GetAsync($"Patient/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Patient>(json, _jsonSerializerOptions);
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
    }

}
