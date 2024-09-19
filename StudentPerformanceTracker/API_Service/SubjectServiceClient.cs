using System.Text.Json;
using SPTKnowledgeService.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker.API_Service
{
    public class SubjectServiceClient
    {
        private readonly HttpClient _httpClient;

        public SubjectServiceClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7141/apigateway/subject/") };
        }

        public async Task<IEnumerable<SubjectDTO>> GetSubjectsAsync()
        {
            var response = await _httpClient.GetAsync("subjects");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<SubjectDTO>>(jsonResponse);
        }

        public async Task<SubjectDTO> GetSubjectBySubjectCodeAsync(string subjectCode)
        {
            var response = await _httpClient.GetAsync($"subjects/{subjectCode}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SubjectDTO>(jsonResponse);
        }

        public async Task AddSubjectAsync(SubjectDTO subject)
        {
            var content = new StringContent(JsonSerializer.Serialize(subject), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("subjects", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSubjectAsync(string subjectCode, SubjectDTO subject)
        {
            var content = new StringContent(JsonSerializer.Serialize(subject), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"subjects/{subjectCode}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSubjectAsync(string subjectCode)
        {
            var response = await _httpClient.DeleteAsync($"subjects/{subjectCode}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> SubjectExistsAsync(string subjectCode)
        {
            var response = await _httpClient.GetAsync($"subjects/Exists/{subjectCode}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(jsonResponse);
        }
    }
}
