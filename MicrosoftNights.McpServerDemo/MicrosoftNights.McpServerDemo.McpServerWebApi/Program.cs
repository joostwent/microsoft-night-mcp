using MicrosoftNights.McpServerDemo.Tools;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly(typeof(OrderTool).Assembly);

var app = builder.Build();

app.MapMcp();

app.Run();