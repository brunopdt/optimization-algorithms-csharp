using System.Linq;

namespace desafio_rotas.Model
{

    public class DivideAndConquer(Transporter transporter)
    {
        private Transporter transporter = transporter;
        private ReportResult reportResult = new ReportResult(transporter);
        public ReportResult DistributeRoutes()
        {
            this.reportResult.startTime();
            DivideAndConquerMethod(transporter.routes.OrderByDescending(r => r).ToList(), transporter.trucks);
            this.reportResult.endTime();
            return reportResult;
        }

        private void DivideAndConquerMethod(List<int> routes, List<Truck> trucks)
        {
            if (routes.Count == 1)
            {
                transporter.trucks.OrderBy(x => x.totalRoute).ToList()[0].AddRoute(routes[0]);
                return;
            }

            int middleIndex = routes.Count / 2;

            List<int> leftHalf = routes.Take(middleIndex).ToList();
            List<int> rightHalf = routes.Skip(middleIndex).ToList();

            for (int i = 0; i < leftHalf.Count; i++)
            {
                var truck = trucks.OrderBy(t => t.totalRoute).First();
                if (leftHalf[i] + truck.totalRoute <= (transporter.averageTruckRoutes))
                    truck.AddRoute(leftHalf[i]);
            }

            DivideAndConquerMethod(rightHalf, trucks);
        }
    }
}
