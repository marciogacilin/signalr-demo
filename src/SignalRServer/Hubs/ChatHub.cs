using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs;

public sealed class ChatHub : Hub<IChatClient>
{
    public async Task SendMessage(string message)
    {
        await Clients.All.ReceiveMessage(message);
    }
}

public record ChatModel(string Name, string Message);