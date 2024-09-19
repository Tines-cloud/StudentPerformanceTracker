using SPTUserService.DTO;
using StudentPerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentPerformanceTracker.API_Service
{
    public class UserServiceClient
    {
        private readonly HttpClient _httpClient;

        public UserServiceClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7141/apigateway/user/") };
        }

        public async Task<UserDTO> LoginAsync(string username, string password)
        {
            var loginDto = new LoginDTO { Username = username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync("users/login", content);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<UserDTO>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var response = await _httpClient.GetAsync($"users/{username}");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error fetching user by username: {response.StatusCode}");
                return null;
            }

            var user = JsonSerializer.Deserialize<UserDTO>(jsonResponse);
            EventService.CurrentUser = user;
            return user;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync("users");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<UserDTO>>(jsonResponse);
        }

        public async Task AddUserAsync(UserDTO user)
        {
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("users", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(string username, UserDTO user)
        {
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"users/{username}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(string username)
        {
            var response = await _httpClient.DeleteAsync($"users/{username}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            var response = await _httpClient.GetAsync($"users/Exists/{username}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(jsonResponse);
        }
    }
}
