using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCaptureServices
{
    public class WeeklyWorker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        

        public WeeklyWorker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("2. worker çalıştı");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
