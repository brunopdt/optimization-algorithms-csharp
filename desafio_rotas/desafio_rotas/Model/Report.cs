using System.Diagnostics;

namespace desafio_rotas.Model
{
    public class Report
    {
        public string reason { get; }
        public string behavior { get; } 
        public string algorithm { get; }
        public DateTime dateTime { get; }
        public TimeSpan averageTime { get; set; }

        public List<ReportResult> results { get; set; }
        public Report(string algorithm, string reason, string behavior) { 
            this.reason = reason;
            this.algorithm = algorithm;
            this.behavior = behavior;
            this.dateTime = DateTime.Now;
            results = new();
        }

        public void addResult(ReportResult result)
        {
            this.results.Add(result);
            double average = results.Average(x => x.timeSpentMS.Microseconds);
            this.averageTime = TimeSpan.FromMicroseconds(average);
        }
    }   
}
