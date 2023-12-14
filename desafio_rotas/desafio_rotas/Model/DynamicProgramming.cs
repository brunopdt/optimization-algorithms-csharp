using desafio_rotas.Model;

namespace desafio_rotas.Model
{
    public class DynamicProgramming(Transporter transporter)
    {
        private Transporter transporter = transporter;
        private ReportResult reportResult = new ReportResult(transporter);
        private List<int> possibleRoutes = new(); 

        private void CloneRoutesFromTransporter() => transporter.routes.ForEach(route => possibleRoutes.Add(route));
        private void CalculateResults(List<int> possibleRoutes, int[] dynamicTableLimits)
        {
            for (int i = 0; i < transporter.trucks.Count; i++)
            {
                transporter.trucks[i].AddRoute(CalculateRoutesToEachTruck(possibleRoutes, dynamicTableLimits));
            }
        }

        private List<int> FindRoutes(int[,] dynamicTable, List<int> routes)
        {
            List<int> solutionRoutes = new List<int>();
            int row = dynamicTable.GetLength(0) - 1;
            int column = dynamicTable.GetLength(1) - 1;


            while (row >= 0 && column > 0)
            {
                if (row == 0 && routes[row] == dynamicTable[row, column])
                {
                    solutionRoutes.Add(routes[row]);
                    break;
                }
                else if (row == 0)
                {
                    break;
                }
                else if (dynamicTable[row, column] != dynamicTable[row - 1, column])
                {
                    solutionRoutes.Add(routes[row]);
                    column -= routes[row];
                    row -= 1;
                }
                else
                {
                    row -= 1;
                }
            }

            return solutionRoutes;
        }

        private int[] DefineDynamicTableLimits()
        {
            double floatUpperLimit = (transporter.sumRoutes / transporter.trucks.Count) * (1 + transporter.tolerance);
            int upperLimit = (int)Math.Floor(floatUpperLimit);
            int[] dynamicTableLimits = new int[upperLimit];
            for (int i = 0; i < upperLimit; i++)
            {
                dynamicTableLimits[i] = i;
            }
            return dynamicTableLimits;
        }

        private int[] RemoveUsedRoutes(List<int> possibleRoutes, List<int> solutionRoutes)
        {
            foreach (int currentRoute in solutionRoutes)
            {
                int index = possibleRoutes.FindIndex(r => r == currentRoute);
                if (index != -1)
                {
                    possibleRoutes.RemoveAt(index);
                }
            }

            int[] dynamicTableLimits = possibleRoutes.ToArray();

            return dynamicTableLimits;
        }

        private List<int> CalculateRoutesToEachTruck(List<int> possibleRoutes, int[] dynamicTableLimits)
        {

            List<int> solutionRoutes;


            int[,] dynamicTable = new int[possibleRoutes.Count, dynamicTableLimits.Length];

            for (int i = 0; i < possibleRoutes.Count; i++)
            {
                for (int j = 0; j < dynamicTableLimits.Length; j++)
                {
                    if ((i == 0 && possibleRoutes[i] > j) || j == 0)
                    {
                        dynamicTable[i, j] = 0;
                    }
                    else if (i == 0 && possibleRoutes[i] <= j)
                    {
                        dynamicTable[i, j] = possibleRoutes[i];
                    }
                    else if (possibleRoutes[i] <= dynamicTableLimits[j])
                    {
                        dynamicTable[i, j] = Math.Max(dynamicTable[i - 1, j], possibleRoutes[i] + dynamicTable[i - 1, j - possibleRoutes[i]]);
                    }
                    else
                    {
                        dynamicTable[i, j] = dynamicTable[i - 1, j];
                    }
                }
            }

            solutionRoutes = FindRoutes(dynamicTable, possibleRoutes);

            RemoveUsedRoutes(possibleRoutes, solutionRoutes);

            return solutionRoutes;
        }
        public ReportResult RunMethod()
        {
            transporter.alterTolerance(0.05);
            reportResult.startTime();
            int[] dynamicTableLimits = DefineDynamicTableLimits();
            CloneRoutesFromTransporter();
            CalculateResults(possibleRoutes, dynamicTableLimits);
            reportResult.endTime();
            return this.reportResult;
        }
    }
}
