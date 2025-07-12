using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicrosoftNights.McpServerDemo.Tools;

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly(typeof(OrderTool).Assembly);

await builder.Build().RunAsync();