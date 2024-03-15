namespace SignalRServer.Hubs;

public interface IChatClient
{
    Task ReceiveMessage(string message);
}
