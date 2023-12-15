using System;
using System.Collections.Generic;
using System.Linq;

namespace desafio_rotas.Model
{

    public class DivideAndConquer(Transporter transporter)
    {
        private Transporter transporter = transporter;
        private ReportResult reportResult = new ReportResult(transporter);
        private double optimalAvg;
        public ReportResult DistributeRoutes()
        {
            this.reportResult.startTime();
            List<int> routes = new List<int>(transporter.routes);
            transporter.alterTolerance(0);
            optimalAvg = transporter.averageTruckRoutes;
            foreach (Truck truck in transporter.trucks)
            {
                truck.AddRoute(RunDivideAndConquer(routes).Last());
                foreach (int route in truck.routes)
                {
                    routes.Remove(route);
                }
            }

            if (routes.Count > 0)
            {
                foreach (int route in routes)
                {
                    transporter.trucks.OrderByDescending(truck => truck.routes.Sum())
                                      .Last()
                                      .AddRoute(route);
                }
            }

            this.reportResult.endTime();
            return reportResult;
        }

        public List<List<int>> RunDivideAndConquer(List<int> routes)
        {
            List<List<int>> possibleRoutesLeft = new();
            List<List<int>> possibleRoutesRight = new();
            if (routes.Count == 0)
            {
                return new();
            }
            else if (routes.Count <= 2)
            {
                return GenerateAllTwoRouteCombination(routes);
            }
            else
            {
                possibleRoutesLeft = RunDivideAndConquer(routes.Take(routes.Count / 2)
                                                               .ToList());
                possibleRoutesRight = RunDivideAndConquer(routes.Skip(routes.Count / 2)
                                                                .ToList());
            }

            int leftPointer = 0;
            int rightPointer = possibleRoutesRight.Count - 1;

            possibleRoutesLeft = possibleRoutesLeft.OrderByDescending(route => route.Sum())
                                                   .ToList();
            possibleRoutesRight = possibleRoutesRight.OrderByDescending(route => route.Sum())
                                                     .ToList();
            List<List<int>> possibleRoutes = new();

            do
            {
                int leftSum;
                int rightSum;
                List<int> leftRoute, rightRoute;
                rightRoute = possibleRoutesRight[rightPointer];
                rightSum = rightRoute.Sum();
                leftRoute = possibleRoutesLeft[leftPointer];
                leftSum = leftRoute.Sum();


                int sum = leftSum + rightSum;

                List<int> route = leftRoute.Concat(rightRoute).ToList();

                if (sum > optimalAvg)
                {
                    leftPointer++;
                }
                else if (sum <= optimalAvg)
                {
                    rightPointer--;
                }
                possibleRoutes.Add(leftRoute);
                possibleRoutes.Add(rightRoute);
                possibleRoutes.Add(route);

            } while (leftPointer < possibleRoutesLeft.Count && rightPointer < possibleRoutesRight.Count && rightPointer >= 0);



            return possibleRoutes.OrderByDescending(route => GetDiffToOptimalAvg(route.Sum()))
                                 .ToList();
        }

        private double GetDiffToOptimalAvg(int route)
        {
            return Math.Abs(route - optimalAvg);
        }

        private List<List<int>> GenerateAllTwoRouteCombination(List<int> routes)
        {
            if (routes.Count == 0)
            {
                return new();
            }
            if (routes.Count == 1)
            {
                return new List<List<int>> { new List<int> { routes[0] } };
            }

            List<List<int>> allRoutes = new List<List<int>>
            {
                new List<int> { routes[0] },
                new List<int> { routes[1] },
                new List<int> { routes[0], routes[1] }
            };

            return allRoutes.OrderByDescending(route => route.Sum()).ToList();
        }
    }
}
