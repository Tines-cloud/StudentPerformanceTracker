using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SPTKnowledgeService.DTO;

namespace StudentPerformanceTracker.API_Service
{
    public class KnowledgeServiceClient
    {
        private readonly HttpClient _httpClient;

        public KnowledgeServiceClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7141/apigateway/knowledge/") };
        }

        // Methods for KnowledgeController

        public async Task<IEnumerable<KnowledgeDTO>> GetKnowledgeAsync()
        {
            var response = await _httpClient.GetAsync("knowledge");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<KnowledgeDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<KnowledgeDTO> GetKnowledgeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"knowledge/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KnowledgeDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task AddKnowledgeAsync(KnowledgeDTO knowledge)
        {
            var content = new StringContent(JsonSerializer.Serialize(knowledge), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("knowledge", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateKnowledgeAsync(KnowledgeDTO knowledge)
        {
            var content = new StringContent(JsonSerializer.Serialize(knowledge), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"knowledge/{knowledge.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteKnowledgeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"knowledge/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<KnowledgeDTO>> GetKnowledgeByCriteriaAsync(string subjectCode, string username, DateTime? fromDate, DateTime? toDate)
        {
            var url = $"knowledge/search/{username}?subjectCode={subjectCode}&fromDate={fromDate?.ToString("o")}&toDate={toDate?.ToString("o")}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<KnowledgeDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<KnowledgeDTO> GetLatestKnowledgeAsync(string subjectCode, string username)
        {
            var response = await _httpClient.GetAsync($"knowledge/latest/{username}/{subjectCode}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KnowledgeDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> KnowledgeExistsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"knowledge/exists/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Methods for BreakController

        public async Task<IEnumerable<BreakDTO>> GetBreaksAsync()
        {
            var response = await _httpClient.GetAsync("break");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<BreakDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<BreakDTO> GetBreakByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"break/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<BreakDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task AddBreakAsync(BreakDTO breakDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(breakDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("break", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateBreakAsync(BreakDTO breakDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(breakDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"break/{breakDto.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBreakAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"break/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<BreakDTO>> GetBreaksByCriteriaAsync(string subjectCode, string username, DateTime? fromDate, DateTime? toDate)
        {
            var url = $"break/search/{username}?subjectCode={subjectCode}&fromDate={fromDate?.ToString("o")}&toDate={toDate?.ToString("o")}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<BreakDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> BreakExistsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"break/exists/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Methods for StudySessionController

        public async Task<IEnumerable<StudySessionDTO>> GetStudySessionsAsync()
        {
            var response = await _httpClient.GetAsync("studysession");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<StudySessionDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<StudySessionDTO> GetStudySessionByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"studysession/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StudySessionDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task AddStudySessionAsync(StudySessionDTO studySessionDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(studySessionDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("studysession", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateStudySessionAsync(StudySessionDTO studySessionDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(studySessionDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"studysession/{studySessionDto.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStudySessionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"studysession/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> StudySessionExistsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"studysession/exists/{id}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<StudySessionDTO>> GetStudySessionsByCriteriaAsync(string subjectCode, string username, DateTime? fromDate, DateTime? toDate)
        {
            var url = $"studysession/search/{username}?subjectCode={subjectCode}&fromDate={fromDate?.ToString("o")}&toDate={toDate?.ToString("o")}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<StudySessionDTO>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
