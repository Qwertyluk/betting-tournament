using BettingTournament.Core.Services;
using Microsoft.Extensions.Options;

namespace BettingTournament.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private readonly TimeSpan _timerPeriod;
        private readonly UpdateManager _updateManager;

        public TimedHostedService(IOptions<Settings> options, UpdateManager updateManager)
        {
            var settings = options.Value;
            _timerPeriod = TimeSpan.FromSeconds(settings.ServiceIntervalInSeconds);
            _updateManager = updateManager;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, _timerPeriod);

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            _updateManager.UpdateSystemAsync();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
