// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;

const string URL = "https://localhost:7186/chat";
var conn = new HubConnectionBuilder()
    .WithUrl(URL)
    .Build();

conn.On<string>("ReceiveMessage", (message) =>
{
    Console.WriteLine(message);
});

try
{
    await conn.StartAsync();
    Console.WriteLine("Connection started.");

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

