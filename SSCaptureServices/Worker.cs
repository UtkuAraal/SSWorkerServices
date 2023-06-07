
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;

namespace SSCaptureServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private Stopwatch _stopwatch;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _stopwatch.Stop();
            Console.WriteLine(_stopwatch.Elapsed);
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //TakeScreenShot();
                _logger.LogInformation("SS alýndý!");
                Console.WriteLine("SS alýndý! ");
                await Task.Delay(10000, stoppingToken);
            }
        }

        private void TakeScreenShot() 
        {
            string fileName = DateTime.Now.ToString().Replace(" ", "_");
            using var bitmap = new Bitmap(1920, 1080);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0,
                bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            bitmap.Save(fileName + ".jpg", ImageFormat.Jpeg);
        }

        
    }


}

