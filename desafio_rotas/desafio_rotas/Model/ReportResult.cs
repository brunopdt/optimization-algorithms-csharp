using System.Diagnostics;

namespace desafio_rotas.Model
{
    public class ReportResult
    {
        public DateTime dateTime { get; }
        public double timeSpentMS { get; set; }
        private Stopwatch timer;

        ReportResult()
        {
            this.dateTime = DateTime.Now;
            this.timer = new Stopwatch();
        }
        public void startTime() => timer.Start();
        public void endTime()
        {
            timer.Stop();
            this.timeSpentMS = timer.ElapsedMilliseconds / 1000;
        }
    }
}
