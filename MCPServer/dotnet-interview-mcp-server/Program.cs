using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.Server;
using System.ComponentModel;
using dotnet_interview_mcp_server.Tools;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<TodoListTools>()
    .WithTools<TodoListItemTools>();

builder.Services.AddHttpClient();

await builder.Build().RunAsync();

//[McpServerToolType]
//public class EchoTool
//{
//    [McpServerTool, Description("Echoes the message back to the client.")]
//    public static string Echo(string message) => $"Hello from C#: {message}";

//    [McpServerTool, Description("Echoes in reverse the message sent by the client.")]
//    public static string ReverseEcho(string message) => new string(message.Reverse().ToArray());
//}