using System;
using Microsoft.Extensions.DependencyInjection;
using Backend.Services;
using Backend.Utilities;

class Program
{
    static void Main(string[] args)
    {
        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddSingleton<NatsService>()
            .AddSingleton<CsvFileWriter>()
            .BuildServiceProvider();

        // Get Services
        var natsService = serviceProvider.GetService<NatsService>();
        var csvWriter = serviceProvider.GetService<CsvFileWriter>();

        // Subscribe to streams
        natsService.Subscribe("stream.booleans", new DataHandler<bool>(csvWriter, "booleans.csv"));
        natsService.Subscribe("stream.integers", new DataHandler<int>(csvWriter, "integers.csv"));
        natsService.Subscribe("stream.uintegers", new DataHandler<uint>(csvWriter, "uintegers.csv"));
        natsService.Subscribe("stream.floats", new DataHandler<float>(csvWriter, "floats.csv"));

        Console.WriteLine("Subscriptions are set up. Press any key to exit...");
        Console.ReadKey();
    }
}