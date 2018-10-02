using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SignalRDemo.Models;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.Sensor
{
    
    class Program
    {
        private static HubConnection _hubConnection;

        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            await SetupSignalRHubAsync();

            Console.WriteLine("Connected to Hub");

            // Console.WriteLine("Press ESC to stop");

            Random random = new Random();

            do
            {
                Message message = new Message { Value = random.Next(0, 100) };

                await _hubConnection.SendAsync("Send", message);

                Console.WriteLine($"Send {message.Value}");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            while (true);
            //while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        // PM> Install-Package Microsoft.AspNetCore.SignalR.Client
        public static async Task SetupSignalRHubAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                 .WithUrl("http://localhost:5000/messages")
                 // .AddMessagePackProtocol()
                 // .ConfigureLogging(options => options.AddConsole())
                 .Build();

            await _hubConnection.StartAsync();
        }
    }
}
