using System.Diagnostics;

namespace desafio_rotas.Model
{
    public class ReportResult(Transporter transporter)
    {
        public TimeSpan timeSpentMS { get; set; }
        public Transporter transporter { get; set; } = transporter;

        private Stopwatch timer = new Stopwatch();

        public void startTime() => timer.Start();
        public void endTime()
        {
            timer.Stop();
            this.timeSpentMS = timer.Elapsed;

        }
    }
}
