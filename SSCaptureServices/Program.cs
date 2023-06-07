using Serilog.Events;
using Serilog;
using SSCaptureServices;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(@"C:\temp\ScreenTracker\LogFile.txt")
    .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHostedService<WeeklyWorker>();
    })
    .UseSerilog()
    .Build();

await host.RunAsync();
