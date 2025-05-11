// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// https://learn.microsoft.com/fr-fr/dotnet/orleans/tutorials-and-samples/tutorial-1

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
      silo.UseLocalhostClustering()
          .ConfigureLogging(logging => logging.AddConsole());
    })
    .UseConsoleLifetime();

using IHost host = builder.Build();

await host.RunAsync();