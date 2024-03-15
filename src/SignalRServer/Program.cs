using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();
app.MapHub<ChatHub>("chat");

app.MapGet("/", () => "Hello World!");

app.MapPost("send", async (ChatModel request, IHubContext<ChatHub, IChatClient> context) =>
{
    await context.Clients.All.ReceiveMessage($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {request.Name}: {request.Message}");

    return Results.NoContent();
});

app.Run();
