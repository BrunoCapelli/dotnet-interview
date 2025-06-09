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
