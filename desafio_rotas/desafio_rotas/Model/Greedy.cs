using desafio_rotas.Model;

public class Greedy(Transporter transporter)
{
    Transporter transporter = transporter;
    ReportResult reportResult { get; set; } = new ReportResult(transporter);
    public ReportResult DistributeRoutes1stAlgorithm()
    {
        this.reportResult.startTime();
        var sortedRoutes = this.transporter.routes.OrderBy(r => r).ToArray();

        for (int i = 0; i < sortedRoutes.Length; i++)
        {
            this.transporter.trucks[i % this.transporter.trucks.Count].AddRoute(sortedRoutes[i]);
        }
        this.reportResult.endTime();
        return reportResult;
    }

    public ReportResult DistributeRoutes2ndAlgorithm()
    {
        this.reportResult.startTime();
        var sortedRoutes = this.transporter.routes.OrderBy(r => r).Reverse().ToArray();

        for (int i = 0; i < sortedRoutes.Length; i++)
        {
            int targetTruckIndex = i % this.transporter.trucks.Count;

            if (sortedRoutes[i] > this.transporter.averageTruckRoutes + this.transporter.averageTruckRoutes)
            {
                this.transporter.trucks[targetTruckIndex].AddRoute(sortedRoutes[i]);
            }
            else
            {
                while (this.transporter.trucks[targetTruckIndex].totalRoute + sortedRoutes[i] <= this.transporter.averageTruckRoutes + this.transporter.averageTruckRoutes)
                {
                    this.transporter.trucks[targetTruckIndex].AddRoute(sortedRoutes[i]);
                }
                targetTruckIndex = (targetTruckIndex + 1) % this.transporter.trucks.Count;
            }
        }
        this.reportResult.endTime();

        return reportResult;
    }
}