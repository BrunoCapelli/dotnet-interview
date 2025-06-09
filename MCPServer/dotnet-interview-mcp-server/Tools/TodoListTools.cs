using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using dotnet_interview_mcp_server.Models;

namespace dotnet_interview_mcp_server.Tools
{
    public class TodoListTools
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:8080/api/";
        public TodoListTools() 
        {
            _httpClient = new HttpClient();
        }

        [McpServerTool, Description("Gets all lists")]
        public async Task<string> GetLists()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}todolists");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;

            }
            catch (HttpRequestException ex)
            {
                return $"HTTP Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }

        [McpServerTool, Description("Get a list by id")]
        public async Task<string> GetList(long id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}todolists/{id}");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;

            }
            catch (Exception ex)
            {
                return "Error getting lists: " + ex.Message;
            }
        }

        [McpServerTool, Description("Rename a list by ID")]
        public async Task<string> PutList(long id, string name)
        {
            try
            {
                var list = new TodoList { Name = name };

                var json = JsonSerializer.Serialize(list);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}todolists/{id}", content);

                return response.IsSuccessStatusCode ? "TodoList updated successfully!" : $"Error: {response.StatusCode}";
            }
            catch (HttpRequestException ex)
            {
                return $"HTTP Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }

        [McpServerTool, Description("Create a new list providing a name")]
        public async Task<string> PostTodoList(string name)
        {
            try
            {
                var list = new TodoList { Name = name};

                var json = JsonSerializer.Serialize(list);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_apiUrl}todolists", content);

                return response.IsSuccessStatusCode ? "TodoList added successfully!" : $"Error: {response.StatusCode}";
            }
            catch (HttpRequestException ex)
            {
                return $"HTTP Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }

        [McpServerTool, Description("Delete a list by id")]
        public async Task<string> DeleteTodoList(long id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}todolists/{id}");

                return response.IsSuccessStatusCode ? "TodoList deleted successfully!" : $"Error: {response.StatusCode}";
            }
            catch (HttpRequestException ex)
            {
                return $"HTTP Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }

    }
    
}
