using ModelContextProtocol.Server;
using System;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using dotnet_interview_mcp_server.Models;

namespace dotnet_interview_mcp_server.Tools
{
    [McpServerToolType]
    public class TodoListItemTools
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:7027/api/";
        
        public TodoListItemTools()
        {
            _httpClient = new HttpClient();
        }
        
        [McpServerTool, Description("Gets all items")]
        public async Task<string> GetListItems()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}todolistitems");

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

        [McpServerTool, Description("Get a item by id")]
        public async Task<string> GetListItem(long id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}todolistitems/{id}");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                               
                return responseBody;

            }
            catch (Exception ex)
            {
                return "Error getting lists: " + ex.Message;
            }
        }

        [McpServerTool, Description("Set a new body for an item by id")]
        public async Task<string> PutListItem(long id, string body)
        {
            try
            {

                var item = new Item { ItemId = id, Body = body };

                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}todolistitems", content);

                return response.IsSuccessStatusCode ? "Item updated successfully!" : $"Error: {response.StatusCode}";
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

        [McpServerTool, Description("Mark item as completed")]
        public async Task<string> PutListItemCompleted(long id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}todolistitems/{id}", null);

                return response.IsSuccessStatusCode ? "Item completed successfully!" : $"Error: {response.StatusCode}";
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

        [McpServerTool, Description("Create a new item providing TodoListId and item body")]
        public async Task<string> PostTodoListItem(long listId, string body)
        {
            try
            {

                var item = new Item { TodoListId = listId, Body = body };

                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_apiUrl}todolistitems", content);

                return response.IsSuccessStatusCode ? "Item added successfully!" : $"Error: {response.StatusCode}";
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

        [McpServerTool, Description("Delete an item by id")]
        public async Task<string> DeleteTodoListItem(long id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}todolistitems/{id}");

                return response.IsSuccessStatusCode ? "Item deleted successfully!" : $"Error: {response.StatusCode}";
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
