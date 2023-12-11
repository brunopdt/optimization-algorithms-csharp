using System;
namespace desafio_rotas.Model
{
    public class Backtracking(Transporter transporter)
    {
        private Transporter transporter = transporter;
        private ReportResult reportResult = new ReportResult(transporter);
        private double minDifference = double.MaxValue;
        private int[][] bestRouteDistribution;

        public ReportResult RunMethod()
        {
            reportResult.startTime();
            bestRouteDistribution = new int[transporter.trucks.Count][];
            BacktrackingAlgorithm(0);
            int i = 0;
            foreach (Truck truck in transporter.trucks)
            {
                truck.AddRoute(new List<int>(bestRouteDistribution[i++]));
            }
            reportResult.endTime();
            return reportResult;
        }

        private double GetMaxDiff()
        {
            List<Truck> sortedTrucks = new List<Truck>(transporter.trucks);
            sortedTrucks.Sort((Truck x, Truck y) => x.totalRoute < y.totalRoute ? 1 : -1);
            return sortedTrucks.First().totalRoute - sortedTrucks.Last().totalRoute;
        }

        private void BacktrackingAlgorithm(int idxRota)
        {
            List<int> listRoutes = transporter.routes;
            if (idxRota == listRoutes.Count)
            {
                double currentDifference = GetMaxDiff();
                if (currentDifference < minDifference && transporter.trucks.Sum(truck => truck.totalRoute) == transporter.routes.Sum())
                {
                    minDifference = currentDifference;
                    int i = 0;
                    foreach (Truck truck in transporter.trucks)
                    {
                        this.bestRouteDistribution[i++] = truck.routes.ToArray();
                    }
                }
                return;
            }

            foreach (Truck truck in transporter.trucks)
            {
                truck.AddRoute(transporter.routes[idxRota]);
                List<int> listPendingRoutes = transporter.routes.Skip(idxRota + 1).ToList();
                listPendingRoutes = listPendingRoutes.OrderByDescending(r => r).ToList();

                int smallestRoute = listPendingRoutes.Count > 0 ? listPendingRoutes.Last() : int.MaxValue;
                double maximumDifference = GetMaxDiff();
                if (maximumDifference <= minDifference || maximumDifference - smallestRoute <= minDifference)
                {
                    BacktrackingAlgorithm(idxRota + 1);
                }
                truck.RemoveRoute(transporter.routes[idxRota]);
            }
        }

    }
}

