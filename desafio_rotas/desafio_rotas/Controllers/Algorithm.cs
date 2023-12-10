using desafio_rotas.DTOs;
using desafio_rotas.Model;
using Microsoft.AspNetCore.Mvc;

namespace desafio_rotas.Controllers
{
    [ApiController]
    [Route("algorithm")]
    public class Algorithm : ControllerBase
    {
        [HttpPost("/divide-and-conquer")]
        public Report divideAndConquer([FromBody] BaseAlgorithmDTO dto)
        {
            Transporter transporter;
            DivideAndConquer divideAndConquer;
            ReportResult currentReportResult;
            Report report = new("Algoritmo Divisão e conquista", "", "Cria uma tabela com os possíveis resultados e retorna o resultado ótimo");

            DataApplication.baseRoutes.ForEach(route =>
            {
                transporter = new(dto.truckAmount, route.ToList());
                divideAndConquer = new(transporter);
                currentReportResult = divideAndConquer.DistributeRoutes();
                report.addResult(currentReportResult);
            });
            DataApplication.reports.Add(report);

            return report;
        }

        [HttpPost("/greedy")]
        public Report Greedy([FromBody] GreedyAlgorithmDTO dto)
        {
            Transporter transporter;
            Greedy greedy;
            ReportResult currentReportResult;
            Report report = new("Algoritmo Guloso", "", "Escolhe a melhor opção no momento da iteração, entretanto, não garante o resultado ótimo");

            DataApplication.baseRoutes.ForEach(route =>
            {
                transporter = new(dto.truckAmount, route.ToList());
                greedy = new Greedy(transporter);
                if (dto.method == 1)
                    currentReportResult =  greedy.DistributeRoutes1stAlgorithm();
                else
                    currentReportResult = greedy.DistributeRoutes2ndAlgorithm();

                report.addResult(currentReportResult);
            });
            DataApplication.reports.Add(report);

            return report;
        }

        [HttpPost("/dynamic-programming")]
        public Report DynamicProgramming([FromBody] BaseAlgorithmDTO dto)
        {
            Transporter transporter;
            DynamicProgramming dynamicProgramming;
            ReportResult currentReportResult;
            Report report = new("Algoritmo Programação dinamica", "", "Cria uma tabela com os possíveis resultados e retorna o resultado ótimo");

            DataApplication.baseRoutes.ForEach(route =>
            {
                transporter = new(dto.truckAmount, route.ToList());
                dynamicProgramming = new(transporter);
                currentReportResult = dynamicProgramming.RunMethod();
                report.addResult(currentReportResult);
            });
            DataApplication.reports.Add(report);

            return report;
        }
    }
}
