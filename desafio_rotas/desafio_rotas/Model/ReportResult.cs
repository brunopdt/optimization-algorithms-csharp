using System.Diagnostics;

namespace desafio_rotas.Model
{
    public class ReportResult
    {
        public double timeSpentMS { get; set; }
        public Transporter transporter { get; set; }

        private Stopwatch timer;

        public ReportResult(Transporter transporter)
        {
            this.timer = new Stopwatch();
            this.transporter = transporter;
        }
        public void startTime() => timer.Start();
        public void endTime()
        {
            timer.Stop();
            this.timeSpentMS = timer.ElapsedMilliseconds / 1000;
        }
    }
}
