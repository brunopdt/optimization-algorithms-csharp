using System.Diagnostics;

namespace desafio_rotas.Model
{
    public class Report
    {
        public string reason { get; }
        public string behavior { get; }
        public string algorithm { get; }
        public double timeSpentMS { get; set; }
        public DateTime dateTime { get; }
        private Stopwatch timer;
        public Report(string algorithm, string reason, string behavior) { 
            this.reason = reason;
            this.algorithm = algorithm;
            this.behavior = behavior;
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
