﻿// See https://aka.ms/new-console-template for more information
using GrainInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
      client.UseLocalhostClustering();
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .UseConsoleLifetime();

using IHost host = builder.Build();
await host.StartAsync();

IClusterClient client = host.Services.GetRequiredService<IClusterClient>();

IHello friend = client.GetGrain<IHello>(0);
string response = await friend.SayHello("Hi friend!");

Console.WriteLine($"""
    {response}

    Press any key to exit...
    """);

Console.ReadKey();

await host.StopAsync();