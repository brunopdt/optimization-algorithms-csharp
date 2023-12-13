using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
namespace desafio_rotas.Model
{
    public class Backtracking(Transporter transporter)
    {
        private Transporter transporter = transporter;
        private ReportResult reportResult = new ReportResult(transporter);
        private double optimalAvg;
        private double bestDiff;
        private List<List<int>> allPossibleRoutes = new();
        public ReportResult RunMethod()
        {
            reportResult.startTime();
            transporter.alterTolerance(0);
            optimalAvg = transporter.averageTruckRoutes;

            List<int> routes = new(transporter.routes);
            foreach (Truck truck in transporter.trucks)
            {
                int i = 0;
                bestDiff = double.MaxValue;
                foreach (int route in routes)
                {
                    Try(route, new List<int>(), i++, routes);
                }
                truck.AddRoute(allPossibleRoutes.OrderByDescending(route => Math.Abs(route.Sum() - optimalAvg)).Last());

                foreach (int route in truck.routes)
                {
                    routes.Remove(route);
                }

                allPossibleRoutes.Clear();
            }

            reportResult.endTime();
            return reportResult;
        }
        private bool CheckIfShouldPrune(int currentRouteSum, int routeCandidate)
        {
            return currentRouteSum + routeCandidate > optimalAvg && Math.Abs(currentRouteSum + routeCandidate - optimalAvg) > bestDiff;
        }
        private void Try(int candidate, List<int> currentRoute, int idxRoute, List<int> routes)
        {
            if (CheckIfShouldPrune(currentRoute.Sum(), candidate))
            {
                return;
            }
            else
            {
                currentRoute.Add(candidate);
                double curDiff = Math.Abs(currentRoute.Sum() - optimalAvg);
                if (curDiff < bestDiff)
                {
                    bestDiff = curDiff;
                }

                int i = 1;
                allPossibleRoutes.Add(new(currentRoute));
                foreach (int route in routes.Skip(idxRoute + 1))
                {
                    Try(route, currentRoute, idxRoute + i, routes);
                    i++;
                }

                currentRoute.Remove(candidate);
            }
        }
    }
}