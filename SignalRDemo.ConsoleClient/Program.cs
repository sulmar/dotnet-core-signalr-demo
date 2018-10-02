using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using SignalRDemo.Models;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.ConsoleClient
{
    class Program
    {
        private static HubConnection _hubConnection;

        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            await SetupSignalRHubAsync();

            Console.WriteLine("Connected to Hub");

            _hubConnection.On<Message>("Send", message => Console.WriteLine($"Received {message.Value}"));

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

            await _hubConnection.DisposeAsync();

        }

        // PM> Install-Package Microsoft.AspNetCore.SignalR.Client
        public static async Task SetupSignalRHubAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                 .WithUrl("http://localhost:5000/messages")
                 // .AddMessagePackProtocol()
                 //.ConfigureLogging(factory =>
                 //{
                 //    factory.AddConsole();
                 //    factory.AddFilter("Console", level => level >= LogLevel.Trace);
                 //})
                 .Build();

            await _hubConnection.StartAsync();
        }
    }
}
