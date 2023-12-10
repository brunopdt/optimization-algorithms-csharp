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
        var sortedRoutesReverse = this.transporter.routes.OrderBy(r => r).ToArray();
        int currentTruckIndex = 0;

        for (int i = 0; i < sortedRoutesReverse.Length; i++)
        {
            if (this.transporter.trucks[currentTruckIndex].totalRoute + sortedRoutesReverse[i] <= this.transporter.averageTruckRoutes)
            {
                this.transporter.trucks[currentTruckIndex].AddRoute(sortedRoutesReverse[i]);
            }
            else
            {
                if (currentTruckIndex < this.transporter.trucks.Count - 1)
                    currentTruckIndex++;
                else currentTruckIndex = 0;
                this.transporter.trucks[currentTruckIndex].AddRoute(sortedRoutesReverse[i]);
            }
        }


        this.reportResult.endTime();

        return reportResult;
    }
}