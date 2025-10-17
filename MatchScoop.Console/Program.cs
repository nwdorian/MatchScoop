using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder();

builder.Logging.AddConsole();

var host = builder.Build();

await host.RunAsync();
